using System.Linq;
using System.Windows.Forms;
using FinalXML;

namespace FinalXML
{
    public partial class FrmDatosGuia : Form
    {
        private readonly DatosGuia _datosGuia;

        public FrmDatosGuia()
        {
            InitializeComponent();
        }

        private void FrmDatosGuia_Load(object sender, System.EventArgs e)
        {

        }
        public FrmDatosGuia(DatosGuia datosGuia)
        {
            InitializeComponent();
            _datosGuia = datosGuia;

            datosGuiaBindingSource.DataSource = _datosGuia;
            datosGuiaBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoContribuyenteBindingSource.DataSource = ctx.TipoDocumentoContribuyentes.ToList();
                    tipoDocumentoContribuyenteBindingSource.ResetBindings(false);

                    modalidadTransporteBindingSource.DataSource = ctx.ModalidadTransportes.ToList();
                    modalidadTransporteBindingSource.ResetBindings(false);
                }
            };

            toolOk.Click += (s, e) =>
            {
                datosGuiaBindingSource.EndEdit();
                _datosGuia.UnidadMedida = unidadMedidaComboBox.Text;

                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
        private void nombreTransportistaTextBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void toolOk_Click(object sender, System.EventArgs e)
        {

        }
    }
}
