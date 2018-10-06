using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;

namespace FinalXML.Informes
{
    public partial class FrmRetencion : Form
    {
        public DocumentoElectronico _documento;
        private string rptact;
        private object lst;
        public object empresa;
        public object general;
        public object receptor;
        public object otros;
        public object item;
        public object retencion;
    
        public DocumentoElectronico _idcodumento;
        public FrmRetencion(string nombrereporte, DocumentoElectronico lista)
        {
            InitializeComponent();
            List<Contribuyente> Emisor = new List<Contribuyente>();
            ClsDatosReportes cabecera = new ClsDatosReportes();
            List<ClsDatosReportes> valores = new List<ClsDatosReportes>();
            List<Contribuyente> Receptor = new List<Contribuyente>();
            List<DocumentoRetencion> Retencion = new List<DocumentoRetencion>();

           
            if (lista.DocumentoRetencion.Moneda == "PEN")
            {
                cabecera.MonedaLetra = "SOLES";
                cabecera.Moneda = "S/";
            }
            else
            {
                if (lista.DocumentoRetencion.Moneda == "USD")
                {
                    cabecera.MonedaLetra = "DOLARES AMERICANOS";
                    cabecera.Moneda = "$";
                }
                else
                {
                    if (lista.DocumentoRetencion.Moneda == "EUR")
                    {
                        cabecera.MonedaLetra = "EUROS";
                        cabecera.Moneda = "€";
                    }
                }
            }
            cabecera.IdDocumento = lista.DocumentoRetencion.IdDocumento;
            cabecera.FechaEmision = lista.DocumentoRetencion.FechaEmision;
            cabecera.MontoEnLetras = lista.MontoEnLetras;
            valores.Add(cabecera);
            Emisor.Add(lista.DocumentoRetencion.Emisor);
            Receptor.Add(lista.DocumentoRetencion.Receptor);
            Retencion.Add (lista.DocumentoRetencion);
          

            this.rptact = nombrereporte;           
            this.empresa = Emisor;
            this.general = valores;
            this.receptor = Receptor;
            this.otros = valores;
            this.item = lista.DocumentoRetencion.DocumentosRelacionados;
            retencion = Retencion;
           
        }

        private void FrmRetencion_Load(object sender, EventArgs e)
        {

            //NUEVO
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //this.reportViewer1.LocalReport.ReportPath = rptact;
            reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.DTRetencion.rdlc";
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
            ReportDataSource datos6 = new ReportDataSource();
            datos6.Name = "Items";
            datos6.Value = item;
            ReportDataSource datos7 = new ReportDataSource();
            datos7.Name = "Retencion";
            datos7.Value = retencion;


            /*FIRMA PDF*/
            var nomdocumento = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento;

            String datosAdicionales_CDB = "";
            String CodigoCertificado = "";
            String firmadig = "";
            datosAdicionales_CDB = _documento.Emisor.NroDocumento + "|" + _documento.TipoDocumento + "|" + _documento.IdDocumento + "|" + _documento.TotalIgv + "|" + _documento.TotalVenta + "|"
                                 + _documento.FechaEmision + "|" + _documento.Receptor.TipoDocumento + "|" + _documento.Receptor.NroDocumento;
            CodigoCertificado = datosAdicionales_CDB + "|" + firmadig;
            BarcodePDF417 codigobarras = new BarcodePDF417();
            codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
            codigobarras.ErrorLevel = 5;
            codigobarras.YHeight = 6f;
            codigobarras.SetText(CodigoCertificado);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            //bm.Save(@"C:\DOCUMENTOS ELECTRONICOS\CERTIFIK\QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bm.Save(@"QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            //LogoEmp = CargarImagen(@"QR\" + nomdocumento + ".jpeg");



            /*FIN FIRMA*/
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datos);
            this.reportViewer1.LocalReport.DataSources.Add(datos2);
            this.reportViewer1.LocalReport.DataSources.Add(datos3);
            this.reportViewer1.LocalReport.DataSources.Add(datos4);
            this.reportViewer1.LocalReport.DataSources.Add(datos5);
            this.reportViewer1.LocalReport.DataSources.Add(datos6);
            this.reportViewer1.LocalReport.DataSources.Add(datos7);


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

            using (FileStream fs = new FileStream(@"RETENCION_PDF\\" + nomdocumento + ".pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
