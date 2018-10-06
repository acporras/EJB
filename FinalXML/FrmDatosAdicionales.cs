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
    public partial class FrmDatosAdicionales : Form
    {
        private readonly DatoAdicional _dato;
        public FrmDatosAdicionales()
        {
            InitializeComponent();
        }

        public FrmDatosAdicionales(DatoAdicional dato)
        {
            InitializeComponent();
            _dato = dato;
            datoAdicionalBindingSource.DataSource = _dato;
            datoAdicionalBindingSource.ResetBindings(false);
            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDatoAdicionalBindingSource.DataSource = ctx.TipoDatoAdicionales.ToList();
                    tipoDatoAdicionalBindingSource.ResetBindings(false);
                }
            };
            toolCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }
        private void FrmDatosAdicionales_Load(object sender, EventArgs e)
        {

        }

        private void toolOk_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                datoAdicionalBindingSource.EndEdit();
                datoAdicionalBindingSource.RaiseListChangedEvents = false;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                datoAdicionalBindingSource.RaiseListChangedEvents = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
