using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Http;
using FinalXML;
using FinalXML.Properties;
using System.Data.Entity;
using FinalXML.Informes;
using DevComponents.DotNetBar;
using FinalXML.Administradores;
using FinalXML.Interfaces;
using FinalXML.Entidades;
namespace FinalXML
{
    public partial class Form1 : PlantillaBase
    {

        Herramientas herramientas = new Herramientas();
        public String ticket;
        private FrmDocumento _frmDocumento;
        public DocumentoElectronico _documento;
        public DocumentoRetencion _retencion;
        clsAdmNumeracion AdmNumeracion = new clsAdmNumeracion();
        clsNumeracion Numeracion = new clsNumeracion();

        
        public Form1()
        {
            InitializeComponent();
          
            Load += (s, e) =>
            {

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    using (var ctx = new OpenInvoicePeruDb())
                    {
                        direccionSunatBindingSource.DataSource = ctx.DireccionesSunat.ToList();
                        direccionSunatBindingSource.ResetBindings(false);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            };
            var recursos = herramientas.GetResourcesPath();
            txtRutaCertificado.Text = recursos + "\\Certificado_PiuraTours.pfx";

        }

        private void CargaDatos1()
        {
            txtNroRuc.Text = "20102501293";
            txtUsuarioSol.Text = "WILL2016";
            txtClaveSol.Text = "02870964";
            txtPassCertificado.Text = "546IUYJHGT5";
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
             
        private string ValorSeleccionado()
        {
            var direccionSunat = direccionSunatBindingSource.Current as DireccionSunat;
            return direccionSunat == null ? string.Empty : direccionSunat.Descripcion;
        }
                    
        private void Form1_Load(object sender, EventArgs e)
        {
            CargaDatos1();
        }

        private void btnBrowseCert_Click_2(object sender, EventArgs e)
        {

            try
            {
                if (txtRutaCertificado.Text == "")
                {
                    using (var ofd = new OpenFileDialog())
                    {
                        ofd.Title = Resources.seleccioneCertificado;
                        ofd.Filter = Resources.formatosCertificado;
                        ofd.FilterIndex = 1;
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            txtRutaCertificado.Text = ofd.FileName;
                        }
                    }
                }
                else
                {

                    // MessageBox.Show("La ruta del certificado ya existe..!");
                    // return;
                    if (MessageBox.Show("Estas seguro de querer cargar el certificado..?", "Buscar Certificado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var ofd = new OpenFileDialog())
                        {
                            ofd.Title = Resources.seleccioneCertificado;
                            ofd.Filter = Resources.formatosCertificado;
                            ofd.FilterIndex = 1;
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                txtRutaCertificado.Text = ofd.FileName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_frmDocumento == null)
                {
                    if (string.IsNullOrEmpty(txtNroRuc.Text))
                        _frmDocumento = new FrmDocumento();
                    else
                    {
                        var documento = new DocumentoElectronico
                        {
                            Emisor = { NroDocumento = txtNroRuc.Text, NombreLegal = "Empresa de Servicios Turísticos S.R.L.", NombreComercial="PLAYA COLAN LODGE",
                            Ubigeo="200101",Direccion="Calle Arequipa Nº 978 Piura - Piura - Piura",
                            Departamento="PIURA",Provincia="PIURA",Distrito="PIURA"

                            },
                            FechaEmision = DateTime.Today.ToShortDateString()
                        };
                        _frmDocumento = new FrmDocumento(documento);
                    }
                }
                var rpta = _frmDocumento.ShowDialog(this);

                if (rpta != DialogResult.OK) return;

                txtSource.Text = _frmDocumento.RutaArchivo;
                txtSerieCorrelativo.Text = _frmDocumento.IdDocumento;
                _documento = _frmDocumento._documento2;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            string codigoTipoDoc = "";
            switch (cboTipoDoc.SelectedIndex)
            {
                case 0:
                    codigoTipoDoc = "01";
                    break;
                case 1:
                    codigoTipoDoc = "03";
                    break;
                case 2:
                    codigoTipoDoc = "07";
                    break;
                case 3:
                    codigoTipoDoc = "08";
                    break;

                case 4:
                    codigoTipoDoc = "20";
                    break;
            }
            if (codigoTipoDoc == "")
            {
                MessageBox.Show("Seleccione Tipo de Documento");
                return;
            }


            if (codigoTipoDoc == "01")
            {
               
                if (_documento.Receptor.TipoDocumento == "6")
                {

                   /* FrmFactura2 form = new FrmFactura2("Informes\\DTFactura2.rdlc", _documento);
                    form._documento = _documento;
                    form.ShowDialog();*/

                    FrmTFactura fac = new FrmTFactura("Informes\\TFactura.rdlc", _documento);
                    fac._documento = _documento;
                    fac.ShowDialog();

                }
             


            }
            else
            {
                if (codigoTipoDoc == "03")
                {
                    /*FrmBoletas form = new FrmBoletas("Informes\\DTBoletas.rdlc", _documento);
                    form._documento = _documento;
                    form.ShowDialog();*/

                    FrmTTicket ticket = new FrmTTicket("Informes\\TTicket.rdlc", _documento);
                    ticket._documento = _documento;
                    ticket.ShowDialog();

                    /*Erwin erwin = new Erwin("Informes\\Prueba.rdlc", _documento);
                    erwin._documento = _documento;
                    erwin.ShowDialog();*/
                }
                else
                {

                    if (codigoTipoDoc == "07")//NC
                    {

                        FrmNC form = new FrmNC("Informes\\DTNC.rdlc", _documento);
                        form._documento = _documento;
                        form.ShowDialog();
                    }
                    else
                    {
                        if (codigoTipoDoc == "08")//ND
                        {

                            FrmND form = new FrmND("Informes\\DTND.rdlc", _documento);
                            form._documento = _documento;
                            form.ShowDialog();
                        }
                        else
                        {
                            if (codigoTipoDoc == "20") //Retención
                            {
                                FrmRetencion form = new FrmRetencion("Informes\\DTRetencion.rdlc", _documento);
                                form._documento = _documento;
                                form.ShowDialog();
                            }
                        }
                    }
                }

            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string codigoTipoDoc;
                switch (cboTipoDoc.SelectedIndex)
                {
                    case 0:
                        codigoTipoDoc = "01";
                        break;
                    case 1:
                        codigoTipoDoc = "03";
                        break;
                    case 2:
                        codigoTipoDoc = "07";
                        break;
                    case 3:
                        codigoTipoDoc = "08";
                        break;
                    case 4:
                        codigoTipoDoc = "20";
                        break;
                    case 5:
                        codigoTipoDoc = "40";
                        break;
                    case 6:
                        codigoTipoDoc = "RC";
                        break;
                    case 7:
                        codigoTipoDoc = "RA";
                        break;
                    default:
                        codigoTipoDoc = "01";
                        break;
                }
                if (cboTipoDoc.SelectedIndex == -1)
                {

                    MessageBox.Show("Seleccione Tipo de documento");
                    throw new InvalidOperationException("Seleccione Tipo de documento");
                    
                }
               /* if (_documento.TipoDocumento != codigoTipoDoc) {
                    MessageBox.Show("Seleccione Tipo de Documento Igual al Documento Generado..!");
                    throw new InvalidOperationException("Seleccione Tipo de Documento Igual al Documento Generado..!");
                }*/
                if (string.IsNullOrEmpty(txtSerieCorrelativo.Text))
                    throw new InvalidOperationException("La Serie y el Correlativo no pueden estar vacíos");

                var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(txtSource.Text));

                var firmadoRequest = new FirmadoRequest
                {
                    TramaXmlSinFirma = tramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                    PasswordCertificado = txtPassCertificado.Text,
                    UnSoloNodoExtension = rbRetenciones.Checked || rbResumen.Checked

                };


                FirmarController enviar = new FirmarController();

                var respuestaFirmado = enviar.FirmadoResponse(firmadoRequest);

                if (!respuestaFirmado.Exito)
                    throw new ApplicationException(respuestaFirmado.MensajeError);



                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = txtNroRuc.Text,
                    UsuarioSol = txtUsuarioSol.Text,
                    ClaveSol = txtClaveSol.Text,
                    EndPointUrl = ValorSeleccionado(),
                    //https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService //RETENCION
                    IdDocumento = txtSerieCorrelativo.Text,
                    TipoDocumento = codigoTipoDoc,
                    TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                };
                


                // RespuestaComun respuestaEnvio;
                var respuestaEnvio = new EnviarDocumentoResponse();
                var apiMetodo = rbResumen.Checked ? "EnviarResumen" : "EnviarDocumento";

                if (!rbResumen.Checked)
                {

                    if (apiMetodo == "EnviarDocumento")
                    {
                        EnviarDocumentoController enviarDoc = new EnviarDocumentoController();
                        respuestaEnvio = enviarDoc.EnviarDocumentoResponse(enviarDocumentoRequest);

                    }
                    // var rpta =new EnviarDocumentoResponse() ;//(EnviarDocumentoResponse)respuestaEnvio;
                    var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                    txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{rpta.MensajeRespuesta} siendo las {DateTime.Now}";
                    try
                    {
                        //ACTUALIZA CORRELATIVO SI EL DOCUMENTO FUE ACEPTADO
                        if (_documento.Items != null && _documento.Receptor.NroDocumento != "")
                        {
                            clsNumeracion busnum = new clsNumeracion();
                            busnum = AdmNumeracion.BuscaNumeracion(_documento.TipoDocumento);
                            Numeracion.TipoDocumento = Convert.ToString(_documento.TipoDocumento);
                            Numeracion.Numeracion = busnum.Numeracion + 1;
                            if (!AdmNumeracion.ActualizaNumeracion(Numeracion))
                            {
                                MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                            }
                        }
                        if (rpta.Exito && !string.IsNullOrEmpty(rpta.TramaZipCdr))
                        {
                            File.WriteAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml",
                                Convert.FromBase64String(respuestaFirmado.TramaXmlFirmado));

                            File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip",
                                Convert.FromBase64String(rpta.TramaZipCdr));
                            _documento.FirmaDigital = respuestaFirmado.ValorFirma;

                            
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (apiMetodo == "EnviarResumen")
                    {
                        EnviarResumenController enviaResumen = new EnviarResumenController();
                        respuestaEnvio = enviaResumen.EnviarResumenResponse(enviarDocumentoRequest);

                    }

                    var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                    txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{rpta.NroTicket}";
                    if (rpta.Exito) {
                        if (codigoTipoDoc == "RA")
                        {
                            clsNumeracion busnum = new clsNumeracion();
                            busnum = AdmNumeracion.BuscaNumeracion(codigoTipoDoc);
                            Numeracion.TipoDocumento = Convert.ToString(codigoTipoDoc);
                            Numeracion.Numeracion = busnum.Numeracion + 1;
                            if (!AdmNumeracion.ActualizaNumeracion(Numeracion))
                            {
                                MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                            }
                        }
                    }
                }

                if (!respuestaEnvio.Exito)
                    throw new ApplicationException(respuestaEnvio.MensajeError);


               
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnGetStatus_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var frm = new FrmTicket())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    if (string.IsNullOrEmpty(frm.txtNroTicket.Text)) return;


                    var consultaTicketRequest = new ConsultaTicketRequest
                    {
                        Ruc = txtNroRuc.Text,
                        UsuarioSol = txtUsuarioSol.Text,
                        ClaveSol = txtClaveSol.Text,
                        EndPointUrl = ValorSeleccionado(),//"https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService",
                        IdDocumento = txtSerieCorrelativo.Text,
                        NroTicket = frm.txtNroTicket.Text
                    };
                    var respuestaEnvio = new EnviarDocumentoResponse();
                    ConsultarTicket ConsultaTiket = new ConsultarTicket();
                    respuestaEnvio = ConsultaTiket.EnviarDocumentoResponse(consultaTicketRequest);

                    if (!respuestaEnvio.Exito)
                        throw new ApplicationException(respuestaEnvio.MensajeError);

                    txtResult.Text = $"{Resources.procesoCorrecto}{Environment.NewLine}{respuestaEnvio.MensajeRespuesta}";

                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
