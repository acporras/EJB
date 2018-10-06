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
    public class MysqlNumeracion : INumeracion
    {
        clsConexionMysql con = new clsConexionMysql();
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlDataAdapter adap = null;
        DataTable tabla = null;
        public clsNumeracion BuscaNumeracion(String TipoDocumento)
        {
            clsNumeracion ser = null;
            try
            {
                con.conectarBD();            
                cmd = new  SqlCommand ("Select * From INT_DOCELECAB", con.conector);                
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ser = new clsNumeracion();

                        //ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                        ser.TipoDocumento = Convert.ToString(dr.GetString(2));
                        /* ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                         ser.Serie = Convert.ToString(dr.GetString(3));
                         ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));*/
                    }
                }
                return ser;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
/*
        public clsNumeracion BuscaNumeracion(String TipoDocumento)
         {
             clsNumeracion ser = null;
             try
             {
                 con.conectarBD();
                 cmd = new MySqlCommand("BuscarNumeracion", con.conector);
                 cmd.Parameters.AddWithValue("tipdoc", TipoDocumento);                
                 cmd.CommandType = CommandType.StoredProcedure;
                 dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         ser = new clsNumeracion();
                         ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                         ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                         ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                         ser.Serie = Convert.ToString(dr.GetString(3));
                         ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));                       
                     }
                 }
                 return ser;
             }
             catch (MySqlException ex)
             {
                 throw ex;
             }
             finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
         }
         public clsNumeracion BuscaNumeracionDocBaja(String TipoDocumento)
         {
             clsNumeracion ser = null;
             try
             {
                 con.conectarBD();
                 cmd = new MySqlCommand("BuscarNumeracion", con.conector);
                 cmd.Parameters.AddWithValue("tipdoc", TipoDocumento);
                 cmd.CommandType = CommandType.StoredProcedure;
                 dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         ser = new clsNumeracion();
                         ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                         ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                         ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                         ser.Serie = Convert.ToString(dr.GetString(3));
                         ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                     }
                 }
                 return ser;
             }
             catch (MySqlException ex)
             {
                 throw ex;
             }
             finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
         }
         public clsNumeracion BuscaNumeracionFac()
         {
           
             clsNumeracion ser = null;
             try
             {
                 con.conectarBD();
                 cmd = new MySqlCommand("BuscaNumeracionFac", con.conector);              
                 cmd.CommandType = CommandType.StoredProcedure;
                 dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         ser = new clsNumeracion();
                         ser.IDDocumento = Convert.ToInt32(dr.GetDecimal(0));
                         ser.TipoDocumento = Convert.ToString(dr.GetString(1));
                         ser.NombreDocumento = Convert.ToString(dr.GetString(2));
                         ser.Serie = Convert.ToString(dr.GetString(3));
                         ser.Numeracion = Convert.ToInt32(dr.GetInt32(4));
                     }
                 }
                 return ser;
             }
             catch (MySqlException ex)
             {
                 throw ex;
             }
             finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
         }
        public Boolean ActualizaNumeracion(clsNumeracion Numeracion)
         {
            return true;
            try
             {
                 con.conectarBD();

                 cmd = new MySqlCommand("ActualizaNumeracion", con.conector);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("numera", Numeracion.Numeracion);
                 cmd.Parameters.AddWithValue("tipdoc", Numeracion.TipoDocumento);

                 int x = cmd.ExecuteNonQuery();
                 if (x != 0)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
             catch (MySqlException ex)
             {
                 throw ex;

             }
             finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
         }*/

    }
}
