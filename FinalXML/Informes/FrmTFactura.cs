using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Drawing.Printing;


using System.Drawing;
using System.Diagnostics;

namespace FinalXML.Informes
{
    public partial class FrmTFactura : Form
    {
        public DocumentoElectronico _documento;
        private string rptact;
        private object lst;
        public object empresa;
        public object general;
        public object receptor;
        public object otros;
        public Byte[] LogoEmp { get; set; }
        public DocumentoElectronico _idcodumento;
        public FrmTFactura(string nombrereporte, DocumentoElectronico lista)
        {
            InitializeComponent();
            List<Contribuyente> Emisor = new List<Contribuyente>();
            ClsDatosReportes cabecera = new ClsDatosReportes();
            List<ClsDatosReportes> valores = new List<ClsDatosReportes>();
            List<Contribuyente> Receptor = new List<Contribuyente>();
            if (lista.Moneda == "PEN")
            {
                cabecera.MonedaLetra = "SOLES";
                cabecera.Moneda = "S/";
            }
            else
            {
                if (lista.Moneda == "USD")
                {
                    cabecera.MonedaLetra = "DOLARES AMERICANOS";
                    cabecera.Moneda = "$";
                }
            }
            cabecera.IdDocumento = lista.IdDocumento;
            cabecera.FechaEmision = lista.FechaEmision;
            cabecera.Gravadas = lista.Gravadas;
            cabecera.Inafectas = lista.Inafectas;
            cabecera.Gratuitas = lista.Gratuitas;
            cabecera.Exoneradas = lista.Exoneradas;
            cabecera.TotalIgv = lista.TotalIgv;
            cabecera.TotalVenta = lista.TotalVenta;
            cabecera.MontoEnLetras = lista.MontoEnLetras;
            cabecera.SubTotalVentas = lista.SubTotalVenta;

            valores.Add(cabecera);
            Emisor.Add(lista.Emisor);
            Receptor.Add(lista.Receptor);

            this.rptact = nombrereporte;
            this.lst = lista.Items;
            this.empresa = Emisor;
            this.general = valores;
            this.receptor = Receptor;
            this.otros = valores;
        }

