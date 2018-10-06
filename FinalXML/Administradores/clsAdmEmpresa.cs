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
    public class clsAdmEmpresa
    {
        IEmpresa CEmpresa = new MysqlEmpresa();

        public DataTable CargaEmpresa()
        {
            try
            {
                return CEmpresa.CargaEmpresa();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public Contribuyente LeerEmpresa(String NumRuc)
        {
            try
            {
                return CEmpresa.LeerEmpresa(NumRuc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public int GetCorrelativoMasivo(int codEmpresa, String TipoDoc)
        {
            try
            {
                return CEmpresa.GetCorrelativoMasivo(codEmpresa, TipoDoc);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public Boolean SetCorrelativoMasivo(int codEmpresa, String TipoDoc, int NeoCor)
        {
            try
            {
                return CEmpresa.SetCorrelativoMasivo(codEmpresa, TipoDoc, NeoCor);
            }
            catch(Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public Boolean AnularDocumento(String NumRuc, String TipDoc, String Sersun, String NumSun)
        {
            try
            {
                return CEmpresa.AnularDocumento(NumRuc, TipDoc, Sersun, NumSun);
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Se encontró el siguiente problema: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
