
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
//using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FE.InterfaceService
{


    public class BaseDatos
    {
        public enum BBDD
        {
            SQL = 1,
            ODBC = 2,
            OLEDB = 3,
            MySQL = 4
        }

        private IDbConnection Conexion = null;
        private IDbCommand Commando = null;
        private IDbTransaction Transaccion = null;
        private string sCadenaConexion;
        private DbProviderFactory _Factory = null;
        private BBDD tipoBBDD;
        private List<IDbDataParameter> pParametros = new List<IDbDataParameter>();


        public BaseDatos(string sServidor,
                       BaseDatos.BBDD tipoConexion,
                       string sBaseDatos,
                       string sUsuario,
                       string sPass)
        {
            try
            {
                string proveedor = "";
                //InicializarVariables()


                this.tipoBBDD = tipoConexion;

                switch (this.tipoBBDD)
                {
                    case BBDD.SQL:
                        proveedor = "System.Data.SqlClient";
                        break;
                    case BBDD.ODBC:
                        proveedor = "System.Data.Odbc";
                        break;
                    case BBDD.OLEDB:
                        proveedor = "System.Data.OleDb";
                        break;
                    case BBDD.MySQL:
                        proveedor = "MySql.Data.MySqlClient";
                        break;

                }
                this.sCadenaConexion = "data source = " + sServidor + "; initial catalog=" + sBaseDatos + "; user id = " + sUsuario + "; password = " + sPass;
                this._Factory = DbProviderFactories.GetFactory(proveedor);
                pParametros.Clear();
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.New(Parametros) ", ex);
            }
        }

        public BaseDatos(string ProveedorBBDD, string sKeyConfig)
        {
            try
            {
                string proveedor = ConfigurationManager.AppSettings.Get(ProveedorBBDD);

                switch (proveedor.Trim())
                {
                    case "System.Data.SqlClient":
                        tipoBBDD = BBDD.SQL;
                        break;
                    case "System.Data.Odbc":
                        tipoBBDD = BBDD.ODBC;
                        break;
                    case "System.Data.OleDb":
                        tipoBBDD = BBDD.OLEDB;
                        break;
                    case "MySql.Data.MySqlClient":
                        tipoBBDD = BBDD.MySQL;
                        break;
                }

                this.sCadenaConexion = ConfigurationManager.AppSettings.Get(sKeyConfig);
                this._Factory = DbProviderFactories.GetFactory(proveedor);
                pParametros.Clear();
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.New(sKeyConfig) ", ex);
            }
        }

        public BaseDatos(BaseDatos.BBDD tipoConexion,
                       string sCadenaConexion)
        {
            try
            {
                string proveedor = "";

                tipoBBDD = tipoConexion;
                switch (tipoBBDD)
                {
                    case BBDD.SQL:
                        proveedor = "System.Data.SqlClient";
                        break;
                    case BBDD.ODBC:
                        proveedor = "System.Data.Odbc";
                        break;
                    case BBDD.OLEDB:
                        proveedor = "System.Data.OleDb";
                        break;
                    case BBDD.MySQL:
                        proveedor = "MySql.Data.MySqlClient";
                        break;
                }

                this.sCadenaConexion = sCadenaConexion;
                this._Factory = DbProviderFactories.GetFactory(proveedor);
                pParametros.Clear();
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.New(tipoConexion,CadenaConexion) ", ex);
            }
        }

        public BaseDatos()
        {
            // TODO: Complete Member initialization 
        }

        public void Conectar()
        {
            try
            {
                if (this.Conexion != null)
                {
                    if (this.Conexion.State.Equals(ConnectionState.Closed))
                    {
                        throw new BaseDatosException("La conexion ya se encuentra abierta");

                    }
                }

                if (this.Conexion == null)
                {
                    switch (tipoBBDD)
                    {
                        case BBDD.SQL:
                            this.Conexion = new SqlConnection();
                            break;
                        case BBDD.ODBC:
                            this.Conexion = new OdbcConnection();
                            break;
                        case BBDD.OLEDB:
                            this.Conexion = new OleDbConnection();
                            break;
                        // case BBDD.MySQL : this.Conexion = new MySqlConnection();
                    }

                    this.Conexion = _Factory.CreateConnection();
                    this.Conexion.ConnectionString = this.sCadenaConexion;
                }
                this.Conexion.Open();
                if (this.Conexion.State != ConnectionState.Open)
                {
                    //MessageBox.Show("ERROR AL CONECTAR CON LA BASE DE DATOS " + this.Conexion.Database);
                    throw new BaseDatosException("ERROR AL CONECTAR CON LA BASE DE DATOS " + this.Conexion.Database, null);
                }
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("ERROR :" + ex.Message + " - Cadena conexion : " + this.sCadenaConexion + " BASEDATOS.Conectar ", ex);
            }

        }

        public void Desconectar()
        {
            try
            {
                if (this.Conexion.State.Equals(ConnectionState.Open))
                {
                    this.Conexion.Close();
                    this.Conexion = null;
                }
            }
            catch (DataException ex)
            {
                this.Conexion = null;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.DESCONECTAR ", ex);
            }
            catch (InvalidOperationException ex)
            {
                this.Conexion = null;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.DESCONECTAR ", ex);
            }
        }

        public void ComenzarTransaccion()
        {
            if (this.Transaccion == null)
            {
                this.Transaccion = this.Conexion.BeginTransaction();
            }
        }

        public void CancelarTransaccion()
        {
            if (this.Transaccion != null)
            {
                this.Transaccion.Rollback();
            }
        }

        public void ConfirmarTransaccion()
        {
            if (this.Transaccion != null)
            {
                this.Transaccion.Commit();
            }
        }

        public bool EjecutarConsulta(string CadenaSql)
        {
            try
            {
                this.CrearComando(CadenaSql, "S");
                this.EjecutarComando();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.EjecutarConsulta ", ex);
            }
        }

        
        private void CrearComando(string CadenaSql,
                             string TipoConsulta)
        {
            try
            {
                switch (tipoBBDD)
                {
                    case BBDD.SQL:
                        this.Commando = new SqlCommand();
                        break;
                    case BBDD.ODBC:
                        this.Commando = new OdbcCommand();
                        break;
                    case BBDD.OLEDB:
                        this.Commando = new OleDbCommand();
                        break;
                    //case BBDD.MySQL : this.Commando = new MySqlCommand();
                }

                this.Commando = _Factory.CreateCommand();
                this.Commando.Connection = this.Conexion;
                this.Commando.CommandTimeout = 99999999;
                switch (TipoConsulta)
                {
                    case "P"://Procedimiento almacenado
                        this.Commando.CommandType = CommandType.StoredProcedure;
                        break;

                    case "T":
                        this.Commando.CommandType = CommandType.TableDirect;
                        break;

                    default://Sentencia SQL
                        this.Commando.CommandType = CommandType.Text;
                        break;
                }

                this.Commando.CommandText = CadenaSql;

                if (this.Transaccion != null)
                {
                    this.Commando.Transaction = this.Transaccion;
                }
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.CrearComando ", ex);
            }

        }

        private void EjecutarComando()
        {
            try{
                this.Commando.ExecuteNonQuery();
            }
            catch (Exception ex){
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.EjecutarComando ", ex);
            }

        }

        private IDataAdapter EjecutarConsultaDataAdapter()
        {
            try
            {
                switch (tipoBBDD)
                {
                    case BBDD.SQL: 
                        return new SqlDataAdapter((SqlCommand)this.Commando);
                    case BBDD.ODBC : 
                        return new OdbcDataAdapter((OdbcCommand)this.Commando);
                    case BBDD.OLEDB : 
                        return new OleDbDataAdapter((OleDbCommand)this.Commando);
                        //case BBDD.MySQL : return new MySqlDataAdapter((MySqlCommand)this.Commando); break;
                    default: return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.EjecutarConsultaDataAdapter ", ex);
            }

        }

        public bool Dame_Datos_DT(string CadenaSQL,
                                  bool HayParametros,
                                  DataTable Tabla,
                                  string TipoConsulta)
        {
            IDataAdapter arsDatos;
            DataSet datos = new DataSet();
            int i = 0;
            try
            {

                switch (tipoBBDD)
                {
                    case BBDD.SQL: arsDatos = new SqlDataAdapter(); break;
                    case BBDD.ODBC: arsDatos = new OdbcDataAdapter(); break;
                    case BBDD.OLEDB: arsDatos = new OleDbDataAdapter(); break;
                        //case BBDD.MySQL : arsDatos = new MySqlDataAdapter();
                }


                CrearComando(CadenaSQL, TipoConsulta);

                if (HayParametros)
                {
                    while (i <= (pParametros.Count() - 1))
                    {
                        this.Commando.Parameters.Add(pParametros[i]);
                        i = i + 1;
                    }
                }

                arsDatos = this.EjecutarConsultaDataAdapter();
                arsDatos.Fill(datos);
                Tabla = datos.Tables[0];

                if (Tabla.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.DameDatosDT ", ex);
            }
        }

        public IDbDataAdapter Dame_Datos_DA(string CadenaSQL,
                                      bool HayParametros,
                                      string TipoConsulta)
        {
            try
            {
                int i = 0;

                CrearComando(CadenaSQL, TipoConsulta);

                if (HayParametros) {
                    while (i <= (pParametros.Count() - 1))
                    {
                        this.Commando.Parameters.Add(pParametros[i]);
                        i = i + 1;
                    }
                }

                return (IDbDataAdapter)this.EjecutarConsultaDataAdapter();
            }
            catch (Exception ex)
            {
                return null;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.DameDatos_DA ", ex);
            }
        }

        public IDataReader Dame_Datos_DR(string CadenaSQL,
                                      bool HayParametros,
                                      string TipoConsulta)
        {
            try
            {
                int i = 0;
                CrearComando(CadenaSQL, TipoConsulta);
                if (HayParametros) {
                    while (i <= (pParametros.Count() -1)) {
                        this.Commando.Parameters.Add(pParametros[i]);
                        i = i + 1;
                    }
                }

                return (IDataReader)this.Commando.ExecuteReader();
            }
            catch (Exception ex)
            {
                return null;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.DameDatosDR ", ex);
            }
        }

        public bool Añadir_Parametro(int Indice,
                                     string Nombre,
                                     string Tipo,
                                     string Valor)
        {

            //
            try
            {
                //List<IDbDataParameter> temp = new List<IDbDataParameter>(Indice);
                if (pParametros.Count -1 < Indice)
                {
                    for (int i = pParametros.Count; i <= Indice; i++)
                        pParametros.Add(null);
                }

                //pParametros = temp;

                switch (tipoBBDD)
                {
                    case BBDD.SQL :
                        pParametros[Indice] = new SqlParameter();
                        break;
                    case BBDD.ODBC :
                        pParametros[Indice] = new OdbcParameter();
                        break;
                    case BBDD.OLEDB :
                        pParametros[Indice] = new OleDbParameter();
                        break;
                        //case BBDD.MySQL :
                    //pParametros[Indice] = new MySqlParameter();
                }

                pParametros[Indice].ParameterName = Nombre;

                if (Valor == null || Valor == "") {
                    Tipo = "N";
                }
                if (Tipo == "BI") { if (Valor == "0") { Tipo = "N"; } }

                switch (Tipo)
                {
                    case "L" : //Long
                        Convert.ToInt64(Valor);
                        pParametros[Indice].DbType = DbType.Int64;
                        break;
                    case "D" : //Double
                        Convert.ToDouble(Valor);
                        pParametros[Indice].DbType = DbType.Double;
                        break;
                    case "B" : //Bit- Booleano
                        Convert.ToBoolean(Valor);
                        pParametros[Indice].DbType = DbType.Boolean;
                        break;
                    case "DC": //Decimal
                        Convert.ToDecimal(Valor);
                        pParametros[Indice].DbType = DbType.Decimal;
                        break;
                    case "DT": //Datetime
                        Convert.ToDateTime(Valor);
                        pParametros[Indice].DbType = DbType.DateTime;
                        break;
                    case "DA": //Date
                        Convert.ToString(Valor);
                        pParametros[Indice].DbType = DbType.Date;
                        break;
                    case "T": //Time
                        pParametros[Indice].DbType = DbType.Time;
                        break;
                    case "S" : //String
                        pParametros[Indice].DbType = DbType.String;
                        break;
                    case "I" : //Integer
                        Convert.ToInt32(Valor);
                        pParametros[Indice].DbType = DbType.Int32;
                        break;
                    case "SM": //Smallint
                        Convert.ToInt16(Valor);
                        pParametros[Indice].DbType = DbType.Int16;
                        break;
                    case "BI": //Smallint
                        Convert.ToByte(Valor);
                        pParametros[Indice].DbType = DbType.Byte;
                        break;
                    case "N":
                        /*Establece NULL*/
                        break;

                }
                if (Tipo == "N") { pParametros[Indice].Value = DBNull.Value; }
                else if (Tipo == "T") { pParametros[Indice].Value = DateTime.Parse(Valor).TimeOfDay;}
                else { pParametros[Indice].Value = Valor; }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.Añadir_Parametro ", ex);
            }

        }

        public bool Ejecutar_PA(string NombreProcedimiento,
                                bool HayParametros)
        {
            // Esta instancia ejecuta un procedimiento almacenado INSERT, DELETE o UPDATE
            try
            {
                int i = 0;

                CrearComando(NombreProcedimiento, "P");
                if (HayParametros) {
                    while (i <= pParametros.Count() - 1)
                    {
                        this.Commando.Parameters.Add(pParametros[i]);
                        i = i + 1;
                    }
                }

                if (this.Commando.ExecuteNonQuery() == 0) {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw new BaseDatosException("ERROR :" + ex.Message + " BASEDATOS.EjecutarPA ", ex);
            }

        }

    }
}

    


