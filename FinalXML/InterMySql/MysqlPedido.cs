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
    public class MysqlPedido : IPedido
    {
        clsConexionMysql con = new clsConexionMysql();
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlDataAdapter adap = null;
        DataTable tabla = null;

        public clsPedido LeerPedido(String IdPedido)
        {
            clsPedido ven = null;
            try
            {
                string consulta = @"SELECT * FROM PD0003PENC WHERE F5_CNUMPED=@IdPedido";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@IdPedido", IdPedido);                
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ven = new clsPedido();
                        ven.IdPedido = dr.GetString(1);
                        ven.Sigla = dr.GetString(2);
                        ven.Serie = dr.GetString(3);
                        ven.Numeracion = dr.GetString(4);
                        ven.FechaEmision = dr.GetDateTime(5);
                        ven.NumDocCliente = dr.GetString(10).Trim();
                        ven.Cliente = dr.GetString(11).Trim();
                        ven.DirCliente = dr.GetString(12).Trim();
                        
                        
                    }

                }
                return ven;

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }
        public DataTable CargaPedidos(DateTime desde, DateTime hasta)
        {
            try
            {
                string consulta = @"SELECT F5_CNUMPED,F5_CTD,F5_CNUMSER,F5_CNUMDOC,CONCAT(F5_CTD,'-',F5_CNUMSER,'-',F5_CNUMDOC) AS NUMDOC,
                                    F5_CCODCLI,F5_CNOMBRE,F5_CDIRECC,F5_DFECDOC,F5_NIMPORT " +
                                     "FROM PD0003PENC "+
                                     "WHERE F5_DFECDOC BETWEEN @desde AND @hasta ORDER BY F5_CNUMDOC DESC";
         
                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.AddWithValue("@hasta", SqlDbType.DateTime).Value = hasta;
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
        public DataTable LeerDetalle(String IdPedido)
        {

            try
            {
                string consulta = @"SELECT F6_CITEM,F6_CCODIGO,F6_CDESCRI,F6_CUNIDAD,F6_NCANTID,F6_NPRECIO,F6_NIGV,F6_NIMPMN
                                     FROM PD0003PEND  WHERE F6_CNUMPED=@IdPedido";
                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdPedido", IdPedido);             
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
    }

}
