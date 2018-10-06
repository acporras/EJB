using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using FinalXML.Entidades;




namespace FinalXML.Informes
{
    public partial class FrmPedido : Form
    {
        public clsPedido Pedido2;
        public String nomdocumento;
        private object lst;      
        public object general;
        
        public FrmPedido(clsPedido Pedido)
        {
            InitializeComponent();
            Pedido2 = new clsPedido();
           
            List<clsPedido> Ped = new List<clsPedido>();
            if (Pedido.Moneda == "PEN")
            {
                Pedido.MonedaLetra = "SOLES";
                Pedido.Moneda = "S/";
            }
            else
            {
                if (Pedido.Moneda == "USD")
                {
                    Pedido.MonedaLetra = "DOLARES AMERICANOS";
                    Pedido.Moneda = "$";
                }
            }
            

            Pedido2 = Pedido;
            Ped.Add(Pedido2);
            this.general = Ped;
            this.lst = Pedido.Items;
            nomdocumento = Pedido.IdPedido + "-" +(Pedido.FechaEmision.ToString("yyyy-MM-dd"));
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            try {
                Herramientas herramientas = new Herramientas();
                var recursos = herramientas.GetResourcesPath2();
                this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.EnableExternalImages = true;

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.DTPedido.rdlc";
               

                ReportDataSource datos = new ReportDataSource();
                datos.Name = "DetalleDocumento";
                datos.Value = lst;
                ReportDataSource datos2 = new ReportDataSource();
                datos2.Name = "General";
                datos2.Value = general;
                this.reportViewer1.RefreshReport();
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datos);
                this.reportViewer1.LocalReport.DataSources.Add(datos2);
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

                using (FileStream fs = new FileStream(@"PEDIDOS_PDF\\" + nomdocumento + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
               
            }
            catch (Exception a ) { MessageBox.Show(a.Message); }
        }
        private static void WriteTextToDocument(BaseFont bf, iTextSharp.text.Rectangle tamPagina, PdfContentByte over,PdfGState gs, string texto)

        {

            over.SetGState(gs);

            over.SetRGBColorFill(220, 220, 220);

            over.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_STROKE);

            over.SetFontAndSize(bf, 46);

            Single anchoDiag =

                (Single)Math.Sqrt(Math.Pow((tamPagina.Height - 120), 2)

                + Math.Pow((tamPagina.Width - 60), 2));

            Single porc = (Single)100

                * (anchoDiag / bf.GetWidthPoint(texto, 46));

            over.SetHorizontalScaling(porc);

            double angPage = (-1)

            * Math.Atan((tamPagina.Height - 60) / (tamPagina.Width - 60));

            over.SetTextMatrix((float)Math.Cos(angPage),

                       (float)Math.Sin(angPage),

                       (float)((-1F) * Math.Sin(angPage)),

                       (float)Math.Cos(angPage),

                       30F,

                       (float)tamPagina.Height - 60);

            over.ShowText(texto);


        }

        public  void PDF() {
            string path = @"PEDIDOS_PDF\\" + nomdocumento + ".pdf";

            PdfReader reader = new PdfReader(path);

            FileStream fs = null;

            PdfStamper stamp = null;

            Document document = null;

            try

            {

                document = new Document();

                string outputPdf = String.Format("C:\\temp\\{0}.pdf",

                Guid.NewGuid().ToString());

                fs = new FileStream(outputPdf,

                          FileMode.CreateNew,

                          FileAccess.Write);

                stamp = new PdfStamper(reader, fs);

                BaseFont bf =

                  BaseFont.CreateFont(@"c:\windows\fonts\arial.ttf",

                              BaseFont.CP1252, true);

                PdfGState gs = new PdfGState();

                gs.FillOpacity = 0.35F;

                gs.StrokeOpacity = 0.35F;

                for (int nPag = 1; nPag <= reader.NumberOfPages; nPag++)

                {

                    iTextSharp.text.Rectangle tamPagina =

                        reader.GetPageSizeWithRotation(nPag);

                    PdfContentByte over = stamp.GetOverContent(nPag);

                    over.BeginText();

                    WriteTextToDocument(bf,

                                tamPagina,

                                over,

                                gs,

                                "www.devjoker.com");

                    over.EndText();

                }


            }

            finally

            {

                // Garantizamos que aunque falle se cierran los objetos

                // alternativa:usar using

                reader.Close();

                if (stamp != null) stamp.Close();

                if (fs != null) fs.Close();

                if (document != null) document.Close();

            }

           
        }

        private void FrmPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
