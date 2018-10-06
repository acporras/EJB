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
    
    public class clsAdmNumeracion
    {
        INumeracion MNum = new MysqlNumeracion();
      /*  public Boolean ActualizaNumeracion(clsNumeracion Numeracion)
        {
            try
            {
                return MNum.ActualizaNumeracion(Numeracion);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }*/

        public clsNumeracion  BuscaNumeracion(String TipoDocumento)
         {
            try
            {
                return MNum.BuscaNumeracion(TipoDocumento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

       /* public clsNumeracion BuscaNumeracionFac()
        {
            try
            {
                return MNum.BuscaNumeracionFac();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public clsNumeracion BuscaNumeracionDocBaja(String TipoDocumento)
        {
            try
            {
                return MNum.BuscaNumeracionDocBaja(TipoDocumento);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }*/
    }
   
}
