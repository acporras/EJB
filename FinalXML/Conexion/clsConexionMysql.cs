using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalXML.Conexion
{
    class clsConexionMysql 
    {
        public SqlConnection conector = null;
        public static String sConex = ConfigurationManager.ConnectionStrings["ConnNegocio"].ConnectionString;      

        public SqlConnection  conectarBD()
        {
            try
            {
               
                conector = new SqlConnection(sConex);
                conector.Open();
                return conector;

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SqlConnection desconectarBD()
        {
            conector.Close(); return conector;
        }

        public String LocalIPAddress()
        {
            IPHostEntry host;
            String localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

    }
}
