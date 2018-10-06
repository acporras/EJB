using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace FE.InterfaceConsole
{
    class Program
    {
        public static System.Timers.Timer ti_intejesrv = new System.Timers.Timer(); //Intervalo de ejecución del servicio.
        public static int i = 0;
        public static BaseDatos BD = new BaseDatos("BASPRVNAM", "BASCADCON"); //Conexión a BD Facturación

        static void Main(string[] args)
        {

            ti_intejesrv.Interval = 5000;
            ti_intejesrv.Elapsed += new System.Timers.ElapsedEventHandler(ti_intejesrv_Elapsed);
            ti_intejesrv.Enabled = true;
            ti_intejesrv.Start();
            //ti_intejesrv_Elapsed();

            Console.ReadLine();
        }

        public static void ti_intejesrv_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //public static void ti_intejesrv_Elapsed()
        {
            ThreadStart ts_srvprosun = new ThreadStart(ml_proceso_sunat);
            Thread.CurrentThread.Name = "SRVPROSUN";
            Thread th_srvprosun = new Thread(ts_srvprosun);
            th_srvprosun.Start();
            th_srvprosun.Join();

            ti_intejesrv.Enabled = true;
        }

        //public static void ml_proceso_sunat(object sender, EventArgs args)
        public static void ml_proceso_sunat()
        {
            //Obtener Lista de Emisores electronicos
            BD.Conectar();
            IDataReader dr_emidocele = BD.Dame_Datos_DR("SPS_MAE_EMIDOCELE", false, "P");
            ListBEMaeemiele lst_maeemiele = new ListBEMaeemiele();
            lst_maeemiele = ml_get_maestro_emisores(dr_emidocele);
            //Recorre la lista de emisores
            BD.Desconectar();
            foreach (BEMaeemiele item in lst_maeemiele)
            {
                //Inicia el proceso de migración por cada compañia de forma independiente
                Thread th_srvpromig = new Thread(() => ml_migracion_documentos_cliente(item)) { Name = "SRVPROMIG" };
                th_srvpromig.Start();
            }
            Console.WriteLine("Inicio del servicio");
        }
        //Se encarga de realizar la migración de documentos a BD Facturación
        public static void ml_migracion_documentos_cliente(BEMaeemiele oBEMaeemiele)
        {
            Console.WriteLine("Migración - Empresa: " + oBEMaeemiele.nu_eminumruc);
            //Se iniciliza la conexión de la BD
            BaseDatos BDFact = new BaseDatos("BASPRVNAM", "BASCADCON");
            Boolean ProcessException = false;
            String MessageException = "";
            //Se verifica que no exista un proceso de migración en ejecución para la empresa
            BDFact.Conectar();
            BDFact.Añadir_Parametro(0, "NID_EMIDOCELE", "I", oBEMaeemiele.nid_maeemiele.ToString());
            BDFact.Añadir_Parametro(1, "CO_ESTPROINT", "S", "EJ"); //Ejecutando
            BDFact.Añadir_Parametro(2, "CO_TIPPROFAC", "S", "MI"); //Migración
            IDataReader dr_proejemig = BDFact.Dame_Datos_DR("SPS_TL_PROFACINT_BY_EMIDOCELE", true, "P");
            Boolean fl_proejemig = false;
            while (dr_proejemig.Read())
            {
                fl_proejemig = true;
                Console.WriteLine("Omitiendo por proceso abierto - Empresa: " + oBEMaeemiele.nu_eminumruc);
            }
            BDFact.Desconectar();
            //Si no existe proceso en ejecución se procede a hacer el volcado de información de la base cliente a la base de de facturación
            if (!fl_proejemig)
            {
                //Se crea un registro identificador de la tarea en ejecución
                Console.WriteLine("Aperturando nuevo proceso - Empresa: " + oBEMaeemiele.nu_eminumruc);
                BDFact.Conectar();
                BDFact.Añadir_Parametro(0, "CO_TIPPROFAC", "S", "MIG"); //Migración
                BDFact.Añadir_Parametro(1, "CO_ESTPROINT", "S", "EJ"); //Ejecutando
                BDFact.Añadir_Parametro(2, "NID_EMIDOCELE", "I", oBEMaeemiele.nid_maeemiele.ToString());
                BDFact.Ejecutar_PA("SPI_TL_PROFACINT", true);
                BDFact.Desconectar();
                //Se identifica el tipo de base de datos registrada
                BaseDatos.BBDD BBDD = 0;
                switch (oBEMaeemiele.no_bastipbas)
                {
                    case "SQL":
                        BBDD = BaseDatos.BBDD.SQL;
                        break;
                    case "ODBC":
                        BBDD = BaseDatos.BBDD.ODBC;
                        break;
                    case "OLEDB":
                        BBDD = BaseDatos.BBDD.OLEDB;
                        break;
                    case "MySQL":
                        BBDD = BaseDatos.BBDD.MySQL;
                        break;
                }
                //Crear conexión con base de datos cliente
                BaseDatos BDClient = new BaseDatos(oBEMaeemiele.no_basnomsrv, BBDD, oBEMaeemiele.no_basnombas,
                    oBEMaeemiele.no_basusrbas, oBEMaeemiele.no_basusrpas);
                //Obteniendo la cabecera del documento
                BDClient.Conectar();
                BDClient.Añadir_Parametro(0, "TX_ESTDOCELE", "S", "4"); //Pendiente y Por enviar
                BDClient.Añadir_Parametro(1, "NO_DOCELECAB", "S", oBEMaeemiele.no_tabfaccab); //Pendiente y Por enviar
                IDataReader dr_clidoccab = BDClient.Dame_Datos_DR("SPS_TABFACCAB_BY_ESTDOCELE", true, "P");
                ListBEDoccabcli oListBEDoccabcli = new ListBEDoccabcli();
                oListBEDoccabcli = ml_get_docelecab(dr_clidoccab);
                BDClient.Desconectar();
                //Se recorre los datos de cabecera
                foreach (BEDoccabcli item in oListBEDoccabcli)
                {
                    try
                    {
                        BaseDatos BDClienti = new BaseDatos(oBEMaeemiele.no_basnomsrv, BBDD, oBEMaeemiele.no_basnombas,
                            oBEMaeemiele.no_basusrbas, oBEMaeemiele.no_basusrpas);
                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " IDDOC: " + item.fa1_cserdoc + "-" + item.fa1_cnumdoc);
                        //Obteniendo el detalle dl documento
                        BDClienti.Conectar();
                        BDClienti.Añadir_Parametro(0, "CO_DETALTIDO", "S", item.fa1_ctipdoc);
                        BDClienti.Añadir_Parametro(1, "NU_DETSERSUN", "S", item.fa1_cserdoc);
                        BDClienti.Añadir_Parametro(2, "NU_DETNUMSUN", "S", item.fa1_cnumdoc);
                        BDClienti.Añadir_Parametro(3, "NO_DOCELEDET", "S", oBEMaeemiele.no_tabfacdet);
                        IDataReader dr_clidocdet = BDClienti.Dame_Datos_DR("SPS_TABFACDET_BY_TABFACCAB", true, "P");
                        ListBEDocdetcli oListBEDocdetcli = new ListBEDocdetcli();
                        oListBEDocdetcli = ml_get_doceledet(dr_clidocdet);
                        BDClienti.Desconectar();

                        //Generando XML cabecera y detalle
                        XmlDocument xm_emi = SerializeToXmlDocument(oBEMaeemiele);
                        XmlDocument xm_cab = SerializeToXmlDocument(item);
                        XmlDocument xm_det = SerializeToXmlDocument(oListBEDocdetcli);
                        //Insertando documento electronico
                        BaseDatos BDFaci = new BaseDatos("BASPRVNAM", "BASCADCON");
                        BDFaci.Conectar();
                        BDFaci.Añadir_Parametro(0, "XM_EMIDOCELE", "XML", xm_emi.OuterXml);
                        BDFaci.Añadir_Parametro(1, "XM_DOCELECAB", "XML", xm_cab.OuterXml);
                        BDFaci.Añadir_Parametro(2, "XM_DOCELEDET", "XML", xm_det.OuterXml);
                        BDFaci.Ejecutar_PA("SPI_TBL_DOCELECD", true);
                        BDFaci.Desconectar();
                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " CDDOC: " + item.fa1_cserdoc + "-" + item.fa1_cnumdoc);
                        //Actualizar el estado del documento en la base de datos
                        BDClient.Conectar();
                        BDClient.Añadir_Parametro(0, "CO_DOCALTIDO", "S", item.fa1_ctipdoc);
                        BDClient.Añadir_Parametro(1, "NU_DOCSERSUN", "S", item.fa1_cserdoc);
                        BDClient.Añadir_Parametro(2, "NU_DOCNUMSUN", "S", item.fa1_cnumdoc);
                        BDClient.Añadir_Parametro(3, "NO_DOCELECAB", "S", oBEMaeemiele.no_tabfaccab);
                        BDClient.Ejecutar_PA("SPU_TABFACCAB_MIG", true);
                        BDClient.Desconectar();

                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " UDDOC: " + item.fa1_cserdoc + "-" + item.fa1_cnumdoc);
                    }
                    catch (Exception ex)
                    {
                        ProcessException = true;
                        MessageException = ex.Message.ToString();
                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " MESSAGE: " + ex.Message.ToString());
                    }
                }

                //Se actualiza el registro identificador de la tarea que ha finalizado
                BDFact.Conectar();
                BDFact.Añadir_Parametro(0, "CO_TIPPROFAC", "S", "MIG"); //Migración
                BDFact.Añadir_Parametro(1, "CO_ESTPROINT", "S", (ProcessException) ? "EX" : "CO"); //Excepción - Correcto
                BDFact.Añadir_Parametro(2, "NID_EMIDOCELE", "I", oBEMaeemiele.nid_maeemiele.ToString());
                BDFact.Añadir_Parametro(3, "TX_DESCRIPCI", "S", MessageException);
                BDFact.Ejecutar_PA("SPU_TL_PROFACINT", true);
                BDFact.Desconectar();
            }
        }

        public static ListBEMaeemiele ml_get_maestro_emisores(IDataReader dr_emidocele)
        {
            ListBEMaeemiele oListBEMaeemiele = new ListBEMaeemiele();
            while (dr_emidocele.Read())
            {
                var oBEMaeemiele = new BEMaeemiele();
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NID_EMIDOCELE"))))
                    oBEMaeemiele.nid_maeemiele = dr_emidocele.GetInt32(dr_emidocele.GetOrdinal("NID_EMIDOCELE"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NU_EMINUMRUC"))))
                    oBEMaeemiele.nu_eminumruc = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NU_EMINUMRUC"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIRAZSOC"))))
                    oBEMaeemiele.no_emirazsoc = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIRAZSOC"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("CO_EMICODAGE"))))
                    oBEMaeemiele.co_emicodage = dr_emidocele.GetString(dr_emidocele.GetOrdinal("CO_EMICODAGE"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_ESTEMIELE"))))
                    oBEMaeemiele.no_estemiele = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_ESTEMIELE"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_CONEMIELE"))))
                    oBEMaeemiele.no_conemiele = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_CONEMIELE"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIUBIGEO"))))
                    oBEMaeemiele.no_emiubigeo = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIUBIGEO"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIDEPART"))))
                    oBEMaeemiele.no_emidepart = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIDEPART"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIPROVIN"))))
                    oBEMaeemiele.no_emiprovin = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIPROVIN"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIDISTRI"))))
                    oBEMaeemiele.no_emidistri = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIDISTRI"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_EMIDIRFIS"))))
                    oBEMaeemiele.no_emidirfis = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_EMIDIRFIS"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_BASTIPBAS"))))
                    oBEMaeemiele.no_bastipbas = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_BASTIPBAS"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_BASNOMSRV"))))
                    oBEMaeemiele.no_basnomsrv = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_BASNOMSRV"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_BASNOMBAS"))))
                    oBEMaeemiele.no_basnombas = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_BASNOMBAS"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_BASUSRBAS"))))
                    oBEMaeemiele.no_basusrbas = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_BASUSRBAS"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_BASUSRPAS"))))
                    oBEMaeemiele.no_basusrpas = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_BASUSRPAS"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_TABFACCAB"))))
                    oBEMaeemiele.no_tabfaccab = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_TABFACCAB"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_TABFACDET"))))
                    oBEMaeemiele.no_tabfacdet = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_TABFACDET"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_RUTCERDIG"))))
                    oBEMaeemiele.no_rutcerdig = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_RUTCERDIG"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_USUSOLSUN"))))
                    oBEMaeemiele.no_ususolsun = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_USUSOLSUN"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NO_PASSOLSUN"))))
                    oBEMaeemiele.no_passolsun = dr_emidocele.GetString(dr_emidocele.GetOrdinal("NO_PASSOLSUN"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("NID_CFGSEREMI"))))
                    oBEMaeemiele.nid_cfgseremi = dr_emidocele.GetInt32(dr_emidocele.GetOrdinal("NID_CFGSEREMI"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("FE_REGCREACI"))))
                    oBEMaeemiele.fe_regcreaci = dr_emidocele.GetDateTime(dr_emidocele.GetOrdinal("FE_REGCREACI"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("FE_REGMODIFI"))))
                    oBEMaeemiele.fe_regmodifi = dr_emidocele.GetDateTime(dr_emidocele.GetOrdinal("FE_REGMODIFI"));
                if ((!dr_emidocele.IsDBNull(dr_emidocele.GetOrdinal("FL_REGINACTI"))))
                    oBEMaeemiele.fl_reginacti = dr_emidocele.GetString(dr_emidocele.GetOrdinal("FL_REGINACTI"));
                oListBEMaeemiele.Add(oBEMaeemiele);
            }
            dr_emidocele.Close();

            return oListBEMaeemiele;
        }
        
        public static ListBEDoccabcli ml_get_docelecab(IDataReader dr_clidoccab)
        {
            ListBEDoccabcli oListBEDoccabcli = new ListBEDoccabcli();
            while (dr_clidoccab.Read())
            {
                BEDoccabcli oBEDoccabcli = new BEDoccabcli();
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODSUC"))))
                    oBEDoccabcli.fa1_ccodsuc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODSUC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTIPDOC"))))
                    oBEDoccabcli.fa1_ctipdoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTIPDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CSERDOC"))))
                    oBEDoccabcli.fa1_cserdoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CSERDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNUMDOC"))))
                    oBEDoccabcli.fa1_cnumdoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNUMDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECDOC"))))
                    oBEDoccabcli.fa1_dfecdoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECVEN"))))
                    oBEDoccabcli.fa1_dfecven = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODCLI"))))
                    oBEDoccabcli.fa1_ccodcli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODCLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNOMCLI"))))
                    oBEDoccabcli.fa1_cnomcli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNOMCLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CRUCCLI"))))
                    oBEDoccabcli.fa1_cruccli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CRUCCLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDIRCLI"))))
                    oBEDoccabcli.fa1_cdircli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDIRCLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFORVEN"))))
                    oBEDoccabcli.fa1_cforven = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFORVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODVEN"))))
                    oBEDoccabcli.fa1_ccodven = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODVE2"))))
                    oBEDoccabcli.fa1_ccodve2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODVE2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTGDORE"))))
                    oBEDoccabcli.fa1_ctgdore = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTGDORE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CSEDORE"))))
                    oBEDoccabcli.fa1_csedore = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CSEDORE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNUDORE"))))
                    oBEDoccabcli.fa1_cnudore = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNUDORE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTGDOR2"))))
                    oBEDoccabcli.fa1_ctgdor2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTGDOR2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNUDOR2"))))
                    oBEDoccabcli.fa1_cnudor2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNUDOR2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTIPOPE"))))
                    oBEDoccabcli.fa1_ctipope = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTIPOPE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODALM"))))
                    oBEDoccabcli.fa1_ccodalm = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODALM"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCENCOS"))))
                    oBEDoccabcli.fa1_ccencos = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCENCOS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CGLOSA1"))))
                    oBEDoccabcli.fa1_cglosa1 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CGLOSA1"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CGLOSA2"))))
                    oBEDoccabcli.fa1_cglosa2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CGLOSA2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODMON"))))
                    oBEDoccabcli.fa1_ccodmon = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODMON"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NTIPCAM"))))
                    oBEDoccabcli.fa1_ntipcam = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NTIPCAM"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NIMPORT"))))
                    oBEDoccabcli.fa1_nimport = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NIMPORT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORDE1"))))
                    oBEDoccabcli.fa1_nporde1 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORDE1"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORDE2"))))
                    oBEDoccabcli.fa1_nporde2 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORDE2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORDE3"))))
                    oBEDoccabcli.fa1_nporde3 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORDE3"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDIRECC"))))
                    oBEDoccabcli.fa1_cdirecc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDIRECC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDEBHAB"))))
                    oBEDoccabcli.fa1_cdebhab = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDEBHAB"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CSTOCK"))))
                    oBEDoccabcli.fa1_cstock = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CSTOCK"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CESTADO"))))
                    oBEDoccabcli.fa1_cestado = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CESTADO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CUSUCRE"))))
                    oBEDoccabcli.fa1_cusucre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CUSUCRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECCRE"))))
                    oBEDoccabcli.fa1_dfeccre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECCRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CUSUMOD"))))
                    oBEDoccabcli.fa1_cusumod = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CUSUMOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECMOD"))))
                    oBEDoccabcli.fa1_dfecmod = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECMOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDOCORI"))))
                    oBEDoccabcli.fa1_cdocori = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDOCORI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDOCATE"))))
                    oBEDoccabcli.fa1_cdocate = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDOCATE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODUBI"))))
                    oBEDoccabcli.fa1_ccodubi = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODUBI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTGPAIS"))))
                    oBEDoccabcli.fa1_ctgpais = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTGPAIS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CSUDORE"))))
                    oBEDoccabcli.fa1_csudore = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CSUDORE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CSUCATE"))))
                    oBEDoccabcli.fa1_csucate = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CSUCATE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNUMATE"))))
                    oBEDoccabcli.fa1_cnumate = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNUMATE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CHORCRE"))))
                    oBEDoccabcli.fa1_chorcre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CHORCRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CHORMOD"))))
                    oBEDoccabcli.fa1_chormod = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CHORMOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDIRFIS"))))
                    oBEDoccabcli.fa1_cdirfis = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDIRFIS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CORTSUC"))))
                    oBEDoccabcli.fa1_cortsuc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CORTSUC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CORTTAL"))))
                    oBEDoccabcli.fa1_corttal = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CORTTAL"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CORTNUM"))))
                    oBEDoccabcli.fa1_cortnum = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CORTNUM"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODCAJ"))))
                    oBEDoccabcli.fa1_ccodcaj = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODCAJ"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFLACAN"))))
                    oBEDoccabcli.fa1_cflacan = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFLACAN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTGDOR3"))))
                    oBEDoccabcli.fa1_ctgdor3 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTGDOR3"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNUDOR3"))))
                    oBEDoccabcli.fa1_cnudor3 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNUDOR3"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFLAMAS"))))
                    oBEDoccabcli.fa1_cflamas = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFLAMAS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NIMPPER"))))
                    oBEDoccabcli.fa1_nimpper = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NIMPPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORPER"))))
                    oBEDoccabcli.fa1_nporper = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFLACCT"))))
                    oBEDoccabcli.fa1_cflacct = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFLACCT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CORTVEH"))))
                    oBEDoccabcli.fa1_cortveh = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CORTVEH"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECPRO"))))
                    oBEDoccabcli.fa1_dfecpro = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECPRO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORIGV"))))
                    oBEDoccabcli.fa1_nporigv = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORIGV"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODTRA"))))
                    oBEDoccabcli.fa1_ccodtra = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODTRA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CNOMTRA"))))
                    oBEDoccabcli.fa1_cnomtra = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CNOMTRA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODVEH"))))
                    oBEDoccabcli.fa1_ccodveh = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODVEH"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODFER"))))
                    oBEDoccabcli.fa1_ccodfer = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODFER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECREF"))))
                    oBEDoccabcli.fa1_dfecref = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECREF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODDIR"))))
                    oBEDoccabcli.fa1_ccoddir = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODDIR"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CTIPMOV"))))
                    oBEDoccabcli.fa1_ctipmov = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CTIPMOV"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CGLOSA3"))))
                    oBEDoccabcli.fa1_cglosa3 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CGLOSA3"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDEPORI"))))
                    oBEDoccabcli.fa1_cdepori = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDEPORI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDEPDES"))))
                    oBEDoccabcli.fa1_cdepdes = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDEPDES"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODPER"))))
                    oBEDoccabcli.fa1_ccodper = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CKEYINT"))))
                    oBEDoccabcli.fa1_ckeyint = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CKEYINT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("EXISTE"))))
                    oBEDoccabcli.existe = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("EXISTE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("NUEVO"))))
                    oBEDoccabcli.nuevo = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("NUEVO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODSUR"))))
                    oBEDoccabcli.fa1_ccodsur = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODSUR"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPERCMN"))))
                    oBEDoccabcli.fa1_npercmn = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPERCMN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPERCUS"))))
                    oBEDoccabcli.fa1_npercus = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPERCUS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NNUMIMP"))))
                    oBEDoccabcli.fa1_nnumimp = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NNUMIMP"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFLADET"))))
                    oBEDoccabcli.fa1_cfladet = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFLADET"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CFLAANT"))))
                    oBEDoccabcli.fa1_cflaant = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CFLAANT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NIMPANT"))))
                    oBEDoccabcli.fa1_nimpant = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NIMPANT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NSALANT"))))
                    oBEDoccabcli.fa1_nsalant = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NSALANT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODREF"))))
                    oBEDoccabcli.fa1_ccodref = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODREF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDATADI"))))
                    oBEDoccabcli.fa1_cdatadi = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDATADI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODCOB"))))
                    oBEDoccabcli.fa1_ccodcob = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODCOB"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODSUB"))))
                    oBEDoccabcli.fa1_ccodsub = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODSUB"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCOMPRO"))))
                    oBEDoccabcli.fa1_ccompro = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCOMPRO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CANOCOM"))))
                    oBEDoccabcli.fa1_canocom = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CANOCOM"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECANU"))))
                    oBEDoccabcli.fa1_dfecanu = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_DFECANU"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CCODDET"))))
                    oBEDoccabcli.fa1_ccoddet = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CCODDET"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NPORTAS"))))
                    oBEDoccabcli.fa1_nportas = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NPORTAS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CMONANT"))))
                    oBEDoccabcli.fa1_cmonant = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CMONANT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_NSUMAPL"))))
                    oBEDoccabcli.fa1_nsumapl = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("FA1_NSUMAPL"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_COD_ESTADO_SUNAT"))))
                    oBEDoccabcli.fa1_cod_estado_sunat = dr_clidoccab.GetInt32(dr_clidoccab.GetOrdinal("FA1_COD_ESTADO_SUNAT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_MENSAJE_SUNAT"))))
                    oBEDoccabcli.fa1_mensaje_sunat = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_MENSAJE_SUNAT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_ESTADO_ENVIO"))))
                    oBEDoccabcli.fa1_estado_envio = dr_clidoccab.GetInt32(dr_clidoccab.GetOrdinal("FA1_ESTADO_ENVIO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_XML"))))
                    oBEDoccabcli.fa1_xml = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_XML"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_CDR"))))
                    oBEDoccabcli.fa1_cdr = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_CDR"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_PDF"))))
                    oBEDoccabcli.fa1_pdf = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("FA1_PDF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("FA1_DFECDOC9"))))
                    oBEDoccabcli.fa1_dfecdoc9 = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("FA1_DFECDOC9"));

                oListBEDoccabcli.Add(oBEDoccabcli);
            }
            dr_clidoccab.Close();
            return oListBEDoccabcli;
        }

        public static ListBEDocdetcli ml_get_doceledet(IDataReader dr_clidocdet)
        {
            ListBEDocdetcli oListBEDocdetcli = new ListBEDocdetcli();
            while (dr_clidocdet.Read())
            {
                BEDocdetcli oBEDocdetcli = new BEDocdetcli();
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODSUC"))))
                    oBEDocdetcli.fa2_ccodsuc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODSUC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CTIPDOC"))))
                    oBEDocdetcli.fa2_ctipdoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CTIPDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSERDOC"))))
                    oBEDocdetcli.fa2_cserdoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSERDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CNUMDOC"))))
                    oBEDocdetcli.fa2_cnumdoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CNUMDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CITEM"))))
                    oBEDocdetcli.fa2_citem = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CITEM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODART"))))
                    oBEDocdetcli.fa2_ccodart = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODART"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CNOMART"))))
                    oBEDocdetcli.fa2_cnomart = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CNOMART"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CUNIART"))))
                    oBEDocdetcli.fa2_cuniart = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CUNIART"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANTID"))))
                    oBEDocdetcli.fa2_ncantid = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANTID"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPRECIO"))))
                    oBEDocdetcli.fa2_nprecio = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPRECIO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPREUNI"))))
                    oBEDocdetcli.fa2_npreuni = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPREUNI"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPRUNMN"))))
                    oBEDocdetcli.fa2_nprunmn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPRUNMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPRUNUS"))))
                    oBEDocdetcli.fa2_nprunus = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPRUNUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPRSIGV"))))
                    oBEDocdetcli.fa2_nprsigv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPRSIGV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODALM"))))
                    oBEDocdetcli.fa2_ccodalm = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODALM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODMON"))))
                    oBEDocdetcli.fa2_ccodmon = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODMON"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NTIPCAM"))))
                    oBEDocdetcli.fa2_ntipcam = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NTIPCAM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPORDE1"))))
                    oBEDocdetcli.fa2_nporde1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPORDE1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPDE1"))))
                    oBEDocdetcli.fa2_nimpde1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPDE1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPORDE2"))))
                    oBEDocdetcli.fa2_nporde2 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPORDE2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPDE2"))))
                    oBEDocdetcli.fa2_nimpde2 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPDE2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPORDE3"))))
                    oBEDocdetcli.fa2_nporde3 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPORDE3"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPDE3"))))
                    oBEDocdetcli.fa2_nimpde3 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPDE3"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NTOTDES"))))
                    oBEDocdetcli.fa2_ntotdes = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NTOTDES"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPORIGV"))))
                    oBEDocdetcli.fa2_nporigv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPORIGV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPIGV"))))
                    oBEDocdetcli.fa2_nimpigv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPIGV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPORT"))))
                    oBEDocdetcli.fa2_nimport = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPORT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPOMN"))))
                    oBEDocdetcli.fa2_nimpomn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPOMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPOUS"))))
                    oBEDocdetcli.fa2_nimpous = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPOUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIIGVMN"))))
                    oBEDocdetcli.fa2_niigvmn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIIGVMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIIGVUS"))))
                    oBEDocdetcli.fa2_niigvus = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIIGVUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSTOCK"))))
                    oBEDocdetcli.fa2_cstock = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSTOCK"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CESTADO"))))
                    oBEDocdetcli.fa2_cestado = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CESTADO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CUSUCRE"))))
                    oBEDocdetcli.fa2_cusucre = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CUSUCRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_DFECCRE"))))
                    oBEDocdetcli.fa2_dfeccre = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_DFECCRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CUSUMOD"))))
                    oBEDocdetcli.fa2_cusumod = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CUSUMOD"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_DFECMOD"))))
                    oBEDocdetcli.fa2_dfecmod = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_DFECMOD"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCOSTMN"))))
                    oBEDocdetcli.fa2_ncostmn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCOSTMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCOSTUS"))))
                    oBEDocdetcli.fa2_ncostus = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCOSTUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANATE"))))
                    oBEDocdetcli.fa2_ncanate = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANATE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CDOCATE"))))
                    oBEDocdetcli.fa2_cdocate = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CDOCATE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSUCATE"))))
                    oBEDocdetcli.fa2_csucate = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSUCATE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CNUMATE"))))
                    oBEDocdetcli.fa2_cnumate = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CNUMATE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CFLAKIT"))))
                    oBEDocdetcli.fa2_cflakit = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CFLAKIT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODCAJ"))))
                    oBEDocdetcli.fa2_ccodcaj = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODCAJ"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPORPER"))))
                    oBEDocdetcli.fa2_nporper = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPORPER"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPPER"))))
                    oBEDocdetcli.fa2_nimpper = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPPER"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPERCMN"))))
                    oBEDocdetcli.fa2_npercmn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPERCMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPERCUS"))))
                    oBEDocdetcli.fa2_npercus = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPERCUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODAR2"))))
                    oBEDocdetcli.fa2_ccodar2 = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODAR2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CALMREF"))))
                    oBEDocdetcli.fa2_calmref = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CALMREF"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CFLAATE"))))
                    oBEDocdetcli.fa2_cflaate = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CFLAATE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPESART"))))
                    oBEDocdetcli.fa2_npesart = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPESART"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("EXISTE"))))
                    oBEDocdetcli.existe = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("EXISTE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("NUEVO"))))
                    oBEDocdetcli.nuevo = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("NUEVO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANBUL"))))
                    oBEDocdetcli.fa2_ncanbul = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANBUL"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPESBUL"))))
                    oBEDocdetcli.fa2_npesbul = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPESBUL"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANTI2"))))
                    oBEDocdetcli.fa2_ncanti2 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANTI2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANTI3"))))
                    oBEDocdetcli.fa2_ncanti3 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANTI3"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCANOBS"))))
                    oBEDocdetcli.fa2_ncanobs = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCANOBS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPREOBS"))))
                    oBEDocdetcli.fa2_npreobs = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPREOBS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NIMPOBS"))))
                    oBEDocdetcli.fa2_nimpobs = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NIMPOBS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NCAXPRE"))))
                    oBEDocdetcli.fa2_ncaxpre = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NCAXPRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_NPRXPRE"))))
                    oBEDocdetcli.fa2_nprxpre = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("FA2_NPRXPRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSUCANT"))))
                    oBEDocdetcli.fa2_csucant = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSUCANT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CDOCANT"))))
                    oBEDocdetcli.fa2_cdocant = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CDOCANT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSERANT"))))
                    oBEDocdetcli.fa2_cserant = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSERANT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CNUMANT"))))
                    oBEDocdetcli.fa2_cnumant = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CNUMANT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CDATADI"))))
                    oBEDocdetcli.fa2_cdatadi = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CDATADI"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CITEFAC"))))
                    oBEDocdetcli.fa2_citefac = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CITEFAC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CCODACT"))))
                    oBEDocdetcli.fa2_ccodact = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CCODACT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("FA2_CSITACT"))))
                    oBEDocdetcli.fa2_csitact = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("FA2_CSITACT"));
                oListBEDocdetcli.Add(oBEDocdetcli);
            }
            dr_clidocdet.Close();

            return oListBEDocdetcli;
        }

        public static XmlDocument SerializeToXmlDocument(Object input)
        {
            XmlSerializer Serializer = new XmlSerializer(input.GetType());

            XmlDocument xmlDocument = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                Serializer.Serialize(memStm, input);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xmlDocument = new XmlDocument();
                    xmlDocument.Load(xtr);
                }
            }

            return xmlDocument;
        }
    }
}