        private void FrmTFactura_Load(object sender, EventArgs e)
        {
         

            Herramientas herramientas = new Herramientas();
            var recursos = herramientas.GetResourcesPath2();

            /*FIRMA PDF*/
            var nomdocumento = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento;

            String datosAdicionales_CDB = "";
            String CodigoCertificado = "";

            datosAdicionales_CDB = _documento.Emisor.NroDocumento + "|" + _documento.TipoDocumento + "|" + _documento.IdDocumento + "|" + _documento.TotalIgv + "|" + _documento.TotalVenta + "|"
                                 + _documento.FechaEmision + "|" + _documento.Receptor.TipoDocumento + "|" + _documento.Receptor.NroDocumento;
            CodigoCertificado = datosAdicionales_CDB + "|" + _documento.FirmaDigital;
            BarcodePDF417 codigobarras = new BarcodePDF417();
            codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            codigobarras.ErrorLevel = 5;
            codigobarras.YHeight = 6f;
            codigobarras.SetText(CodigoCertificado);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            //bm.Save(@"C:\DOCUMENTOS ELECTRONICOS\CERTIFIK\QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bm.Save(@"QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            

            /*FIN FIRMA*/

            List<ReportParameter> parametro = new List<ReportParameter>();
            //parametro.Add(new ReportParameter("pLogo", @"file:///C:/PIURAMAQ.png"));
            parametro.Add(new ReportParameter("pLogo", @"file:///" + recursos + "/" + nomdocumento + ".jpeg"));
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.EnableExternalImages = true;

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.TFactura.rdlc";
            reportViewer1.LocalReport.SetParameters(parametro);

            ReportDataSource datos = new ReportDataSource();
            datos.Name = "DetalleDocumento";
            datos.Value = lst;
            ReportDataSource datos2 = new ReportDataSource();
            datos2.Name = "Empresa";
            datos2.Value = empresa;
            ReportDataSource datos3 = new ReportDataSource();
            datos3.Name = "General";
            datos3.Value = general;
            ReportDataSource datos4 = new ReportDataSource();
            datos4.Name = "Receptor";
            datos4.Value = receptor;
            ReportDataSource datos5 = new ReportDataSource();
            datos5.Name = "Otros";
            datos5.Value = otros;


            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datos);
            this.reportViewer1.LocalReport.DataSources.Add(datos2);
            this.reportViewer1.LocalReport.DataSources.Add(datos3);
            this.reportViewer1.LocalReport.DataSources.Add(datos4);
            this.reportViewer1.LocalReport.DataSources.Add(datos5);
            this.reportViewer1.RefreshReport();


            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            //ToString("yyyy-MM-dd")
            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(@"FACTURAS_PDF\\" + nomdocumento + "-1.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            

            /* PrintDocument printDocument = new PrintDocument();
             printDocument.PrinterSettings.PrinterName = "\\\\192.168.1.35\\EPSON LX-350 ESC/P";

             if (!printDocument.PrinterSettings.IsValid)
                 return; //ImpresoraNoEncontrada

             //printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
             //printDocument.PrintPage+=new PrintPageEventHandler();
             printDocument.Print();*/

            /* try
             {
                 var streamToPrint = new StreamReader
                                    ("C:\\MyFile.txt");
                 try
                 {
                     //printFont = new Font("Arial", 10);
                     PrintDocument pd = new PrintDocument();
                     pd.PrintPage += new PrintPageEventHandler
                        (this.pd_PrintPage);
                     pd.Print();
                 }
                 finally
                 {
                     streamToPrint.Close();
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
            //printaFactura( nomdocumento);

            /* ProcessStartInfo info = new ProcessStartInfo();
             info.Verb = "print";
             info.FileName = @"FACTURAS_PDF\\" + nomdocumento + ".pdf";
             info.CreateNoWindow = true;
             info.WindowStyle = ProcessWindowStyle.Hidden;

             Process p = new Process();
             p.StartInfo = info;
             p.Start();

             p.WaitForInputIdle();
             System.Threading.Thread.Sleep(3000);
             if (false == p.CloseMainWindow())
                 p.Kill();*/
                 
            /* var informe = herramientas.GetResourcesPath3();
             PrintDialog pd = new PrintDialog();
             pd.PrinterSettings = new PrinterSettings();
             pd.PrinterSettings.PrinterName = "\\\\192.168.1.35\\EPSON LX-350 ESC/P";

             Process printjob = new Process();
             printjob.StartInfo.FileName = @"FACTURAS_PDF\\" + nomdocumento + ".pdf";
            printjob.StartInfo.Arguments = pd.PrinterSettings.PrinterName;
             printjob.StartInfo.UseShellExecute = true;
             printjob.StartInfo.CreateNoWindow = true;
             printjob.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
             printjob.StartInfo.Verb = "print";
             printjob.Start();*/


            /*Process impresion = new Process();
            impresion.StartInfo.FileName = @"FACTURAS_PDF\\" + nomdocumento + ".pdf";
            impresion.StartInfo.UseShellExecute = true;
            impresion.StartInfo.CreateNoWindow = true;
            impresion.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            impresion.StartInfo.Verb = "print";
            impresion.Start();*/


        }
        // The PrintPage event is raised for each page to be printed.

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
           /*linesPerPage = ev.MarginBounds.Height /           printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
            */
            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }


        private void printaFactura( string nomdocumento)
        {
            try
            {
                Herramientas herramientas = new Herramientas();

                var informe = herramientas.GetResourcesPath3();

                CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                rd.Load(informe +"\\"+ nomdocumento+".pdf");


                CrystalDecisions.CrystalReports.Engine.PrintOptions rptoption = rd.PrintOptions;
                rptoption.PrinterName = "\\\\192.168.1.35\\EPSON LX-350 ESC/P";
                rptoption.PaperSize = (CrystalDecisions.Shared.PaperSize)GetIDPaperSize("\\\\192.168.1.35\\EPSON LX-350 ESC/P", "A4");//(CrystalDecisions.Shared.PaperSize)ext.GetIDPaperSize(Convert.ToString(System.Drawing.Printing.PrinterSettings.InstalledPrinters[3]), "documentoFioviza");           

                rd.PrintToPrinter(1, false, 1, 1);

                rd.Close();
                rd.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Se encontro el siguiente problema" + ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Int32 GetIDPaperSize(String PrinterName, String PaperSizeName)
        {
            System.Drawing.Printing.PrintDocument pdprint = new System.Drawing.Printing.PrintDocument();
            pdprint.PrinterSettings.PrinterName = PrinterName;
            Int32 PaperSizeID = 0;
            foreach (System.Drawing.Printing.PaperSize ps in pdprint.PrinterSettings.PaperSizes)
            {
                if (ps.PaperName == PaperSizeName)
                {
                    PaperSizeID = ps.RawKind;
                    break;
                }
            }
            return PaperSizeID;
        }

    }
}
