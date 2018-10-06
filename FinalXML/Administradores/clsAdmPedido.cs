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
    public class clsAdmPedido
    {
        IPedido IPedido = new MysqlPedido();

        public clsPedido LeerPedido(String IdPedido)
        {
            try
            {
                return IPedido.LeerPedido(IdPedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public DataTable CargaPedidos(DateTime FInicio, DateTime FFin)
        {
            try
            {
                return IPedido.CargaPedidos(FInicio, FFin);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        public DataTable LeerDetalle(String IdPedido)
        {
            try
            {
                return IPedido.LeerDetalle(IdPedido);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

    }
}
