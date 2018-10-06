using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalXML
{
    public partial class FrmDetalleDocumento : Form
    {
        private readonly DetalleDocumento _detalle;
        private readonly DocumentoElectronico _documento;
        public FrmDetalleDocumento()
        {
            InitializeComponent();
        }
        public FrmDetalleDocumento(DetalleDocumento detalle, DocumentoElectronico documento)
        {
            InitializeComponent();
            _detalle = detalle;
            _documento = documento;

            detalleDocumentoBindingSource.DataSource = detalle;
            detalleDocumentoBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoImpuestoBindingSource.DataSource = ctx.TipoImpuestos.ToList();
                    tipoImpuestoBindingSource.ResetBindings(false);

                    tipoPrecioBindingSource.DataSource = ctx.TipoPrecios.ToList();
                    tipoPrecioBindingSource.ResetBindings(false);
                }
            };
            decimal sumar = 0;
            sumar = documento.Items.Count() + 1;
            idNumericUpDown.Value = (sumar);
        }
        private void FrmDetalleDocumento_Load(object sender, EventArgs e)
        {
            decimal sumar = 0;
            sumar = _documento.Items.Count() + 1;
            idNumericUpDown.Value = (sumar);
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {
            tipoPrecioComboBox.Focus();
            _detalle.UnidadMedida = unidadMedidaComboBox.Text;

            // Evaluamos el tipo de Impuesto.
            if (!_detalle.TipoImpuesto.StartsWith("1"))
            {
                _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
                _detalle.TotalVenta = _detalle.Suma;
            }
            else
            {
                if (_detalle.OtroImpuesto > 0)
                    _detalle.TotalVenta = _detalle.TotalVenta + _detalle.OtroImpuesto;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCalcIgv_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            // _detalle.Impuesto = _detalle.Suma * _documento.CalculoIgv;


            if (_documento.CalculoIgv > 0)
            {
                //_documento.SubTotalVenta=Math.Round((_detalle.Suma / Convert.ToDecimal(1.18)),2);
                _detalle.SubTotalVenta = Math.Round((_detalle.Suma / Convert.ToDecimal(1.18)), 2);
                _detalle.Impuesto = Math.Round(_detalle.Suma - _detalle.SubTotalVenta, 2);
            }
            else
            {
                //_documento.SubTotalVenta = _detalle.Suma;
                _detalle.SubTotalVenta = _detalle.Suma;
                _detalle.Impuesto = 0;
            }


            //_detalle.TotalVenta = _detalle.Suma;
            _detalle.TotalVenta = _detalle.Suma;

            detalleDocumentoBindingSource.ResetBindings(false);
        }

        private void btnCalcIsc_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            _detalle.ImpuestoSelectivo = _detalle.Suma * _documento.CalculoIsc;

            detalleDocumentoBindingSource.ResetBindings(false);
        }
    }
}
