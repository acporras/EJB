using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalXML.Interfaces;
using FinalXML.Administradores;
using FinalXML.InterMySql;
using FinalXML.Entidades;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace FinalXML.Administradores
{
    public class clsAdmCargaVentas
    {
        ICargaVentas Cventa = new MysqlCargaVentas();

        public Boolean update(clsCargaVentas ven)
        {
            try
            {
                return Cventa.Update(ven);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public DataTable CargaVentas(DateTime FInicio,DateTime FFin)
        {
            try
            {
                return Cventa.CargaVentas(FInicio, FFin);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDocumentos(String RucEmi ,DateTime FInicio, DateTime FFin, String CTipDoc)
        {
            try
            {
                return Cventa.CargaDocumentos(RucEmi ,FInicio, FFin, CTipDoc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaDocumentos(String RucEmi, DateTime FInicio, DateTime FFin, String CTipDoc, int Estado)
        {
            try
            {
                return Cventa.CargaDocumentos(RucEmi, FInicio, FFin, CTipDoc, Estado);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCargaVentas LeerVenta(String Sigla,String Serie, String Numeracion)
        {
            try
            {
                return Cventa.LeerVenta(Sigla,Serie,Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsCargaVentas LeerVenta(String NumRuc, String Sigla, String Serie, String Numeracion)
        {
            try
            {
                return Cventa.LeerVenta(NumRuc ,Sigla, Serie, Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public List<DetalleDocumento> LeerVentaDetalle(String Sigla, String Serie, String Numeracion)
        {
            try
            {
                return Cventa.LeerVentaDetalle(Sigla, Serie, Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable LeerDetalle(String Sigla, String Serie, String Numeracion)
        {
            try
            {
                return Cventa.LeerDetalle(Sigla, Serie, Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable LeerDetalle(String NumRuc ,String Sigla, String Serie, String Numeracion)
        {
            try
            {
                return Cventa.LeerDetalle(NumRuc ,Sigla, Serie, Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public Boolean ActualizarEstadoResumen(String NumRuc, String Ticket)
        {
            try
            {
                return Cventa.ActualizarEstadoResumen(NumRuc, Ticket);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
