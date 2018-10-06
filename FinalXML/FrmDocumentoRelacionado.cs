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
    
    public partial class FrmDocumentoRelacionado : Form
    {
        private readonly DocumentoRelacionado _documentoRelacionado;
        public FrmDocumentoRelacionado()
        {
            InitializeComponent();
        }
        public FrmDocumentoRelacionado(DocumentoRelacionado documentoRelacionado)
        {
            InitializeComponent();
            _documentoRelacionado = documentoRelacionado;
            documentoRelacionadoBindingSource.DataSource = _documentoRelacionado;
            documentoRelacionadoBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoRelacionadoBindingSource.DataSource = ctx.TipoDocumentoRelacionados.ToList();
                    tipoDocumentoRelacionadoBindingSource.ResetBindings(false);
                }
            };

            toolOk.Click += (s, e) =>
            {
                documentoRelacionadoBindingSource.EndEdit();
                DialogResult = DialogResult.OK;
            };

            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
        private void FrmDocumentoRelacionado_Load(object sender, EventArgs e)
        {

        }

        private void toolOk_Click(object sender, EventArgs e)
        {

        }
    }
}
