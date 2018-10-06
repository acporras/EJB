using System;
using System.IO;
using System.Windows.Forms;
using FinalXML;
namespace FinalXML
{

   public static class Program
    {
        public static string CarpetaXml => "./XML";
        public static string CarpetaCdr => "./CDR";
        public static string Certificado => "./Certificado";
        public static string FACTURAS_PDF => "./FACTURAS_PDF";
        public static string BOLETAS_PDF => "./BOLETAS_PDF";
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!Directory.Exists(CarpetaXml))
                    Directory.CreateDirectory(CarpetaXml);
                if (!Directory.Exists(CarpetaCdr))
                    Directory.CreateDirectory(CarpetaCdr);
                if (!Directory.Exists(FACTURAS_PDF))
                    Directory.CreateDirectory(FACTURAS_PDF);
                if (!Directory.Exists(BOLETAS_PDF))
                    Directory.CreateDirectory(BOLETAS_PDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            Application.Run(new Form2());
        }
    }
}
