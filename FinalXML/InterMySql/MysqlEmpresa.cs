using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using FinalXML.Entidades;
using FinalXML.Interfaces;
using FinalXML.Conexion;
using System.Data.Sql;
using System.Data.SqlClient;
namespace FinalXML.InterMySql
{
    public class MysqlEmpresa : IEmpresa
    {
        clsConexionMysql con = new clsConexionMysql();
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlDataAdapter adap = null;
        DataTable tabla = null;

        public DataTable CargaEmpresa()
        {
            try
            {
                string consulta = @"SELECT * FROM MAE_EMIDOCELE WHERE FL_REGINACTI = '0' ORDER BY FE_REGCREACI";

                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                adap = new SqlDataAdapter(cmd);
                adap.Fill(tabla);
                return tabla;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable CargaEmpresa(String NumRuc)
        {
            try
            {
                string consulta = @"SELECT * FROM MAE_EMIDOCELE WHERE NU_EMINUMRUC = @numruc ORDER BY FE_REGCREACI";

                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@numruc", SqlDbType.Char).Value = NumRuc;
                cmd.CommandType = CommandType.Text;
                adap = new SqlDataAdapter(cmd);
                adap.Fill(tabla);
                return tabla;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public Contribuyente LeerEmpresa(String NumRuc)
        {
            Contribuyente cont = null;
            try
            {
                string consulta = @"SELECT * FROM MAE_EMIDOCELE WHERE FL_REGINACTI = '0' AND NU_EMINUMRUC = @numruc ORDER BY FE_REGCREACI";

                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@numruc", SqlDbType.Char).Value = NumRuc;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cont = new Contribuyente();
                        cont.CodigoEmpresa = dr.GetInt32(0);
                        cont.NroDocumento = dr.GetString(1);
                        cont.TipoDocumento = "6";
                        cont.NombreLegal = dr.GetString(2);
                        cont.NombreComercial = dr.GetString(2);
                        cont.Ubigeo = dr.GetString(6);
                        cont.Direccion = dr.GetString(10);
                        cont.Urbanizacion = "";
                        cont.Departamento = dr.GetString(7);
                        cont.Provincia = dr.GetString(8);
                        cont.Distrito = dr.GetString(9);
                        cont.UsuarioSol = dr.GetString(19);
                        cont.ClaveSol = dr.GetString(20);
                    }

                }
                return cont;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public int GetCorrelativoMasivo(int codEmpresa, String TipoDoc)
        {
            int correlativo = 0;
            try
            {
                string consulta = @"SPS_GET_CORRELATIVO_MASIVOS @nidempresa, @tipdoc";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@nidempresa", SqlDbType.Int).Value = codEmpresa;
                cmd.Parameters.AddWithValue("@tipdoc", SqlDbType.Char).Value = TipoDoc;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        correlativo = dr.GetInt32(0);
                    }

                }
                return correlativo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public Boolean SetCorrelativoMasivo(int codEmpresa, String TipoDoc, int NeoCor)
        {
            try
            {
                string consulta = @"SPS_SET_CORRELATIVO_MASIVOS @nidempresa, @tipdoc, @neocor";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@nidempresa", SqlDbType.Int).Value = codEmpresa;
                cmd.Parameters.AddWithValue("@tipdoc", SqlDbType.Char).Value = TipoDoc;
                cmd.Parameters.AddWithValue("@neocor", SqlDbType.Int).Value = NeoCor;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public Boolean AnularDocumento(String NumRuc, String TipDoc, String Sersun, String NumSun)
        {
            try
            {
                string consulta = @"UPDATE INT_DOCELECAB SET FA1_ESTADO_ENVIO = 4 WHERE FA1_CRUCEMI = @numruc AND FA1_CTIPDOC = @tipdoc AND FA1_CSERDOC = @sersun AND FA1_CNUMDOC = @numsun";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@numruc", SqlDbType.Char).Value = NumRuc;
                cmd.Parameters.AddWithValue("@tipdoc", SqlDbType.Char).Value = TipDoc;
                cmd.Parameters.AddWithValue("@sersun", SqlDbType.Char).Value = Sersun;
                cmd.Parameters.AddWithValue("@numsun", SqlDbType.Char).Value = NumSun;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public Boolean GuardarEmpresa(clsEmpresa empresa)
        {
            try
            {
                string consulta = @"INSERT INTO MAE_EMIDOCELE(NU_EMINUMRUC, NO_EMIRAZSOC, CO_EMICODAGE, NO_ESTEMIELE, NO_CONEMIELE, NO_EMIUBIGEO, NO_EMIDEPART, NO_EMIPROVIN, NO_EMIDISTRI, NO_EMIDIRFIS, NO_BASTIPBAS, NO_BASNOMSRV, NO_BASNOMBAS, NO_BASUSRBAS, NO_BASUSRPAS, NO_TABFACCAB, NO_TABFACDET, NO_USUSOLSUN, NO_PASSOLSUN, FE_REGCREACI, FL_REGINACTI) " +
                    "VALUES(@nu_eminumruc, @no_emirazsoc, @co_emicodage, @no_estemiele, @no_conemiele, @no_emiubigeo, @no_emidepart, @no_emiprovin, @no_emidistri, @no_emidirfis, @no_bastipbas, @no_basnomsrv, @no_basnombas, @no_basusrbas, @no_basusrpas, @no_tabfaccab, @no_tabfacdet, @no_ususolsun, @no_passolsun, GETDATE(), @fl_reginacti)";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@nu_eminumruc", SqlDbType.VarChar).Value = empresa.nu_eminumruc;
                cmd.Parameters.AddWithValue("@no_emirazsoc", SqlDbType.VarChar).Value = empresa.no_emirazsoc;
                cmd.Parameters.AddWithValue("@co_emicodage", SqlDbType.VarChar).Value = empresa.co_emicodage;
                cmd.Parameters.AddWithValue("@no_estemiele", SqlDbType.VarChar).Value = empresa.no_estemiele;
                cmd.Parameters.AddWithValue("@no_conemiele", SqlDbType.VarChar).Value = empresa.no_conemiele;
                cmd.Parameters.AddWithValue("@no_emiubigeo", SqlDbType.VarChar).Value = empresa.no_emiubigeo;
                cmd.Parameters.AddWithValue("@no_emidepart", SqlDbType.VarChar).Value = empresa.no_emidepart;
                cmd.Parameters.AddWithValue("@no_emiprovin", SqlDbType.VarChar).Value = empresa.no_emiprovin;
                cmd.Parameters.AddWithValue("@no_emidistri", SqlDbType.VarChar).Value = empresa.no_emidistri;
                cmd.Parameters.AddWithValue("@no_emidirfis", SqlDbType.VarChar).Value = empresa.no_emidirfis;
                cmd.Parameters.AddWithValue("@no_bastipbas", SqlDbType.VarChar).Value = empresa.no_bastipbas;
                cmd.Parameters.AddWithValue("@no_basnomsrv", SqlDbType.VarChar).Value = empresa.no_basnomsrv;
                cmd.Parameters.AddWithValue("@no_basnombas", SqlDbType.VarChar).Value = empresa.no_basnombas;
                cmd.Parameters.AddWithValue("@no_basusrbas", SqlDbType.VarChar).Value = empresa.no_basusrbas;
                cmd.Parameters.AddWithValue("@no_basusrpas", SqlDbType.VarChar).Value = empresa.no_basusrpas;
                cmd.Parameters.AddWithValue("@no_tabfaccab", SqlDbType.VarChar).Value = empresa.no_tabfaccab;
                cmd.Parameters.AddWithValue("@no_tabfacdet", SqlDbType.VarChar).Value = empresa.no_tabfacdet;
                cmd.Parameters.AddWithValue("@no_ususolsun", SqlDbType.VarChar).Value = empresa.no_ususolsun;
                cmd.Parameters.AddWithValue("@no_passolsun", SqlDbType.VarChar).Value = empresa.no_passolsun;
                cmd.Parameters.AddWithValue("@fl_reginacti", SqlDbType.VarChar).Value = empresa.fl_reginacti;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public Boolean ActualizarEmpresa(clsEmpresa empresa)
        {
            try
            {
                string consulta = @"UPDATE MAE_EMIDOCELE " +
                    "SET NO_EMIRAZSOC = @no_emirazsoc, " +
                    "CO_EMICODAGE = @co_emicodage, " +
                    "NO_ESTEMIELE = @no_estemiele, " +
                    "NO_CONEMIELE = @no_conemiele, " +
                    "NO_EMIUBIGEO = @no_emiubigeo, " +
                    "NO_EMIDEPART = @no_emidepart, " +
                    "NO_EMIPROVIN = @no_emiprovin, " +
                    "NO_EMIDISTRI = @no_emidistri, " +
                    "NO_EMIDIRFIS = @no_emidirfis, " +
                    "NO_BASTIPBAS = @no_bastipbas, " +
                    "NO_BASNOMSRV = @no_basnomsrv, " +
                    "NO_BASNOMBAS = @no_basnombas, " +
                    "NO_BASUSRBAS = @no_basusrbas, " +
                    "NO_BASUSRPAS = @no_basusrpas, " +
                    "NO_TABFACCAB = @no_tabfaccab, " +
                    "NO_TABFACDET = @no_tabfacdet, " +
                    "NO_USUSOLSUN = @no_ususolsun, " +
                    "NO_PASSOLSUN = @no_passolsun, " +
                    "FE_REGMODIFI = GETDATE(), " +
                    "FL_REGINACTI = @fl_reginacti " +
                    "WHERE NU_EMINUMRUC = @nu_eminumruc";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@nu_eminumruc", SqlDbType.VarChar).Value = empresa.nu_eminumruc;
                cmd.Parameters.AddWithValue("@no_emirazsoc", SqlDbType.VarChar).Value = empresa.no_emirazsoc;
                cmd.Parameters.AddWithValue("@co_emicodage", SqlDbType.VarChar).Value = empresa.co_emicodage;
                cmd.Parameters.AddWithValue("@no_estemiele", SqlDbType.VarChar).Value = empresa.no_estemiele;
                cmd.Parameters.AddWithValue("@no_conemiele", SqlDbType.VarChar).Value = empresa.no_conemiele;
                cmd.Parameters.AddWithValue("@no_emiubigeo", SqlDbType.VarChar).Value = empresa.no_emiubigeo;
                cmd.Parameters.AddWithValue("@no_emidepart", SqlDbType.VarChar).Value = empresa.no_emidepart;
                cmd.Parameters.AddWithValue("@no_emiprovin", SqlDbType.VarChar).Value = empresa.no_emiprovin;
                cmd.Parameters.AddWithValue("@no_emidistri", SqlDbType.VarChar).Value = empresa.no_emidistri;
                cmd.Parameters.AddWithValue("@no_emidirfis", SqlDbType.VarChar).Value = empresa.no_emidirfis;
                cmd.Parameters.AddWithValue("@no_bastipbas", SqlDbType.VarChar).Value = empresa.no_bastipbas;
                cmd.Parameters.AddWithValue("@no_basnomsrv", SqlDbType.VarChar).Value = empresa.no_basnomsrv;
                cmd.Parameters.AddWithValue("@no_basnombas", SqlDbType.VarChar).Value = empresa.no_basnombas;
                cmd.Parameters.AddWithValue("@no_basusrbas", SqlDbType.VarChar).Value = empresa.no_basusrbas;
                cmd.Parameters.AddWithValue("@no_basusrpas", SqlDbType.VarChar).Value = empresa.no_basusrpas;
                cmd.Parameters.AddWithValue("@no_tabfaccab", SqlDbType.VarChar).Value = empresa.no_tabfaccab;
                cmd.Parameters.AddWithValue("@no_tabfacdet", SqlDbType.VarChar).Value = empresa.no_tabfacdet;
                cmd.Parameters.AddWithValue("@no_ususolsun", SqlDbType.VarChar).Value = empresa.no_ususolsun;
                cmd.Parameters.AddWithValue("@no_passolsun", SqlDbType.VarChar).Value = empresa.no_passolsun;
                cmd.Parameters.AddWithValue("@fl_reginacti", SqlDbType.VarChar).Value = empresa.fl_reginacti;
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

    }
}
