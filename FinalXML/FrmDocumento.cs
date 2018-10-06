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
using FinalXML.Informes;
using DevComponents.DotNetBar;
using FinalXML.Administradores;
using FinalXML.Entidades;
using System.Text.RegularExpressions;
using Tesseract;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace FinalXML
{
    public partial class FrmDocumento : PlantillaBase
    {

        #region Variables
        IntRange red = new IntRange(0, 255);
        IntRange green = new IntRange(0, 255);
        IntRange blue = new IntRange(0, 255);
        SunatRuc MyInfoSunat;
        Reniec MyInfoReniec;
        string Texto = string.Empty;
        #endregion
        #region Variables Privadas
        private readonly DocumentoElectronico _documento;
        public DocumentoElectronico _documento2;
        #endregion
        public string TramaXmlSinFirma { get; set; }
        #region Propiedades
        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        #endregion
        public string numeracion;
        Conversion ConvertLetras = new Conversion();
        ConvertThis ConvertLetras2 = new ConvertThis();
        clsAdmNumeracion AdmNumera = new clsAdmNumeracion();
        clsNumeracion Numera = new clsNumeracion();


        public Exportacion expor;
        private const string FormatoFecha = "yyyy-MM-dd";


        public FrmDocumento()
        {
            InitializeComponent();
            Numera = AdmNumera.BuscaNumeracionFac();
            string str = Convert.ToString(Numera.Numeracion);
            char pad = '0';
           
            _documento = new DocumentoElectronico
            {
                FechaEmision = DateTime.Today.ToShortDateString(),
                //IdDocumento = Numera.Serie+ "-" + str.PadLeft(8, pad)
            };
            Inicializar();
            if (_documento.Receptor != null)
            {
                txtNroDocRec.Text = _documento.Receptor.NroDocumento;
                txtNombreLegalRec.Text = _documento.Receptor.NombreLegal;
                txtDirRec.Text = _documento.Receptor.Direccion;
            }
        }
        private void Inicializar()
        {
            documentoElectronicoBindingSource.DataSource = _documento;
            documentoElectronicoBindingSource.ResetBindings(false);

            emisorBindingSource.DataSource = _documento.Emisor;
            emisorBindingSource.ResetBindings(false);

            receptorBindingSource.DataSource = _documento.Receptor;
            receptorBindingSource.ResetBindings(false);
        }
        private void FrmDocumento_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoBindingSource.DataSource = ctx.TipoDocumentos.ToList();
                    tipoDocumentoBindingSource.ResetBindings(false);

                    tipoDocumentoContribuyenteBindingSource.DataSource = ctx.TipoDocumentoContribuyentes.ToList();
                    tipoDocumentoContribuyenteBindingSource.ResetBindings(false);

                    tipoDocumentoAnticipoBindingSource.DataSource = ctx.TipoDocumentoAnticipos.ToList();
                    tipoDocumentoAnticipoBindingSource.ResetBindings(false);

                    tipoOperacionBindingSource.DataSource = ctx.TipoOperaciones.ToList();
                    tipoOperacionBindingSource.ResetBindings(false);

                    monedaBindingSource.DataSource = ctx.Monedas.ToList();
                    monedaBindingSource.ResetBindings(false);
                }

                if (_documento.TipoDocumento != null)
                {
                    cboTipoDoc.SelectedValue = _documento.TipoDocumento;
                    String dato;
                    dato = Convert.ToString(cboTipoDoc.SelectedValue);
                    Numera = AdmNumera.BuscaNumeracion(Convert.ToString(dato));
                    string str = Convert.ToString(Numera.Numeracion);
                    char pad = '0';
                    numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                    textBox17.Text = numeracion.ToString();
                    _documento.IdDocumento = numeracion;

                  
                }
                else {
                    cboTipoDoc.SelectedIndex = -1;
                }
               
                comboBox1.SelectedIndex = -1;
                //cboTipoDocRec.SelectedIndex = -1;
                cboTipoDocRec2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
                txtCorrelativo3.Text = "R001-0001";
                cboMoneda2.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            #region CARGAR RUC
            try
            {
                CargarImagenSunat();
                LeerCaptchaSunat();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }

        public FrmDocumento(DocumentoElectronico documento)
        {
            InitializeComponent();
            _documento = documento;              
            txtSerie.Text = "B002";
            txtCorrel.Text = "1";
            CargaNumDocBaja();
            Inicializar();
            
        }

        private void CalcularTotales()
        {
            // Realizamos los cálculos respectivos.
            _documento.TotalIgv = _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);

            _documento.Gravadas = _documento.Items
                 .Where(d => d.TipoImpuesto.StartsWith("1"))
                 .Sum(d => d.SubTotalVenta);
           //_documento.Gravadas = _documento.SubTotalVenta;

            _documento.Exoneradas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma);

            _documento.Gratuitas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("21"))
                .Sum(d => d.Suma);
          
            // Cuando existe ISC se debe recalcular el IGV.
            if (_documento.TotalIsc > 0)
            {
                _documento.TotalIgv = (_documento.Gravadas + _documento.TotalIsc) * _documento.CalculoIgv;
                // Se recalcula nuevamente el Total de Venta.
            }

             _documento.TotalVenta = _documento.Gravadas + _documento.Exoneradas + _documento.Inafectas +
                                      _documento.TotalIgv + _documento.TotalIsc + _documento.TotalOtrosTributos;
              _documento.MontoEnLetras= ConvertLetras.enletras(_documento.TotalVenta.ToString());
           

            montoEnLetrasTextBox.Text =_documento.MontoEnLetras;
            if (_documento.CalculoIgv > 0)
            {
                _documento.SubTotalVenta = _documento.TotalVenta - _documento.TotalIgv;
            }
            else {
                _documento.SubTotalVenta = _documento.TotalVenta;
            }
            documentoElectronicoBindingSource.ResetBindings(false);

        }

        private void toolGenerar_Click(object sender, EventArgs e)
        {

            try
            {
                if (cboTipoDoc.SelectedIndex==-1) {
                    MessageBox.Show("Seleccione un tipo de Documento Factura/Boleta");
                    return;
                }
                if (cboTipoDocRec.SelectedIndex==-1)
                {
                    MessageBox.Show("Seleccione un tipo de Documento para el Cliente..!");
                    return;
                }
               
                if (txtNroDocRec.Text=="") {
                    MessageBox.Show("Ingrese Tipo Documento Cliente");
                    txtNroDocRec.Focus();
                    return;
                }
                if (txtNombreLegalRec.Text=="") {
                    MessageBox.Show("Ingrese Nombre Legal Cliente");
                    txtNombreLegalRec.Focus();
                    return;
                }
                if (cboTipoDocRec.SelectedValue.ToString()=="1") {
                    cboTipoDocRec.MaxLength = 8;
                    if ((txtNroDocRec.Text.Length)<8) {
                        MessageBox.Show("Ingrese DNI Correcto");
                        txtNroDocRec.Focus();
                        return;
                    }
                }
                if (cboTipoDocRec.SelectedValue.ToString() == "6")
                {
                    cboTipoDocRec.MaxLength = 11;
                    if ((txtNroDocRec.Text.Length) < 11)
                    {
                        MessageBox.Show("Ingrese RUC Correcto");
                        txtNroDocRec.Focus();
                        return;
                    }
                }

                if (txtDirRec.Text=="") {
                    MessageBox.Show("Ingrese Dirección de Cliente..!");
                    txtDirRec.Focus();
                    return;
                }
                if (textBox17.Text == "") {
                    MessageBox.Show("Ingrese Correlativo del Documento..!");
                    textBox17.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                documentoElectronicoBindingSource.EndEdit();
                totalVentaTextBox.Focus();
               
                switch (_documento.TipoDocumento)
                {
                    case "07":
                        //NotaCredito
                        var notaCredito = GeneradorXML.GenerarCreditNote(_documento);
                        var serializador1 = new Serializador();
                        TramaXmlSinFirma = serializador1.GenerarXml(notaCredito);
                        break;
                    case "08":
                        //GenerarNotaDebito
                        var notaDebito = GeneradorXML.GenerarDebitNote(_documento);
                        var serializador2 = new Serializador();
                        TramaXmlSinFirma = serializador2.GenerarXml(notaDebito);
                        break;
                    default:
                       var invoice = GeneradorXML.GenerarInvoice(_documento);
                        var serializador3 = new Serializador();
                        TramaXmlSinFirma = serializador3.GenerarXml(invoice);
                        break;
                }


               
                RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Documentos\\" +
                $"{_documento.IdDocumento}.xml");
                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String( TramaXmlSinFirma));

               

                IdDocumento = _documento.IdDocumento;
               
               _documento2 = _documento;
                DialogResult = DialogResult.OK;

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

       
        private void btnGuia_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var datosGuia = _documento.DatosGuiaTransportista ?? new DatosGuia();

                using (var frm = new FrmDatosGuia(datosGuia))
                {
                    if (frm.ShowDialog(this) != DialogResult.OK) return;

                    _documento.DatosGuiaTransportista = datosGuia;
                    documentoElectronicoBindingSource.ResetBindings(false);
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
        }
      
      
        private static Contribuyente CrearEmisor()
        {
            return new Contribuyente
            {
                NroDocumento = "20102501293",
                TipoDocumento = "6",
                Direccion = "Calle Arequipa Nº 978 Piura - Piura - Piura",
                Departamento = "PIURA",
                Provincia = "PIURA",
                Distrito = "PIURA",
                NombreLegal = "Empresa de Servicios Turísticos S.R.L.",
                NombreComercial = "PLAYA COLAN LODGE",
                Ubigeo = "200101"

            };
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dglista.Rows.Count > 0)
                {
                    var correl = txtCorrel.Text;
                    var documentoResumenDiario = new ResumenDiario
                    {

                        IdDocumento = string.Format("RC-{0:yyyyMMdd}-" + correl, DateTime.Today),
                        FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                        FechaReferencia = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
                        Emisor = CrearEmisor(),
                        Resumenes = new List<GrupoResumen>()
                    };
                    var nomdoc = "RC-" + string.Format("{0:yyyyMMdd}-" + correl, DateTime.Today);
                    foreach (DataGridViewRow row in dglista.Rows)
                    {
                        GrupoResumen resu = new GrupoResumen();
                        // documentoResumenDiario.
                        resu.Id = Convert.ToInt32(row.Cells[0].Value);
                        resu.CorrelativoInicio = Convert.ToInt32(row.Cells[3].Value);
                        resu.CorrelativoFin = Convert.ToInt32(row.Cells[4].Value);
                        resu.Moneda = Convert.ToString(row.Cells[5].Value);
                        resu.TotalVenta = Convert.ToDecimal(row.Cells[6].Value);
                        resu.TotalIgv = Convert.ToDecimal(row.Cells[7].Value);
                        resu.Gravadas = Convert.ToDecimal(row.Cells[8].Value);
                        resu.Exoneradas = 0;
                        resu.Exportacion = 0;
                        resu.TipoDocumento = Convert.ToString(row.Cells[1].Value);
                        resu.Serie = Convert.ToString(row.Cells[2].Value);
                        documentoResumenDiario.Resumenes.Add(resu);
                    }
                    var invoice = GeneradorXML.GenerarSummaryDocuments(documentoResumenDiario);
                    var serializador3 = new Serializador();
                    TramaXmlSinFirma = serializador3.GenerarXml(invoice);
                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{documentoResumenDiario.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));

                    IdDocumento = nomdoc;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No hay Registros para Generar Documento");
                    return;

                }

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

        private void cboTipoDoc_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            String dato;
            dato = Convert.ToString(cboTipoDoc.SelectedValue);
            Numera=AdmNumera.BuscaNumeracion(Convert.ToString(dato));         


            string str = Convert.ToString(Numera.Numeracion); 
            char pad = '0';

            if (Convert.ToDouble(dato) == 01)
            {
             
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
               
            }
            else if (Convert.ToDouble(dato) == 03)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
            }
            else if (Convert.ToDouble(dato) == 07)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
            }
            else if (Convert.ToDouble(dato) == 08)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
            }
            _documento.IdDocumento = numeracion.ToString();
            textBox17.Text = numeracion.ToString();
        }

        Int32 counter2 = 1;       

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dglista2.Rows.Count > 0)
                {
                    var correl = txtcorrelativo2.Text;
                    var documentoBaja = new ComunicacionBaja
                    {

                        IdDocumento = string.Format("RA-{0:yyyyMMdd}-" + correl, DateTime.Today),
                        FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                        FechaReferencia = DateTime.Today.ToString("yyyy-MM-dd"),//DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
                        Emisor = CrearEmisor(),
                        Bajas = new List<DocumentoBaja>()
                      
                    };
                    var nomdoc = "RA-"+string.Format("{0:yyyyMMdd}-" + correl, DateTime.Today);
                    foreach (DataGridViewRow row in dglista2.Rows)
                    {
                       DocumentoBaja baja = new DocumentoBaja();
                        baja.Id = Convert.ToInt32(row.Cells[0].Value);
                        baja.TipoDocumento = Convert.ToString(row.Cells[1].Value);
                        baja.Serie = Convert.ToString(row.Cells[2].Value); 
                        baja.Correlativo = Convert.ToString(row.Cells[3].Value); 
                        baja.MotivoBaja = Convert.ToString(row.Cells[4].Value); 
                       
                         documentoBaja.Bajas.Add(baja);
                       
                    }
                    var invoice = GeneradorXML.GenerarVoidedDocuments(documentoBaja);
                    var serializador3 = new Serializador();
                    TramaXmlSinFirma = serializador3.GenerarXml(invoice);
                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{documentoBaja.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));
                    IdDocumento = nomdoc;

                    DialogResult = DialogResult.OK;
                }
                else {
                    MessageBox.Show("No hay Registros para Generar Documento");
                    return;
                }

             

               

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
        
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try {
                if (dgreten.Rows.Count > 0)
                {
                                      
                    _documento.DocumentoRetencion.Receptor.NroDocumento = txtNroCliente.Text;
                    _documento.DocumentoRetencion.Receptor.TipoDocumento = cboTipoDocRec2.SelectedValue.ToString();
                    _documento.DocumentoRetencion.Receptor.NombreLegal = txtNomCliente.Text;
                    _documento.DocumentoRetencion.IdDocumento = txtCorrelativo3.Text;
                    _documento.DocumentoRetencion.FechaEmision = DateTime.Today.ToString(FormatoFecha);
                    _documento.DocumentoRetencion.Moneda = cboMoneda2.SelectedValue.ToString();
                    _documento.DocumentoRetencion.RegimenRetencion = "01";
                    _documento.DocumentoRetencion.TasaRetencion = 3;
                  
                    
                    Decimal ImporteRetenido = 0,ImportePagado=0;
                    foreach (DataGridViewRow row in dgreten.Rows)
                    {
                        ItemRetencion retencion = new ItemRetencion();
                        retencion.NroDocumento = row.Cells[1].Value.ToString();
                        retencion.TipoDocumento = "01";
                        retencion.MonedaDocumentoRelacionado = row.Cells[3].Value.ToString();
                        retencion.FechaEmision = DateTime.Today.ToString(FormatoFecha);
                        retencion.ImporteTotal =Convert.ToDecimal( row.Cells[4].Value);
                        retencion.FechaPago = row.Cells[2].Value.ToString();
                        retencion.NumeroPago = Convert.ToInt32(row.Cells[0].Value);
                        retencion.ImporteSinRetencion = Convert.ToDecimal(row.Cells[4].Value) - Convert.ToDecimal(row.Cells[5].Value);
                        retencion.ImporteRetenido = Convert.ToDecimal(row.Cells[5].Value) ;
                        retencion.FechaRetencion = row.Cells[2].Value.ToString();
                        retencion.ImporteTotalNeto = Convert.ToDecimal(row.Cells[4].Value); ;
                       // retencion.TipoCambio = 3.41m;
                        //retencion.FechaTipoCambio = DateTime.Today.ToString(FormatoFecha);
                        ImporteRetenido += Convert.ToDecimal(row.Cells[5].Value);
                        ImportePagado= Convert.ToDecimal(row.Cells[4].Value);
                        _documento.DocumentoRetencion.DocumentosRelacionados.Add(retencion);
                        
                        
                        //documentoReten.DocumentosRelacionados.Add(retencion);

                    }
                    _documento.DocumentoRetencion.ImporteTotalPagado = ImportePagado;
                    _documento.DocumentoRetencion.ImporteTotalRetenido = ImporteRetenido;
                    _documento.DocumentoRetencion.Emisor = CrearEmisor();                    
                    _documento.MontoEnLetras = ConvertLetras.enletras(_documento.DocumentoRetencion.ImporteTotalRetenido.ToString());
                   
                    var RetenDoc = GeneradorXML.GenerarRetention(_documento.DocumentoRetencion);
                    var serializador4 = new Serializador();
                    TramaXmlSinFirma = serializador4.GenerarXml(RetenDoc);
                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{_documento.DocumentoRetencion.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(TramaXmlSinFirma));
                    IdDocumento = _documento.DocumentoRetencion.IdDocumento;
                    _documento2 = _documento;
                    DialogResult = DialogResult.OK;


                }
                else
                {
                    MessageBox.Show("No hay Registros para Generar Documento");

                }

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
        Int32 j = 1;     
        private void txtMontoPago_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

     
        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            double dato;

            dato = Convert.ToDouble(comboBox1.SelectedValue);
            if (dato == 01)
            {
                //MessageBox.Show(dato.ToString());
                numeracion = "F002";
            }
            else if (dato == 03)
            {
                numeracion = "B002";
            }
            textBox7.Text = numeracion;
        }

      
        Int32 counter = 1;
              
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (tbPaginas.SelectedIndex)
                {
                    case 0:
                        var detalle = new DetalleDocumento();

                        using (var frm = new FrmDetalleDocumento(detalle, _documento))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Items.Add(detalle);

                            CalcularTotales();
                        }
                        break;
                    case 1:
                        var datoAdicional = new DatoAdicional();
                        using (var frm = new FrmDatosAdicionales(datoAdicional))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.DatoAdicionales.Add(datoAdicional);
                        }
                        break;
                    case 2:
                        var documentoRelacionado = new DocumentoRelacionado();
                        using (var frm = new FrmDocumentoRelacionado(documentoRelacionado))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Relacionados.Add(documentoRelacionado);
                        }
                        break;
                    case 3:
                        var discrepancia = new Discrepancia();
                        using (var frm = new FrmDiscrepancia(discrepancia, _documento.TipoDocumento))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Discrepancias.Add(discrepancia);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var registro = detallesBindingSource.Current as DetalleDocumento;
                if (registro == null) throw new ArgumentNullException(nameof(registro));

                var copia = new DetalleDocumento
                {
                    Id = registro.Id,
                    Cantidad = registro.Cantidad,
                    CodigoItem = registro.CodigoItem,
                    Descripcion = registro.Descripcion,
                    PrecioUnitario = registro.PrecioUnitario,
                    PrecioReferencial = registro.PrecioReferencial,
                    UnidadMedida = registro.UnidadMedida,
                    Impuesto = registro.Impuesto,
                    ImpuestoSelectivo = registro.ImpuestoSelectivo,
                    TipoImpuesto = registro.TipoImpuesto,
                    TipoPrecio = registro.TipoPrecio,
                    TotalVenta = registro.TotalVenta,
                    Suma = registro.Suma,
                    OtroImpuesto = registro.OtroImpuesto
                };

                copia.Id = copia.Id + 1;
                _documento.Items.Add(copia);

                CalcularTotales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (tbPaginas.SelectedIndex)
                {
                    case 0:
                        var registro = detallesBindingSource.Current as DetalleDocumento;
                        if (registro == null) return;

                        _documento.Items.Remove(registro);

                        CalcularTotales();
                        break;
                    case 1:
                        var docAdicional = datoAdicionalesBindingSource.Current as DatoAdicional;
                        if (docAdicional == null) return;

                        _documento.DatoAdicionales.Remove(docAdicional);
                        break;
                    case 2:
                        var docRelacionado = relacionadosBindingSource.Current as DocumentoRelacionado;
                        if (docRelacionado == null) return;

                        _documento.Relacionados.Remove(docRelacionado);
                        break;
                    case 3:
                        var discrepancia = discrepanciasBindingSource.Current as Discrepancia;
                        if (discrepancia == null) return;

                        _documento.Discrepancias.Remove(discrepancia);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCalcDetraccion_Click_1(object sender, EventArgs e)
        {
            //_documento.MontoDetraccion = _documento.Gravadas * _documento.CalculoDetraccion;
            _documento.MontoDetraccion = _documento.TotalVenta * _documento.CalculoDetraccion;

            documentoElectronicoBindingSource.ResetBindings(false);
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            if (txtCorrel.Text == "")
            {
                MessageBox.Show("Ingrese Correlativo para el Documento");
                txtCorrel.Text = "001";
                txtCorrel.Focus();
                return;
            }
            if (txtDocInicio.Text == "")
            {
                MessageBox.Show("Ingrese Documento Inicio");
                txtDocInicio.Focus();
                return;
            }
            if (txtDocFin.Text == "")
            {
                MessageBox.Show("Ingrese Documento Final");
                txtDocFin.Focus();
                return;
            }
            if (txtTotVenta.Text == "")
            {
                MessageBox.Show("Ingrese Total Venta");
                txtTotVenta.Focus();
                return;
            }
            if (txtIGV.Text == "")
            {
                MessageBox.Show("Ingrese IGV");
                txtIGV.Focus();
                return;
            }
            if (txtTotVentaGraba.Text == "")
            {
                MessageBox.Show("Ingrese Total Ventas Grabadas");
                txtTotVentaGraba.Focus();
                return;
            }
            dglista.Rows.Add(counter, "03", txtSerie.Text, txtDocInicio.Text, txtDocFin.Text, cbmoneda.SelectedValue, txtTotVenta.Text,
                txtIGV.Text, txtTotVentaGraba.Text);
            counter++;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (dglista.Rows.Count > 0)
            {
                dglista.Rows.RemoveAt(dglista.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Ingrese Serie");
                textBox7.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese Numeración");
                textBox1.Focus();
                return;
            }
            if (txtmotivo.Text == "")
            {
                MessageBox.Show("Ingrese Motivo de Anulación");
                txtmotivo.Focus();
                return;
            }

            dglista2.Rows.Add(counter2, comboBox1.SelectedValue, textBox7.Text, textBox1.Text, txtmotivo.Text);
            counter2++;
            textBox1.Text = "";
            txtmotivo.Text = "";
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (dglista2.Rows.Count > 0)
            {
                dglista2.Rows.RemoveAt(dglista2.CurrentRow.Index);

            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "")
            {
                MessageBox.Show("Ingrese Numeración");
                txtNum.Focus();
                return;
            }
            if (txtMontoPago.Text == "")
            {
                MessageBox.Show("Ingrese Monto del Pago");
                txtMontoPago.Focus();
                return;
            }
            Double reten;
            reten = Convert.ToDouble(txtMontoPago.Text) * Convert.ToDouble(txtValorReten.Text);
            if (dgreten.Rows.Count == 0)
            {
                j = 1;
            }
            dgreten.Rows.Add(j, txtNum.Text, dtpFecha3.Text.ToString(), cboMoneda2.SelectedValue.ToString(), Math.Round(Convert.ToDouble(txtMontoPago.Text), 2), Math.Round(Convert.ToDouble(reten), 2));// DateTime.Today.ToString("yyyy-MM-dd")
            j++;
            txtNum.Text = "";
            txtMontoPago.Text = "";
            txtNum.Focus();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {

            if (dgreten.Rows.Count > 0)
            {
                dgreten.Rows.RemoveAt(dgreten.CurrentRow.Index);

            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            
            cboTipoDocRec.SelectedIndex = -1;
            txtNroDocRec.Text = "";
            txtNombreLegalRec.Text = "";
            txtDirRec.Text = "";
            montoPercepcionTextBox.Text = "";
            montoDetraccionTextBox.Text = "";
            montoEnLetrasTextBox.Text = "";
            descuentoGlobalTextBox.Text = "";
            _documento.Items.Clear();
            _documento.Relacionados.Clear();
            _documento.DatoAdicionales.Clear();
            _documento.Discrepancias.Clear();
            _documento.Receptor.NroDocumento = "";
            _documento.Receptor.NombreLegal = "";
            _documento.Receptor.NombreComercial = "";
            _documento.Receptor.Direccion = "";
            dgvDetalle.Rows.Clear();
            datoAdicionalesDataGridView.Rows.Clear();
            relacionadosDataGridView.Rows.Clear();
            discrepanciasDataGridView.Rows.Clear();
            CalcularTotales();
            dglista.Rows.Clear();
            dglista2.Rows.Clear();
           
           

            // _documento.TipoDocumento = "";
            // _documento.IdDocumento = "";
        }

        #region metodos Sunat
        private void CargarImagenSunat()
        {
            try
            {
                if (MyInfoSunat == null)
                    MyInfoSunat = new SunatRuc();
                this.pictureCapcha.Image = MyInfoSunat.GetCapcha;
                LeerCaptchaSunat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LeerCaptchaSunat()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var image = new System.Drawing.Bitmap(pictureCapcha.Image))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                            string CaptchaTexto = page.GetText();
                            char[] eliminarChars = { '\n', ' ' };
                            CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars);
                            CaptchaTexto = CaptchaTexto.Replace(" ", string.Empty);
                            CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z]+", string.Empty);
                            if (CaptchaTexto != string.Empty & CaptchaTexto.Length == 4)
                                txttexto.Text = CaptchaTexto.ToUpper();
                            else
                                CargarImagenSunat();
                        }
                    }
                }

            }

        }

        private void LeerDatos()
        {
            //llamamos a los metodos de la libreria ConsultaReniec...
            MyInfoSunat.GetInfo(this.txtNroDocRec.Text, this.txttexto.Text);
            switch (MyInfoSunat.GetResul)
            {
                case SunatRuc.Resul.Ok:
                    limpiarSunat();
                    txtNroDocRec.Text = MyInfoSunat.Ruc;
                    txtDirRec.Text = MyInfoSunat.Direcion;
                    txtNombreLegalRec.Text = MyInfoSunat.RazonSocial;

                    //ASIGNA DATOS AL CONTRIBUYENTE
                    _documento.Receptor.NroDocumento = MyInfoSunat.Ruc;
                    _documento.Receptor.NombreLegal = MyInfoSunat.RazonSocial;
                    _documento.Receptor.Direccion = MyInfoSunat.Direcion;


                    break;
                case SunatRuc.Resul.NoResul:
                    limpiarSunat();
                    MessageBox.Show("No Existe RUC");
                    break;
                case SunatRuc.Resul.ErrorCapcha:
                    limpiarSunat();
                    MessageBox.Show("Ingrese imagen correctamente");
                    break;
                default:
                    MessageBox.Show("Error Desconocido");
                    break;
            }
            CargarImagenSunat();
        }

      
        private void limpiarSunat()
        {
            txtNroDocRec.Text = string.Empty;
            txtNombreLegalRec.Text = string.Empty;
            txtDirRec.Text = string.Empty;
            txttexto.Text = string.Empty;
        }
        private void CargaRUC()
        {
            if (txtNroDocRec.TextLength < 11)
            {
                MessageBox.Show("Ingrese RUC Correcto");
                return;
            }
            else
            {
                if (txtNroDocRec.TextLength == 11)
                {
                    LeerDatos();
                }
            }
        }
        #endregion

        private void txtNroDocRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    //aqui codigo
                    if (cboTipoDocRec.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione Tipo de Documento");
                        return;
                    }
                    else
                    {
                        if (cboTipoDocRec.SelectedIndex == 3)
                        {
                            CargaRUC();
                        }
                        else
                        {
                            if (cboTipoDocRec.SelectedIndex == 1)
                            {
                                //CargaDNI();
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Consultar RUC");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cboTipoDocRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNroDocRec.Text = "";
            txtNombreLegalRec.Text = "";
            txtDirRec.Text = "";
            _documento.Receptor.NroDocumento = "";
            _documento.Receptor.NombreLegal = "";
            _documento.Receptor.NombreComercial = "";
            _documento.Receptor.Direccion = "";
        }
        private void CargaNumDocBaja() {
         
            Numera = AdmNumera.BuscaNumeracion("RA");
            string str = Convert.ToString(Numera.Numeracion);
            //char pad = '0';
            //numeracion = str.PadLeft(8, pad);
            txtcorrelativo2.Text = str.ToString();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {

            var documentoBaja = new ComunicacionBaja
            {

                IdDocumento ="",
                FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                FechaReferencia = "",//DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
                Emisor = CrearEmisor(),
                Bajas = new List<DocumentoBaja>()

            };
            documentoBaja.Bajas.Clear();

            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            txtmotivo.Text = "";
            dglista2.Rows.Clear();
        }
    }
}
