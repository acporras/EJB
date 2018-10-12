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
using System.Globalization;

namespace FinalXML.InterMySql
{
   public class MysqlCargaVentas : ICargaVentas
    {
        clsConexionMysql con = new clsConexionMysql();
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlDataAdapter adap = null;
        DataTable tabla = null;
        public Boolean Update(clsCargaVentas ven)
        {
            try
            {
                string consulta = @"UPDATE INT_DOCELECAB SET FA1_COD_ESTADO_SUNAT=@CodEstado, FA1_MENSAJE_SUNAT=@MensajeSunat,FA1_ESTADO_ENVIO=@EstadoEnv,FA1_XML=@Xml ,FA1_CDR=@Cdr,FA1_PDF=@Pdf
                                    FROM INT_DOCELECAB 
                                   WHERE FA1_CRUCEMI = @NumRuc AND FA1_CTIPDOC=@Sigla AND FA1_CSERDOC=@Serie AND FA1_CNUMDOC=@Numeracion";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NumRuc", ven.NumDocEmisor);
                cmd.Parameters.AddWithValue("CodEstado", ven.CodigoRespuesta);
                cmd.Parameters.AddWithValue("MensajeSunat", ven.MensajeRespuesta);
                cmd.Parameters.AddWithValue("EstadoEnv", ven.EstadoDocSunat);
                cmd.Parameters.AddWithValue("Sigla", ven.Sigla);
                cmd.Parameters.AddWithValue("Serie", ven.Serie);
                cmd.Parameters.AddWithValue("Numeracion", ven.Numeracion);
                cmd.Parameters.AddWithValue("Xml", ven.NombreArchivo);
                cmd.Parameters.AddWithValue("Cdr", ven.NombreArchivoCDR);
                cmd.Parameters.AddWithValue("Pdf", ven.NombreArchivoPDF);

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
        }
        public DataTable CargaVentas( DateTime desde, DateTime hasta)
        {
            try
            {
               string consulta = @"SELECT FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC,CONCAT(FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC) AS NUMDOC,
                                    FA1_CCODCLI,FA1_CNOMCLI,FA1_CDIRCLI,FA1_DFECDOC,FA1_NIMPORT,FA1_COD_ESTADO_SUNAT,
                                    FA1_MENSAJE_SUNAT, (CASE ISNULL(FA1_ESTADO_ENVIO,0) WHEN 0 THEN " + "'POR ENVIAR'" + " WHEN 1 THEN " +"'RECHAZADO'" + " WHEN 2 THEN " + "'PENDIENTE'" + " WHEN 3 THEN " + "'ACEPTADA'" + " WHEN 4 THEN " + "'ANULADO'" + " END ) AS ESTADO_ENVIO,FA1_XML,FA1_CDR,FA1_PDF " +
                                    "FROM INT_DOCELECAB "+
                                    "WHERE FA1_DFECDOC BETWEEN @desde AND @hasta ORDER BY FA1_CNUMDOC DESC";

                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta,con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@desde",SqlDbType.DateTime).Value= desde;
                cmd.Parameters.AddWithValue("@hasta", SqlDbType.DateTime).Value= hasta;                             
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

        public DataTable CargaDocumentos(String RucEmi ,DateTime desde, DateTime hasta, String CTipDoc)
        {
            try
            {
                string consulta = @"SELECT FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC,CONCAT(FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC) AS NUMDOC,
                                    FA1_CCODCLI,FA1_CNOMCLI,FA1_CDIRCLI,FA1_DFECDOC,FA1_NIMPORT,FA1_COD_ESTADO_SUNAT,
                                    FA1_MENSAJE_SUNAT, (CASE ISNULL(FA1_ESTADO_ENVIO,0) WHEN 0 THEN " + "'POR ENVIAR'" + " WHEN 1 THEN " + "'RECHAZADO'" + " WHEN 2 THEN " + "'PENDIENTE'" + " WHEN 3 THEN " + "'ACEPTADA'" + " WHEN 4 THEN " + "'ANULADO'" + " END ) AS ESTADO_ENVIO,FA1_XML,FA1_CDR,FA1_PDF " +
                                     "FROM INT_DOCELECAB " +
                                     "WHERE FA1_CRUCEMI= @rucemi AND (@tipdoc = '' OR FA1_CTIPDOC = @tipdoc) AND FA1_DFECDOC BETWEEN @desde AND @hasta ORDER BY FA1_CNUMDOC DESC";

                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rucemi", SqlDbType.Char).Value = RucEmi;
                cmd.Parameters.AddWithValue("@tipdoc", SqlDbType.Char).Value = CTipDoc;
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
        public DataTable CargaDocumentos(String RucEmi, DateTime desde, DateTime hasta, String CTipDoc, int Estado)
        {
            try
            {
                string consulta = @"SELECT FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC,CONCAT(FA1_CTIPDOC,FA1_CSERDOC,FA1_CNUMDOC) AS NUMDOC,
                                    FA1_CCODCLI,FA1_CNOMCLI,FA1_CDIRCLI,FA1_DFECDOC,FA1_NIMPORT,FA1_COD_ESTADO_SUNAT,
                                    FA1_MENSAJE_SUNAT, (CASE ISNULL(FA1_ESTADO_ENVIO,0) WHEN 0 THEN " + "'POR ENVIAR'" + " WHEN 1 THEN " + "'RECHAZADO'" + " WHEN 2 THEN " + "'PENDIENTE'" + " WHEN 3 THEN " + "'ACEPTADA'" + " WHEN 4 THEN " + "'ANULADO'" + " END ) AS ESTADO_ENVIO,FA1_XML,FA1_CDR,FA1_PDF " +
                                     "FROM INT_DOCELECAB " +
                                     "WHERE ISNULL(FA1_ESTADO_ENVIO, 0) = @estado AND FA1_CRUCEMI= @rucemi AND (@tipdoc = '' OR FA1_CTIPDOC = @tipdoc) AND FA1_DFECDOC BETWEEN @desde AND @hasta ORDER BY FA1_CNUMDOC DESC";

                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rucemi", SqlDbType.Char).Value = RucEmi;
                cmd.Parameters.AddWithValue("@tipdoc", SqlDbType.Char).Value = CTipDoc;
                cmd.Parameters.AddWithValue("@desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.AddWithValue("@hasta", SqlDbType.DateTime).Value = hasta;
                cmd.Parameters.AddWithValue("@estado", SqlDbType.Int).Value = Estado;
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
        public clsCargaVentas LeerVenta(String Sigla,String Serie, String Numeracion)
        {
            clsCargaVentas ven = null;
            try
            {
                string consulta = @"SELECT * FROM INT_DOCELECAB WHERE FA1_CTIPDOC=@Sigla AND FA1_CSERDOC=@Serie AND FA1_CNUMDOC=@Numeracion  ";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@Sigla", Sigla);
                cmd.Parameters.AddWithValue("@Serie", Serie);
                cmd.Parameters.AddWithValue("@Numeracion", Numeracion);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        /*ven = new clsCargaVentas();
                        ven.Sigla = dr.GetString(1);
                        ven.Serie = dr.GetString(2);
                        ven.Numeracion = dr.GetString(3);
                        ven.FechaEmision = dr.GetDateTime(5);
                        ven.NumDocCliente = dr.GetString(10);
                        ven.Cliente = dr.GetString(11);
                        ven.DirCliente = dr.GetString(12);
                        ven.SiglaDocAfecta = dr.GetString(23);
                        ven.SerieDocAfecta = dr.GetString(24);
                        ven.NumDocAfecta = dr.GetString(25);
                        ven.Moneda = dr.GetString(16);
                        ven.FechaVencimiento = dr.GetDateTime(6);
                        */
                        ven = new clsCargaVentas();
                        ven.Sigla = dr.GetString(2);
                        ven.Serie = dr.GetString(3);
                        ven.Numeracion = dr.GetString(4);
                        ven.FechaEmision = DateTime.ParseExact(dr.GetString(5), "yyyyMMdd",
                            CultureInfo.InvariantCulture);
                        ven.NumDocCliente = dr.GetString(9);
                        ven.Cliente = dr.GetString(8);
                        ven.DirCliente = dr.GetString(10);
                        ven.SiglaDocAfecta = dr.GetString(14);
                        ven.SerieDocAfecta = dr.GetString(15);
                        ven.NumDocAfecta = dr.GetString(16);
                        ven.Moneda = dr.GetString(24);
                        ven.FechaVencimiento = DateTime.ParseExact(dr.GetString(6), "yyyyMMdd",
                            CultureInfo.InvariantCulture);
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
        public clsCargaVentas LeerVenta(String NumRuc, String Sigla, String Serie, String Numeracion)
        {
            clsCargaVentas ven = null;
            try
            {
                string consulta = @"SELECT * FROM INT_DOCELECAB WHERE FA1_CRUCEMI=@numruc AND FA1_CTIPDOC=@Sigla AND FA1_CSERDOC=@Serie AND FA1_CNUMDOC=@Numeracion  ";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@numruc", NumRuc);
                cmd.Parameters.AddWithValue("@Sigla", Sigla);
                cmd.Parameters.AddWithValue("@Serie", Serie);
                cmd.Parameters.AddWithValue("@Numeracion", Numeracion);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ven = new clsCargaVentas();
                        ven.Sigla = dr.GetString(2);
                        ven.Serie = dr.GetString(3);
                        ven.Numeracion = dr.GetString(4);
                        ven.FechaEmision = DateTime.ParseExact(dr.GetString(5), "yyyyMMdd",
                            CultureInfo.InvariantCulture);
                        ven.NumDocCliente = dr.GetString(9);
                        ven.Cliente = dr.GetString(8);
                        ven.DirCliente = dr.GetString(10);
                        ven.SiglaDocAfecta = dr.GetString(14);
                        ven.SerieDocAfecta = dr.GetString(15);
                        ven.NumDocAfecta = dr.GetString(16);
                        ven.Moneda = dr.GetString(24);
                        ven.FechaVencimiento = DateTime.ParseExact(dr.GetString(6), "yyyyMMdd",
                            CultureInfo.InvariantCulture);
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

        public List<DetalleDocumento> LeerVentaDetalle(String Sigla, String Serie, String Numeracion)
        {
            DetalleDocumento ven = null;            
            List<DetalleDocumento>  Items = new List<DetalleDocumento>();
            try
            {
                string consulta = @" SELECT FA2_CITEM,FA2_CCODART,FA2_CNOMART,FA2_CUNIART,FA2_NCANTID,FA2_NPRECIO,FA2_NIMPIGV,FA2_NIMPOMN
                                     FROM INT_DOCELEDET  WHERE FA2_CTIPDOC=@Sigla AND FA2_CSERDOC=@Serie AND FA2_CNUMDOC=@Numeracion  ";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.Parameters.AddWithValue("@Sigla", Sigla);
                cmd.Parameters.AddWithValue("@Serie", Serie);
                cmd.Parameters.AddWithValue("@Numeracion", Numeracion);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                var totalRow = cmd.ExecuteScalar();
                if (dr.HasRows)
                {
                    Int32 i = 0;

                    while (dr.Read())
                    {
                        
                        ven = new DetalleDocumento();
                        if (dr.GetString(1).Trim() != "TXT")
                        {
                            if (i > 0) Items.Add(ven);
                            ven.Id = Convert.ToInt32(dr.GetString(0));
                            ven.CodigoItem = dr.GetString(1).Trim();
                            ven.Descripcion = dr.GetString(2).Trim();
                            //ven.UnidadMedida = dr.GetString(3).Trim();
                            ven.Cantidad = dr.GetDecimal(4);
                            ven.PrecioUnitario = dr.GetDecimal(5);
                            ven.Suma = Math.Round(ven.PrecioUnitario * ven.Cantidad, 2);
                            ven.SubTotalVenta = Math.Round(ven.Suma / Convert.ToDecimal(1.18), 2);
                            ven.Impuesto = Math.Round(ven.Suma - ven.SubTotalVenta, 2);
                            ven.TotalVenta = Math.Round(ven.Suma, 2);
                            ven.TipoPrecio = "01";
                            ven.TipoImpuesto = "10";
                        }else if (dr.GetString(1).Trim() == "TXT")
                        {
                            ven.Descripcion += dr.GetString(2).Trim();

                        }
                        i++;
                            //Items.Add(ven);
                    }

                }
                return Items;

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally { con.conector.Dispose(); cmd.Dispose(); con.desconectarBD(); }
        }

        public DataTable LeerDetalle(String Sigla, String Serie, String Numeracion)
        {

            try
            {
                string consulta = @"SELECT FA2_CITEM,FA2_CCODART,FA2_CNOMART,FA2_CUNIART,FA2_NCANTID,FA2_NPRECIO,FA2_NIMPIGV,FA2_NIMPOMN,FA2_NPRSIGV,FA2_NIMPOUS
                                     FROM INT_DOCELEDET  WHERE FA2_CTIPDOC=@Sigla AND FA2_CSERDOC=@Serie AND FA2_CNUMDOC=@Numeracion";
                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sigla", Sigla);
                cmd.Parameters.AddWithValue("@Serie", Serie);
                cmd.Parameters.AddWithValue("@Numeracion", Numeracion);
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
        public DataTable LeerDetalle(String  NumRuc ,String Sigla, String Serie, String Numeracion)
        {

            try
            {
                string consulta = @"SELECT FA2_CITEM,FA2_CCODART,FA2_CNOMART,FA2_CUNIART,FA2_NCANTID,FA2_NPRECIO,FA2_NIMPIGV,FA2_NIMPOMN,FA2_NPRSIGV,FA2_NIMPOUS
                                     FROM INT_DOCELEDET WHERE FA2_CRUCEMI=@numruc AND FA2_CTIPDOC=@Sigla AND FA2_CSERDOC=@Serie AND FA2_CNUMDOC=@Numeracion";
                tabla = new DataTable();
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@numruc", NumRuc);
                cmd.Parameters.AddWithValue("@Sigla", Sigla);
                cmd.Parameters.AddWithValue("@Serie", Serie);
                cmd.Parameters.AddWithValue("@Numeracion", Numeracion);
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
        public Boolean ActualizarEstadoResumen(String NumRuc, String Ticket)
        {
            try
            {
                string consulta = @"UPDATE INT_DOCELECAB SET FA1_COD_ESTADO_SUNAT='0',FA1_ESTADO_ENVIO='3'
                                    FROM INT_DOCELECAB 
                                   WHERE FA1_CRUCEMI = @NumRuc AND FA1_MENSAJE_SUNAT=@Ticket";
                con.conectarBD();
                cmd = new SqlCommand(consulta, con.conector);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NumRuc", NumRuc);
                cmd.Parameters.AddWithValue("Ticket", Ticket);

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
        }
    }
}
