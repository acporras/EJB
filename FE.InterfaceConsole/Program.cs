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

            Console.ReadLine();
        }

        public static void ti_intejesrv_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " IDDOC: " + item.f5_cnumser + "-" + item.f5_cnumdoc);
                        //Obteniendo el detalle dl documento
                        BDClienti.Conectar();
                        BDClienti.Añadir_Parametro(0, "CO_DETALTIDO", "S", item.f5_ctd);
                        BDClienti.Añadir_Parametro(1, "NU_DETSERSUN", "S", item.f5_cnumser);
                        BDClienti.Añadir_Parametro(2, "NU_DETNUMSUN", "S", item.f5_cnumdoc);
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
                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " CDDOC: " + item.f5_cnumser + "-" + item.f5_cnumdoc);
                        //Actualizar el estado del documento en la base de datos
                        BDClient.Conectar();
                        BDClient.Añadir_Parametro(0, "CO_DOCALTIDO", "S", item.f5_ctd);
                        BDClient.Añadir_Parametro(1, "NU_DOCSERSUN", "S", item.f5_cnumser);
                        BDClient.Añadir_Parametro(2, "NU_DOCNUMSUN", "S", item.f5_cnumdoc);
                        BDClient.Añadir_Parametro(3, "NO_DOCELECAB", "S", oBEMaeemiele.no_tabfaccab);
                        BDClient.Ejecutar_PA("SPU_TABFACCAB_MIG", true);
                        BDClient.Desconectar();

                        Console.WriteLine("RUC:" + oBEMaeemiele.nu_eminumruc + " UDDOC: " + item.f5_cnumser + "-" + item.f5_cnumdoc);
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
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODAGE"))))
                    oBEDoccabcli.f5_ccodage = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODAGE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTD"))))
                    oBEDoccabcli.f5_ctd = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNUMSER"))))
                    oBEDoccabcli.f5_cnumser = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNUMSER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNUMDOC"))))
                    oBEDoccabcli.f5_cnumdoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNUMDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNROPED"))))
                    oBEDoccabcli.f5_cnroped = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNROPED"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECDOC"))))
                    oBEDoccabcli.f5_dfecdoc = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECVEN"))))
                    oBEDoccabcli.f5_dfecven = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CDH"))))
                    oBEDoccabcli.f5_cdh = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CDH"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CVENDE"))))
                    oBEDoccabcli.f5_cvende = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CVENDE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNROCAJ"))))
                    oBEDoccabcli.f5_cnrocaj = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNROCAJ"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODCLI"))))
                    oBEDoccabcli.f5_ccodcli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODCLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNOMBRE"))))
                    oBEDoccabcli.f5_cnombre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNOMBRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CDIRECC"))))
                    oBEDoccabcli.f5_cdirecc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CDIRECC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRUC"))))
                    oBEDoccabcli.f5_cruc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRUC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CALMA"))))
                    oBEDoccabcli.f5_calma = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CALMA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CFORVEN"))))
                    oBEDoccabcli.f5_cforven = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CFORVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODMON"))))
                    oBEDoccabcli.f5_ccodmon = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODMON"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NTIPCAM"))))
                    oBEDoccabcli.f5_ntipcam = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NTIPCAM"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NIMPORT"))))
                    oBEDoccabcli.f5_nimport = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NIMPORT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NIMPIGV"))))
                    oBEDoccabcli.f5_nimpigv = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NIMPIGV"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NSALDO"))))
                    oBEDoccabcli.f5_nsaldo = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NSALDO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NDESCTO"))))
                    oBEDoccabcli.f5_ndescto = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NDESCTO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNUMORD"))))
                    oBEDoccabcli.f5_cnumord = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNUMORD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRFTD"))))
                    oBEDoccabcli.f5_crftd = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRFTD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRFNSER"))))
                    oBEDoccabcli.f5_crfnser = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRFNSER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRFNDOC"))))
                    oBEDoccabcli.f5_crfndoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRFNDOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CGLOSA"))))
                    oBEDoccabcli.f5_cglosa = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CGLOSA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CESTADO"))))
                    oBEDoccabcli.f5_cestado = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CESTADO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CFACGUI"))))
                    oBEDoccabcli.f5_cfacgui = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CFACGUI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODTRA"))))
                    oBEDoccabcli.f5_ccodtra = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODTRA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCENCOS"))))
                    oBEDoccabcli.f5_ccencos = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCENCOS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODMAQ"))))
                    oBEDoccabcli.f5_ccodmaq = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODMAQ"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CDESTIN"))))
                    oBEDoccabcli.f5_cdestin = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CDESTIN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTF"))))
                    oBEDoccabcli.f5_ctf = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTIPANE"))))
                    oBEDoccabcli.f5_ctipane = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTIPANE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CANEREF"))))
                    oBEDoccabcli.f5_caneref = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CANEREF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NPORDE1"))))
                    oBEDoccabcli.f5_nporde1 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NPORDE1"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NPORDE2"))))
                    oBEDoccabcli.f5_nporde2 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NPORDE2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NFLETE"))))
                    oBEDoccabcli.f5_nflete = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NFLETE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NEMBAL"))))
                    oBEDoccabcli.f5_nembal = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NEMBAL"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NTASA"))))
                    oBEDoccabcli.f5_ntasa = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NTASA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CUSUOPE"))))
                    oBEDoccabcli.f5_cusuope = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CUSUOPE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CUSUSEC"))))
                    oBEDoccabcli.f5_cususec = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CUSUSEC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODCAD"))))
                    oBEDoccabcli.f5_ccodcad = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODCAD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODINT"))))
                    oBEDoccabcli.f5_ccodint = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODINT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODAUT"))))
                    oBEDoccabcli.f5_ccodaut = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODAUT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CREPA"))))
                    oBEDoccabcli.f5_crepa = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CREPA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CUSUCRE"))))
                    oBEDoccabcli.f5_cusucre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CUSUCRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECCRE"))))
                    oBEDoccabcli.f5_dfeccre = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECCRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CUSUMOD"))))
                    oBEDoccabcli.f5_cusumod = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CUSUMOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECMOD"))))
                    oBEDoccabcli.f5_dfecmod = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECMOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTNC"))))
                    oBEDoccabcli.f5_ctnc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTNC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CLINEA"))))
                    oBEDoccabcli.f5_clinea = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CLINEA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CIMPRE"))))
                    oBEDoccabcli.f5_cimpre = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CIMPRE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCJENC"))))
                    oBEDoccabcli.f5_ccjenc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCJENC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CVENDE2"))))
                    oBEDoccabcli.f5_cvende2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CVENDE2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NPORVEN"))))
                    oBEDoccabcli.f5_nporven = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NPORVEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NPORVE2"))))
                    oBEDoccabcli.f5_nporve2 = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NPORVE2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CPERIOD"))))
                    oBEDoccabcli.f5_cperiod = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CPERIOD"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRFTD2"))))
                    oBEDoccabcli.f5_crftd2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRFTD2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CRFNDO2"))))
                    oBEDoccabcli.f5_crfndo2 = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CRFNDO2"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECANU"))))
                    oBEDoccabcli.f5_dfecanu = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECANU"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTIPDNC"))))
                    oBEDoccabcli.f5_ctipdnc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTIPDNC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODVEH"))))
                    oBEDoccabcli.f5_ccodveh = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODVEH"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODFER"))))
                    oBEDoccabcli.f5_ccodfer = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODFER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTIPDEV"))))
                    oBEDoccabcli.f5_ctipdev = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTIPDEV"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CSUBDIA"))))
                    oBEDoccabcli.f5_csubdia = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CSUBDIA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCOMPRO"))))
                    oBEDoccabcli.f5_ccompro = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCOMPRO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECENT"))))
                    oBEDoccabcli.f5_dfecent = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECENT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNROPLA"))))
                    oBEDoccabcli.f5_cnropla = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNROPLA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CAGEOT"))))
                    oBEDoccabcli.f5_cageot = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CAGEOT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CORDTRA"))))
                    oBEDoccabcli.f5_cordtra = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CORDTRA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCHASIS"))))
                    oBEDoccabcli.f5_cchasis = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCHASIS"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CHRADOC"))))
                    oBEDoccabcli.f5_chradoc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CHRADOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCOSUPV"))))
                    oBEDoccabcli.f5_ccosupv = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCOSUPV"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CFLGPLA"))))
                    oBEDoccabcli.f5_cflgpla = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CFLGPLA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTORIGEN"))))
                    oBEDoccabcli.f5_ctorigen = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTORIGEN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTDESTIN"))))
                    oBEDoccabcli.f5_ctdestin = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTDESTIN"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CMONPER"))))
                    oBEDoccabcli.f5_cmonper = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CMONPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NIMPPER"))))
                    oBEDoccabcli.f5_nimpper = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NIMPPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CGUIFAC"))))
                    oBEDoccabcli.f5_cguifac = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CGUIFAC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_AVANEXO"))))
                    oBEDoccabcli.f5_avanexo = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_AVANEXO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_ACODANE"))))
                    oBEDoccabcli.f5_acodane = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_ACODANE"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCONTRAT"))))
                    oBEDoccabcli.f5_ccontrat = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCONTRAT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_COBRA"))))
                    oBEDoccabcli.f5_cobra = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_COBRA"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CPERIOC"))))
                    oBEDoccabcli.f5_cperioc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CPERIOC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCERTIF"))))
                    oBEDoccabcli.f5_ccertif = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCERTIF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CCODTAL"))))
                    oBEDoccabcli.f5_ccodtal = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CCODTAL"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CTIPFOR"))))
                    oBEDoccabcli.f5_ctipfor = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CTIPFOR"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NPORPER"))))
                    oBEDoccabcli.f5_nporper = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NPORPER"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_DFECREF"))))
                    oBEDoccabcli.f5_dfecref = dr_clidoccab.GetDateTime(dr_clidoccab.GetOrdinal("F5_DFECREF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CMORFTC"))))
                    oBEDoccabcli.f5_cmorftc = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CMORFTC"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_NTCREF"))))
                    oBEDoccabcli.f5_ntcref = dr_clidoccab.GetDecimal(dr_clidoccab.GetOrdinal("F5_NTCREF"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CNCAPLI"))))
                    oBEDoccabcli.f5_cncapli = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CNCAPLI"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_COD_ESTADO_SUNAT"))))
                    oBEDoccabcli.f5_cod_estado_sunat = dr_clidoccab.GetInt32(dr_clidoccab.GetOrdinal("F5_COD_ESTADO_SUNAT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_MENSAJE_SUNAT"))))
                    oBEDoccabcli.f5_mensaje_sunat = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_MENSAJE_SUNAT"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_ESTADO_ENVIO"))))
                    oBEDoccabcli.f5_estado_envio = dr_clidoccab.GetInt32(dr_clidoccab.GetOrdinal("F5_ESTADO_ENVIO"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_XML"))))
                    oBEDoccabcli.f5_xml = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_XML"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_CDR"))))
                    oBEDoccabcli.f5_cdr = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_CDR"));
                if ((!dr_clidoccab.IsDBNull(dr_clidoccab.GetOrdinal("F5_PDF"))))
                    oBEDoccabcli.f5_pdf = dr_clidoccab.GetString(dr_clidoccab.GetOrdinal("F5_PDF"));

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
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODAGE"))))
                    oBEDocdetcli.f6_ccodage = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODAGE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTD"))))
                    oBEDocdetcli.f6_ctd = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTD"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNUMSER"))))
                    oBEDocdetcli.f6_cnumser = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNUMSER"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNUMDOC"))))
                    oBEDocdetcli.f6_cnumdoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNUMDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CITEM"))))
                    oBEDocdetcli.f6_citem = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CITEM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODIGO"))))
                    oBEDocdetcli.f6_ccodigo = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODIGO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CDESCRI"))))
                    oBEDocdetcli.f6_cdescri = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CDESCRI"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTR"))))
                    oBEDocdetcli.f6_ctr = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTR"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NCANTID"))))
                    oBEDocdetcli.f6_ncantid = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NCANTID"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CUNIDAD"))))
                    oBEDocdetcli.f6_cunidad = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CUNIDAD"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CSERIE"))))
                    oBEDocdetcli.f6_cserie = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CSERIE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NCANREF"))))
                    oBEDocdetcli.f6_ncanref = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NCANREF"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NUNXENV"))))
                    oBEDocdetcli.f6_nunxenv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NUNXENV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NNUMENV"))))
                    oBEDocdetcli.f6_nnumenv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NNUMENV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NSALDAR"))))
                    oBEDocdetcli.f6_nsaldar = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NSALDAR"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPRECIO"))))
                    oBEDocdetcli.f6_nprecio = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPRECIO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPRECI1"))))
                    oBEDocdetcli.f6_npreci1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPRECI1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPREIMP"))))
                    oBEDocdetcli.f6_npreimp = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPREIMP"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPREIM1"))))
                    oBEDocdetcli.f6_npreim1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPREIM1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPRSIGV"))))
                    oBEDocdetcli.f6_nprsigv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPRSIGV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NDESCTO"))))
                    oBEDocdetcli.f6_ndescto = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NDESCTO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NDESDOC"))))
                    oBEDocdetcli.f6_ndesdoc = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NDESDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NVALDIS"))))
                    oBEDocdetcli.f6_nvaldis = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NVALDIS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIGVPOR"))))
                    oBEDocdetcli.f6_nigvpor = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIGVPOR"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIGV"))))
                    oBEDocdetcli.f6_nigv = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIGV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMPUS"))))
                    oBEDocdetcli.f6_nimpus = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMPUS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMPMN"))))
                    oBEDocdetcli.f6_nimpmn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMPMN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTIPITM"))))
                    oBEDocdetcli.f6_ctipitm = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTIPITM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDE1"))))
                    oBEDocdetcli.f6_nporde1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDE1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMP01"))))
                    oBEDocdetcli.f6_nimp01 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMP01"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDE2"))))
                    oBEDocdetcli.f6_nporde2 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDE2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMP02"))))
                    oBEDocdetcli.f6_nimp02 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMP02"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDE3"))))
                    oBEDocdetcli.f6_nporde3 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDE3"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMP03"))))
                    oBEDocdetcli.f6_nimp03 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMP03"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDE4"))))
                    oBEDocdetcli.f6_nporde4 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDE4"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMP04"))))
                    oBEDocdetcli.f6_nimp04 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMP04"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDE5"))))
                    oBEDocdetcli.f6_nporde5 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDE5"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMP05"))))
                    oBEDocdetcli.f6_nimp05 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMP05"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORDES"))))
                    oBEDocdetcli.f6_npordes = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORDES"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CESTADO"))))
                    oBEDocdetcli.f6_cestado = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CESTADO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CVENDE"))))
                    oBEDocdetcli.f6_cvende = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CVENDE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CALMA"))))
                    oBEDocdetcli.f6_calma = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CALMA"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNROCAJ"))))
                    oBEDocdetcli.f6_cnrocaj = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNROCAJ"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CSTOCK"))))
                    oBEDocdetcli.f6_cstock = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CSTOCK"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_DFECDOC"))))
                    oBEDocdetcli.f6_dfecdoc = dr_clidocdet.GetDateTime(dr_clidocdet.GetOrdinal("F6_DFECDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODLIN"))))
                    oBEDocdetcli.f6_ccodlin = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODLIN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNROTAB"))))
                    oBEDocdetcli.f6_cnrotab = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNROTAB"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNUMPAQ"))))
                    oBEDocdetcli.f6_cnumpaq = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNUMPAQ"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNDSCF"))))
                    oBEDocdetcli.f6_cndscf = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNDSCF"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNDSCL"))))
                    oBEDocdetcli.f6_cndscl = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNDSCL"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNDSCA"))))
                    oBEDocdetcli.f6_cndsca = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNDSCA"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNDSCB"))))
                    oBEDocdetcli.f6_cndscb = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNDSCB"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNFLAT"))))
                    oBEDocdetcli.f6_cnflat = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNFLAT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORCOM"))))
                    oBEDocdetcli.f6_nporcom = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORCOM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMPCOM"))))
                    oBEDocdetcli.f6_nimpcom = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMPCOM"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CUSUCRE"))))
                    oBEDocdetcli.f6_cusucre = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CUSUCRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_DFECCRE"))))
                    oBEDocdetcli.f6_dfeccre = dr_clidocdet.GetDateTime(dr_clidocdet.GetOrdinal("F6_DFECCRE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPRESIS"))))
                    oBEDocdetcli.f6_npresis = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPRESIS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CVENDE2"))))
                    oBEDocdetcli.f6_cvende2 = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CVENDE2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CITEMP"))))
                    oBEDocdetcli.f6_citemp = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CITEMP"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NTEMPER"))))
                    oBEDocdetcli.f6_ntemper = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NTEMPER"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NISCPOR"))))
                    oBEDocdetcli.f6_niscpor = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NISCPOR"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NISC"))))
                    oBEDocdetcli.f6_nisc = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NISC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NCANDEV"))))
                    oBEDocdetcli.f6_ncandev = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NCANDEV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCENCOS"))))
                    oBEDocdetcli.f6_ccencos = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCENCOS"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CANEXO"))))
                    oBEDocdetcli.f6_canexo = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CANEXO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CANEREF"))))
                    oBEDocdetcli.f6_caneref = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CANEREF"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NCANDEC"))))
                    oBEDocdetcli.f6_ncandec = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NCANDEC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTIPPLA"))))
                    oBEDocdetcli.f6_ctippla = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTIPPLA"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODPLA"))))
                    oBEDocdetcli.f6_ccodpla = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODPLA"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTIPCAT"))))
                    oBEDocdetcli.f6_ctipcat = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTIPCAT"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNROPLA"))))
                    oBEDocdetcli.f6_cnropla = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNROPLA"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCOSUPV"))))
                    oBEDocdetcli.f6_ccosupv = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCOSUPV"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_AVANEXO"))))
                    oBEDocdetcli.f6_avanexo = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_AVANEXO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_ACODANE"))))
                    oBEDocdetcli.f6_acodane = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_ACODANE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NRETGAR"))))
                    oBEDocdetcli.f6_nretgar = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NRETGAR"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CTIPDOC"))))
                    oBEDocdetcli.f6_ctipdoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CTIPDOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CNRODOC"))))
                    oBEDocdetcli.f6_cnrodoc = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CNRODOC"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NTASRCN"))))
                    oBEDocdetcli.f6_ntasrcn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NTASRCN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NIMPRCN"))))
                    oBEDocdetcli.f6_nimprcn = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NIMPRCN"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CVANEXO"))))
                    oBEDocdetcli.f6_cvanexo = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CVANEXO"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODANE"))))
                    oBEDocdetcli.f6_ccodane = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODANE"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CCODAN2"))))
                    oBEDocdetcli.f6_ccodan2 = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CCODAN2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CVANEX2"))))
                    oBEDocdetcli.f6_cvanex2 = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CVANEX2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORCM1"))))
                    oBEDocdetcli.f6_nporcm1 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORCM1"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NPORCM2"))))
                    oBEDocdetcli.f6_nporcm2 = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NPORCM2"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_CISCTIP"))))
                    oBEDocdetcli.f6_cisctip = dr_clidocdet.GetString(dr_clidocdet.GetOrdinal("F6_CISCTIP"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NISCMON"))))
                    oBEDocdetcli.f6_niscmon = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NISCMON"));
                if ((!dr_clidocdet.IsDBNull(dr_clidocdet.GetOrdinal("F6_NISCPRE"))))
                    oBEDocdetcli.f6_niscpre = dr_clidocdet.GetDecimal(dr_clidocdet.GetOrdinal("F6_NISCPRE"));
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