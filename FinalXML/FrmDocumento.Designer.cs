namespace FinalXML
{
    partial class FrmDocumento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentFactory.Krypton.Toolkit.KryptonLabel monedaAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel montoAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel docAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoDocAnticipoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalVentaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalOtrosTributosLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalIscLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalIgvLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel gratuitasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel inafectasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel exoneradasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel gravadasLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel urbanizacionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumento));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolGenerar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.receptorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoContribuyenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emisorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentoElectronicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datoAdicionalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relacionadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discrepanciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoOperacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoAnticipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monedaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detallesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.calculoDetraccionTextBox = new System.Windows.Forms.TextBox();
            this.calculoIscTextBox = new System.Windows.Forms.TextBox();
            this.calculoIgvTextBox = new System.Windows.Forms.TextBox();
            this.monedaAnticipoComboBox = new System.Windows.Forms.ComboBox();
            this.montoAnticipoTextBox = new System.Windows.Forms.TextBox();
            this.docAnticipoTextBox = new System.Windows.Forms.TextBox();
            this.tipoDocAnticipoComboBox = new System.Windows.Forms.ComboBox();
            this.btnGuia = new System.Windows.Forms.Button();
            this.montoDetraccionTextBox = new System.Windows.Forms.TextBox();
            this.tbPaginas = new System.Windows.Forms.TabControl();
            this.tpDetalles = new System.Windows.Forms.TabPage();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioReferencialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPrecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impuestoSelectivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otroImpuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAdicionales = new System.Windows.Forms.TabPage();
            this.datoAdicionalesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpRelacionados = new System.Windows.Forms.TabPage();
            this.relacionadosDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDiscrepancias = new System.Windows.Forms.TabPage();
            this.discrepanciasDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoPercepcionTextBox = new System.Windows.Forms.TextBox();
            this.descuentoGlobalTextBox = new System.Windows.Forms.TextBox();
            this.totalVentaTextBox = new System.Windows.Forms.TextBox();
            this.totalOtrosTributosTextBox = new System.Windows.Forms.TextBox();
            this.totalIscTextBox = new System.Windows.Forms.TextBox();
            this.totalIgvTextBox = new System.Windows.Forms.TextBox();
            this.tipoOperacionComboBox = new System.Windows.Forms.ComboBox();
            this.gratuitasTextBox = new System.Windows.Forms.TextBox();
            this.inafectasTextBox = new System.Windows.Forms.TextBox();
            this.exoneradasTextBox = new System.Windows.Forms.TextBox();
            this.gravadasTextBox = new System.Windows.Forms.TextBox();
            this.montoEnLetrasTextBox = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.urbanizacionTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUbigeoEm = new System.Windows.Forms.TextBox();
            this.txtDistritoEm = new System.Windows.Forms.TextBox();
            this.txtDptoEm = new System.Windows.Forms.TextBox();
            this.txtProvEm = new System.Windows.Forms.TextBox();
            this.txtDirEm = new System.Windows.Forms.TextBox();
            this.txtNombreComEm = new System.Windows.Forms.TextBox();
            this.txtNombreLegalEm = new System.Windows.Forms.TextBox();
            this.txtNroDocEm = new System.Windows.Forms.TextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnResetForm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCalcDetraccion = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEliminar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDuplicar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txttexto = new System.Windows.Forms.TextBox();
            this.pictureCapcha = new System.Windows.Forms.PictureBox();
            this.txtDirRec = new System.Windows.Forms.TextBox();
            this.cboTipoDocRec = new System.Windows.Forms.ComboBox();
            this.label28 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNroDocRec = new System.Windows.Forms.TextBox();
            this.txtNombreLegalRec = new System.Windows.Forms.TextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpEmisor = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonWrapLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cbmoneda = new System.Windows.Forms.ComboBox();
            this.txtCorrel = new System.Windows.Forms.TextBox();
            this.label10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dglista = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipdoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totventa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totigv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totgravadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDocInicio = new System.Windows.Forms.TextBox();
            this.txtTotVentaGraba = new System.Windows.Forms.TextBox();
            this.label13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtIGV = new System.Windows.Forms.TextBox();
            this.txtDocFin = new System.Windows.Forms.TextBox();
            this.txtTotVenta = new System.Windows.Forms.TextBox();
            this.label15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label23 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label22 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label14 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.GResumenDiario = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregarLista = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPage4 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtcorrelativo2 = new System.Windows.Forms.TextBox();
            this.label27 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label26 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label31 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtmotivo = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label25 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dglista2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label24 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.GComunicacionBaja = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton6 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPage5 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.GDatosDocumento = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.cboMoneda2 = new System.Windows.Forms.ComboBox();
            this.label49 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label58 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label51 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label50 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpFecha3 = new System.Windows.Forms.DateTimePicker();
            this.GDatosReceptor = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.cboTipoDocRec2 = new System.Windows.Forms.ComboBox();
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.label61 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNroCliente = new System.Windows.Forms.TextBox();
            this.label60 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label59 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtValorReten = new System.Windows.Forms.TextBox();
            this.label52 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCorrelativo3 = new System.Windows.Forms.TextBox();
            this.dgreten = new System.Windows.Forms.DataGridView();
            this.correl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label63 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label62 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.GRetencion = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonButton5 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            monedaAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            montoAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            docAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoDocAnticipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalVentaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalOtrosTributosLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalIscLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalIgvLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            gratuitasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            inafectasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            exoneradasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            gravadasLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            urbanizacionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receptorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoContribuyenteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentoElectronicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoAnticipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).BeginInit();
            this.tbPaginas.SuspendLayout();
            this.tpDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.tpAdicionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesDataGridView)).BeginInit();
            this.tpRelacionados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosDataGridView)).BeginInit();
            this.tbDiscrepancias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor.Panel)).BeginInit();
            this.grpEmisor.Panel.SuspendLayout();
            this.grpEmisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GResumenDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GResumenDiario.Panel)).BeginInit();
            this.GResumenDiario.Panel.SuspendLayout();
            this.GResumenDiario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.kryptonPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglista2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GComunicacionBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GComunicacionBaja.Panel)).BeginInit();
            this.GComunicacionBaja.Panel.SuspendLayout();
            this.GComunicacionBaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).BeginInit();
            this.kryptonPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosDocumento.Panel)).BeginInit();
            this.GDatosDocumento.Panel.SuspendLayout();
            this.GDatosDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosReceptor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosReceptor.Panel)).BeginInit();
            this.GDatosReceptor.Panel.SuspendLayout();
            this.GDatosReceptor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgreten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRetencion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRetencion.Panel)).BeginInit();
            this.GRetencion.Panel.SuspendLayout();
            this.GRetencion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.SuspendLayout();
            // 
            // monedaAnticipoLabel
            // 
            monedaAnticipoLabel.Location = new System.Drawing.Point(12, 81);
            monedaAnticipoLabel.Name = "monedaAnticipoLabel";
            monedaAnticipoLabel.Size = new System.Drawing.Size(107, 20);
            monedaAnticipoLabel.TabIndex = 6;
            monedaAnticipoLabel.Values.Text = "Moneda Anticipo:";
            // 
            // montoAnticipoLabel
            // 
            montoAnticipoLabel.Location = new System.Drawing.Point(12, 57);
            montoAnticipoLabel.Name = "montoAnticipoLabel";
            montoAnticipoLabel.Size = new System.Drawing.Size(99, 20);
            montoAnticipoLabel.TabIndex = 4;
            montoAnticipoLabel.Values.Text = "Monto Anticipo:";
            // 
            // docAnticipoLabel
            // 
            docAnticipoLabel.Location = new System.Drawing.Point(12, 33);
            docAnticipoLabel.Name = "docAnticipoLabel";
            docAnticipoLabel.Size = new System.Drawing.Size(84, 20);
            docAnticipoLabel.TabIndex = 2;
            docAnticipoLabel.Values.Text = "Doc Anticipo:";
            // 
            // tipoDocAnticipoLabel
            // 
            tipoDocAnticipoLabel.Location = new System.Drawing.Point(11, 5);
            tipoDocAnticipoLabel.Name = "tipoDocAnticipoLabel";
            tipoDocAnticipoLabel.Size = new System.Drawing.Size(111, 20);
            tipoDocAnticipoLabel.TabIndex = 0;
            tipoDocAnticipoLabel.Values.Text = "Tipo Doc Anticipo:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.Location = new System.Drawing.Point(751, 606);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(75, 20);
            totalVentaLabel.TabIndex = 147;
            totalVentaLabel.Values.Text = "Total Venta:";
            // 
            // totalOtrosTributosLabel
            // 
            totalOtrosTributosLabel.Location = new System.Drawing.Point(751, 580);
            totalOtrosTributosLabel.Name = "totalOtrosTributosLabel";
            totalOtrosTributosLabel.Size = new System.Drawing.Size(122, 20);
            totalOtrosTributosLabel.TabIndex = 145;
            totalOtrosTributosLabel.Values.Text = "Total Otros Tributos:";
            // 
            // totalIscLabel
            // 
            totalIscLabel.Location = new System.Drawing.Point(751, 554);
            totalIscLabel.Name = "totalIscLabel";
            totalIscLabel.Size = new System.Drawing.Size(61, 20);
            totalIscLabel.TabIndex = 143;
            totalIscLabel.Values.Text = "Total ISC:";
            // 
            // totalIgvLabel
            // 
            totalIgvLabel.Location = new System.Drawing.Point(751, 528);
            totalIgvLabel.Name = "totalIgvLabel";
            totalIgvLabel.Size = new System.Drawing.Size(63, 20);
            totalIgvLabel.TabIndex = 141;
            totalIgvLabel.Values.Text = "Total IGV:";
            // 
            // gratuitasLabel
            // 
            gratuitasLabel.Location = new System.Drawing.Point(11, 609);
            gratuitasLabel.Name = "gratuitasLabel";
            gratuitasLabel.Size = new System.Drawing.Size(62, 20);
            gratuitasLabel.TabIndex = 139;
            gratuitasLabel.Values.Text = "Gratuitas:";
            // 
            // inafectasLabel
            // 
            inafectasLabel.Location = new System.Drawing.Point(11, 583);
            inafectasLabel.Name = "inafectasLabel";
            inafectasLabel.Size = new System.Drawing.Size(62, 20);
            inafectasLabel.TabIndex = 137;
            inafectasLabel.Values.Text = "Inafectas:";
            // 
            // exoneradasLabel
            // 
            exoneradasLabel.Location = new System.Drawing.Point(11, 557);
            exoneradasLabel.Name = "exoneradasLabel";
            exoneradasLabel.Size = new System.Drawing.Size(75, 20);
            exoneradasLabel.TabIndex = 135;
            exoneradasLabel.Values.Text = "Exoneradas:";
            // 
            // gravadasLabel
            // 
            gravadasLabel.Location = new System.Drawing.Point(11, 531);
            gravadasLabel.Name = "gravadasLabel";
            gravadasLabel.Size = new System.Drawing.Size(63, 20);
            gravadasLabel.TabIndex = 133;
            gravadasLabel.Values.Text = "Gravadas:";
            // 
            // urbanizacionLabel
            // 
            urbanizacionLabel.Location = new System.Drawing.Point(322, 11);
            urbanizacionLabel.Name = "urbanizacionLabel";
            urbanizacionLabel.Size = new System.Drawing.Size(84, 20);
            urbanizacionLabel.TabIndex = 10;
            urbanizacionLabel.Values.Text = "Urbanización:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cancel.png");
            this.imageList1.Images.SetKeyName(1, "delete.png");
            this.imageList1.Images.SetKeyName(2, "iconcopy.png");
            this.imageList1.Images.SetKeyName(3, "iconxml.png");
            this.imageList1.Images.SetKeyName(4, "new.png");
            this.imageList1.Images.SetKeyName(5, "ok.png");
            // 
            // toolGenerar
            // 
            this.toolGenerar.Image = global::FinalXML.Properties.Resources.iconxml;
            this.toolGenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGenerar.Name = "toolGenerar";
            this.toolGenerar.Size = new System.Drawing.Size(95, 22);
            this.toolGenerar.Text = "&Generar XML";
            this.toolGenerar.Click += new System.EventHandler(this.toolGenerar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGenerar,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1114, 25);
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::FinalXML.Properties.Resources._142_xml_export_20;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(154, 22);
            this.toolStripButton1.Text = "&Generar Resumen Diario";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::FinalXML.Properties.Resources.file_Exel_download_16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(190, 22);
            this.toolStripButton2.Text = "Generar Comunicación de Baja";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::FinalXML.Properties.Resources.reten2;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(201, 22);
            this.toolStripButton3.Text = "Generar Comprobante Retención";
            this.toolStripButton3.Visible = false;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // receptorBindingSource
            // 
            this.receptorBindingSource.DataSource = typeof(FinalXML.Contribuyente);
            // 
            // tipoDocumentoContribuyenteBindingSource
            // 
            this.tipoDocumentoContribuyenteBindingSource.DataSource = typeof(FinalXML.TipoDocumentoContribuyente);
            // 
            // emisorBindingSource
            // 
            this.emisorBindingSource.DataSource = typeof(FinalXML.Contribuyente);
            // 
            // documentoElectronicoBindingSource
            // 
            this.documentoElectronicoBindingSource.DataSource = typeof(FinalXML.DocumentoElectronico);
            // 
            // tipoDocumentoBindingSource
            // 
            this.tipoDocumentoBindingSource.DataSource = typeof(FinalXML.TipoDocumento);
            // 
            // datoAdicionalesBindingSource
            // 
            this.datoAdicionalesBindingSource.DataMember = "DatoAdicionales";
            this.datoAdicionalesBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // relacionadosBindingSource
            // 
            this.relacionadosBindingSource.DataMember = "Relacionados";
            this.relacionadosBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // discrepanciasBindingSource
            // 
            this.discrepanciasBindingSource.DataMember = "Discrepancias";
            this.discrepanciasBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // tipoOperacionBindingSource
            // 
            this.tipoOperacionBindingSource.DataSource = typeof(FinalXML.TipoOperacion);
            // 
            // tipoDocumentoAnticipoBindingSource
            // 
            this.tipoDocumentoAnticipoBindingSource.DataSource = typeof(FinalXML.TipoDocumentoAnticipo);
            // 
            // monedaBindingSource
            // 
            this.monedaBindingSource.DataSource = typeof(FinalXML.Moneda);
            // 
            // detallesBindingSource
            // 
            this.detallesBindingSource.DataMember = "Items";
            this.detallesBindingSource.DataSource = this.documentoElectronicoBindingSource;
            // 
            // calculoDetraccionTextBox
            // 
            this.calculoDetraccionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoDetraccion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoDetraccionTextBox.Location = new System.Drawing.Point(821, 2);
            this.calculoDetraccionTextBox.Name = "calculoDetraccionTextBox";
            this.calculoDetraccionTextBox.Size = new System.Drawing.Size(88, 22);
            this.calculoDetraccionTextBox.TabIndex = 154;
            // 
            // calculoIscTextBox
            // 
            this.calculoIscTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoIsc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoIscTextBox.Location = new System.Drawing.Point(599, 1);
            this.calculoIscTextBox.Name = "calculoIscTextBox";
            this.calculoIscTextBox.Size = new System.Drawing.Size(100, 22);
            this.calculoIscTextBox.TabIndex = 152;
            // 
            // calculoIgvTextBox
            // 
            this.calculoIgvTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "CalculoIgv", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.calculoIgvTextBox.Location = new System.Drawing.Point(414, 2);
            this.calculoIgvTextBox.Name = "calculoIgvTextBox";
            this.calculoIgvTextBox.Size = new System.Drawing.Size(100, 22);
            this.calculoIgvTextBox.TabIndex = 150;
            // 
            // monedaAnticipoComboBox
            // 
            this.monedaAnticipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "MonedaAnticipo", true));
            this.monedaAnticipoComboBox.DataSource = this.monedaBindingSource;
            this.monedaAnticipoComboBox.DisplayMember = "Descripcion";
            this.monedaAnticipoComboBox.FormattingEnabled = true;
            this.monedaAnticipoComboBox.Location = new System.Drawing.Point(122, 78);
            this.monedaAnticipoComboBox.Name = "monedaAnticipoComboBox";
            this.monedaAnticipoComboBox.Size = new System.Drawing.Size(100, 21);
            this.monedaAnticipoComboBox.TabIndex = 7;
            this.monedaAnticipoComboBox.ValueMember = "Codigo";
            // 
            // montoAnticipoTextBox
            // 
            this.montoAnticipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoAnticipo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoAnticipoTextBox.Location = new System.Drawing.Point(122, 54);
            this.montoAnticipoTextBox.Name = "montoAnticipoTextBox";
            this.montoAnticipoTextBox.Size = new System.Drawing.Size(100, 22);
            this.montoAnticipoTextBox.TabIndex = 5;
            // 
            // docAnticipoTextBox
            // 
            this.docAnticipoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "DocAnticipo", true));
            this.docAnticipoTextBox.Location = new System.Drawing.Point(122, 30);
            this.docAnticipoTextBox.Name = "docAnticipoTextBox";
            this.docAnticipoTextBox.Size = new System.Drawing.Size(100, 22);
            this.docAnticipoTextBox.TabIndex = 3;
            // 
            // tipoDocAnticipoComboBox
            // 
            this.tipoDocAnticipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoDocAnticipo", true));
            this.tipoDocAnticipoComboBox.DataSource = this.tipoDocumentoAnticipoBindingSource;
            this.tipoDocAnticipoComboBox.DisplayMember = "Descripcion";
            this.tipoDocAnticipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDocAnticipoComboBox.DropDownWidth = 360;
            this.tipoDocAnticipoComboBox.FormattingEnabled = true;
            this.tipoDocAnticipoComboBox.Location = new System.Drawing.Point(122, 3);
            this.tipoDocAnticipoComboBox.Name = "tipoDocAnticipoComboBox";
            this.tipoDocAnticipoComboBox.Size = new System.Drawing.Size(100, 21);
            this.tipoDocAnticipoComboBox.TabIndex = 1;
            this.tipoDocAnticipoComboBox.ValueMember = "Codigo";
            // 
            // btnGuia
            // 
            this.btnGuia.Location = new System.Drawing.Point(396, 288);
            this.btnGuia.Name = "btnGuia";
            this.btnGuia.Size = new System.Drawing.Size(149, 23);
            this.btnGuia.TabIndex = 122;
            this.btnGuia.Text = "&Guia de Rem. Transportista";
            this.btnGuia.UseVisualStyleBackColor = true;
            this.btnGuia.Visible = false;
            // 
            // montoDetraccionTextBox
            // 
            this.montoDetraccionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoDetraccion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoDetraccionTextBox.Location = new System.Drawing.Point(658, 260);
            this.montoDetraccionTextBox.Name = "montoDetraccionTextBox";
            this.montoDetraccionTextBox.Size = new System.Drawing.Size(88, 22);
            this.montoDetraccionTextBox.TabIndex = 126;
            // 
            // tbPaginas
            // 
            this.tbPaginas.Controls.Add(this.tpDetalles);
            this.tbPaginas.Controls.Add(this.tpAdicionales);
            this.tbPaginas.Controls.Add(this.tpRelacionados);
            this.tbPaginas.Controls.Add(this.tbDiscrepancias);
            this.tbPaginas.Location = new System.Drawing.Point(12, 316);
            this.tbPaginas.Name = "tbPaginas";
            this.tbPaginas.SelectedIndex = 0;
            this.tbPaginas.Size = new System.Drawing.Size(969, 206);
            this.tbPaginas.TabIndex = 132;
            // 
            // tpDetalles
            // 
            this.tpDetalles.Controls.Add(this.dgvDetalle);
            this.tpDetalles.Location = new System.Drawing.Point(4, 22);
            this.tpDetalles.Name = "tpDetalles";
            this.tpDetalles.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetalles.Size = new System.Drawing.Size(961, 180);
            this.tpDetalles.TabIndex = 0;
            this.tpDetalles.Text = "Detalle de Documentos";
            this.tpDetalles.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codigoItemDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.unidadMedidaDataGridViewTextBoxColumn,
            this.precioUnitarioDataGridViewTextBoxColumn,
            this.precioReferencialDataGridViewTextBoxColumn,
            this.tipoPrecioDataGridViewTextBoxColumn,
            this.impuestoDataGridViewTextBoxColumn,
            this.tipoImpuestoDataGridViewTextBoxColumn,
            this.impuestoSelectivoDataGridViewTextBoxColumn,
            this.otroImpuestoDataGridViewTextBoxColumn,
            this.totalVentaDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.detallesBindingSource;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(955, 174);
            this.dgvDetalle.TabIndex = 25;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 42;
            // 
            // codigoItemDataGridViewTextBoxColumn
            // 
            this.codigoItemDataGridViewTextBoxColumn.DataPropertyName = "CodigoItem";
            this.codigoItemDataGridViewTextBoxColumn.HeaderText = "Codigo Item";
            this.codigoItemDataGridViewTextBoxColumn.Name = "codigoItemDataGridViewTextBoxColumn";
            this.codigoItemDataGridViewTextBoxColumn.Width = 95;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 92;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 79;
            // 
            // unidadMedidaDataGridViewTextBoxColumn
            // 
            this.unidadMedidaDataGridViewTextBoxColumn.DataPropertyName = "UnidadMedida";
            this.unidadMedidaDataGridViewTextBoxColumn.HeaderText = "Unidad Medida";
            this.unidadMedidaDataGridViewTextBoxColumn.Name = "unidadMedidaDataGridViewTextBoxColumn";
            this.unidadMedidaDataGridViewTextBoxColumn.Width = 112;
            // 
            // precioUnitarioDataGridViewTextBoxColumn
            // 
            this.precioUnitarioDataGridViewTextBoxColumn.DataPropertyName = "PrecioUnitario";
            this.precioUnitarioDataGridViewTextBoxColumn.HeaderText = "Precio Unitario";
            this.precioUnitarioDataGridViewTextBoxColumn.Name = "precioUnitarioDataGridViewTextBoxColumn";
            this.precioUnitarioDataGridViewTextBoxColumn.Width = 108;
            // 
            // precioReferencialDataGridViewTextBoxColumn
            // 
            this.precioReferencialDataGridViewTextBoxColumn.DataPropertyName = "PrecioReferencial";
            this.precioReferencialDataGridViewTextBoxColumn.HeaderText = "Precio Referencial";
            this.precioReferencialDataGridViewTextBoxColumn.Name = "precioReferencialDataGridViewTextBoxColumn";
            this.precioReferencialDataGridViewTextBoxColumn.Width = 123;
            // 
            // tipoPrecioDataGridViewTextBoxColumn
            // 
            this.tipoPrecioDataGridViewTextBoxColumn.DataPropertyName = "TipoPrecio";
            this.tipoPrecioDataGridViewTextBoxColumn.HeaderText = "Tipo Precio";
            this.tipoPrecioDataGridViewTextBoxColumn.Name = "tipoPrecioDataGridViewTextBoxColumn";
            this.tipoPrecioDataGridViewTextBoxColumn.Width = 88;
            // 
            // impuestoDataGridViewTextBoxColumn
            // 
            this.impuestoDataGridViewTextBoxColumn.DataPropertyName = "Impuesto";
            this.impuestoDataGridViewTextBoxColumn.HeaderText = "Impuesto";
            this.impuestoDataGridViewTextBoxColumn.Name = "impuestoDataGridViewTextBoxColumn";
            this.impuestoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tipoImpuestoDataGridViewTextBoxColumn
            // 
            this.tipoImpuestoDataGridViewTextBoxColumn.DataPropertyName = "TipoImpuesto";
            this.tipoImpuestoDataGridViewTextBoxColumn.HeaderText = "Tipo Impuesto";
            this.tipoImpuestoDataGridViewTextBoxColumn.Name = "tipoImpuestoDataGridViewTextBoxColumn";
            this.tipoImpuestoDataGridViewTextBoxColumn.Width = 105;
            // 
            // impuestoSelectivoDataGridViewTextBoxColumn
            // 
            this.impuestoSelectivoDataGridViewTextBoxColumn.DataPropertyName = "ImpuestoSelectivo";
            this.impuestoSelectivoDataGridViewTextBoxColumn.HeaderText = "Impuesto Selectivo";
            this.impuestoSelectivoDataGridViewTextBoxColumn.Name = "impuestoSelectivoDataGridViewTextBoxColumn";
            this.impuestoSelectivoDataGridViewTextBoxColumn.Width = 128;
            // 
            // otroImpuestoDataGridViewTextBoxColumn
            // 
            this.otroImpuestoDataGridViewTextBoxColumn.DataPropertyName = "OtroImpuesto";
            this.otroImpuestoDataGridViewTextBoxColumn.HeaderText = "Otro Impuesto";
            this.otroImpuestoDataGridViewTextBoxColumn.Name = "otroImpuestoDataGridViewTextBoxColumn";
            this.otroImpuestoDataGridViewTextBoxColumn.Width = 107;
            // 
            // totalVentaDataGridViewTextBoxColumn
            // 
            this.totalVentaDataGridViewTextBoxColumn.DataPropertyName = "TotalVenta";
            this.totalVentaDataGridViewTextBoxColumn.HeaderText = "Total Venta";
            this.totalVentaDataGridViewTextBoxColumn.Name = "totalVentaDataGridViewTextBoxColumn";
            this.totalVentaDataGridViewTextBoxColumn.Width = 90;
            // 
            // tpAdicionales
            // 
            this.tpAdicionales.AutoScroll = true;
            this.tpAdicionales.Controls.Add(this.datoAdicionalesDataGridView);
            this.tpAdicionales.Location = new System.Drawing.Point(4, 22);
            this.tpAdicionales.Name = "tpAdicionales";
            this.tpAdicionales.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdicionales.Size = new System.Drawing.Size(961, 180);
            this.tpAdicionales.TabIndex = 1;
            this.tpAdicionales.Text = "Datos Adicionales";
            this.tpAdicionales.UseVisualStyleBackColor = true;
            // 
            // datoAdicionalesDataGridView
            // 
            this.datoAdicionalesDataGridView.AllowUserToAddRows = false;
            this.datoAdicionalesDataGridView.AutoGenerateColumns = false;
            this.datoAdicionalesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.datoAdicionalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datoAdicionalesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.datoAdicionalesDataGridView.DataSource = this.datoAdicionalesBindingSource;
            this.datoAdicionalesDataGridView.Location = new System.Drawing.Point(1, 0);
            this.datoAdicionalesDataGridView.Name = "datoAdicionalesDataGridView";
            this.datoAdicionalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datoAdicionalesDataGridView.Size = new System.Drawing.Size(870, 177);
            this.datoAdicionalesDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Contenido";
            this.dataGridViewTextBoxColumn2.HeaderText = "Contenido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 87;
            // 
            // tpRelacionados
            // 
            this.tpRelacionados.AutoScroll = true;
            this.tpRelacionados.Controls.Add(this.relacionadosDataGridView);
            this.tpRelacionados.Location = new System.Drawing.Point(4, 22);
            this.tpRelacionados.Name = "tpRelacionados";
            this.tpRelacionados.Padding = new System.Windows.Forms.Padding(3);
            this.tpRelacionados.Size = new System.Drawing.Size(961, 180);
            this.tpRelacionados.TabIndex = 2;
            this.tpRelacionados.Text = "Documentos Relacionados";
            this.tpRelacionados.UseVisualStyleBackColor = true;
            // 
            // relacionadosDataGridView
            // 
            this.relacionadosDataGridView.AllowUserToAddRows = false;
            this.relacionadosDataGridView.AllowUserToDeleteRows = false;
            this.relacionadosDataGridView.AutoGenerateColumns = false;
            this.relacionadosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.relacionadosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.relacionadosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3});
            this.relacionadosDataGridView.DataSource = this.relacionadosBindingSource;
            this.relacionadosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relacionadosDataGridView.Location = new System.Drawing.Point(3, 3);
            this.relacionadosDataGridView.Name = "relacionadosDataGridView";
            this.relacionadosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.relacionadosDataGridView.Size = new System.Drawing.Size(955, 174);
            this.relacionadosDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoDocumento";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tipo de Documento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 122;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NroDocumento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nro. Documento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 107;
            // 
            // tbDiscrepancias
            // 
            this.tbDiscrepancias.AutoScroll = true;
            this.tbDiscrepancias.Controls.Add(this.discrepanciasDataGridView);
            this.tbDiscrepancias.Location = new System.Drawing.Point(4, 22);
            this.tbDiscrepancias.Name = "tbDiscrepancias";
            this.tbDiscrepancias.Padding = new System.Windows.Forms.Padding(3);
            this.tbDiscrepancias.Size = new System.Drawing.Size(961, 180);
            this.tbDiscrepancias.TabIndex = 3;
            this.tbDiscrepancias.Text = "Discrepancias";
            this.tbDiscrepancias.UseVisualStyleBackColor = true;
            // 
            // discrepanciasDataGridView
            // 
            this.discrepanciasDataGridView.AllowUserToAddRows = false;
            this.discrepanciasDataGridView.AllowUserToDeleteRows = false;
            this.discrepanciasDataGridView.AutoGenerateColumns = false;
            this.discrepanciasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.discrepanciasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.discrepanciasDataGridView.DataSource = this.discrepanciasBindingSource;
            this.discrepanciasDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.discrepanciasDataGridView.Location = new System.Drawing.Point(3, 3);
            this.discrepanciasDataGridView.Name = "discrepanciasDataGridView";
            this.discrepanciasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.discrepanciasDataGridView.Size = new System.Drawing.Size(955, 174);
            this.discrepanciasDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NroReferencia";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nro. Referencia";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 111;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Tipo";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 54;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Descripcion";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 92;
            // 
            // montoPercepcionTextBox
            // 
            this.montoPercepcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoPercepcion", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.montoPercepcionTextBox.Location = new System.Drawing.Point(658, 224);
            this.montoPercepcionTextBox.Name = "montoPercepcionTextBox";
            this.montoPercepcionTextBox.Size = new System.Drawing.Size(88, 22);
            this.montoPercepcionTextBox.TabIndex = 124;
            // 
            // descuentoGlobalTextBox
            // 
            this.descuentoGlobalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "DescuentoGlobal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.descuentoGlobalTextBox.Location = new System.Drawing.Point(301, 290);
            this.descuentoGlobalTextBox.Name = "descuentoGlobalTextBox";
            this.descuentoGlobalTextBox.Size = new System.Drawing.Size(89, 22);
            this.descuentoGlobalTextBox.TabIndex = 121;
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(877, 603);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalVentaTextBox.TabIndex = 148;
            // 
            // totalOtrosTributosTextBox
            // 
            this.totalOtrosTributosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalOtrosTributos", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalOtrosTributosTextBox.Location = new System.Drawing.Point(877, 577);
            this.totalOtrosTributosTextBox.Name = "totalOtrosTributosTextBox";
            this.totalOtrosTributosTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalOtrosTributosTextBox.TabIndex = 146;
            // 
            // totalIscTextBox
            // 
            this.totalIscTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalIsc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalIscTextBox.Location = new System.Drawing.Point(877, 551);
            this.totalIscTextBox.Name = "totalIscTextBox";
            this.totalIscTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalIscTextBox.TabIndex = 144;
            // 
            // totalIgvTextBox
            // 
            this.totalIgvTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "TotalIgv", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalIgvTextBox.Location = new System.Drawing.Point(877, 525);
            this.totalIgvTextBox.Name = "totalIgvTextBox";
            this.totalIgvTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalIgvTextBox.TabIndex = 142;
            // 
            // tipoOperacionComboBox
            // 
            this.tipoOperacionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoOperacion", true));
            this.tipoOperacionComboBox.DataSource = this.tipoOperacionBindingSource;
            this.tipoOperacionComboBox.DisplayMember = "Descripcion";
            this.tipoOperacionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoOperacionComboBox.FormattingEnabled = true;
            this.tipoOperacionComboBox.Location = new System.Drawing.Point(301, 224);
            this.tipoOperacionComboBox.Name = "tipoOperacionComboBox";
            this.tipoOperacionComboBox.Size = new System.Drawing.Size(242, 21);
            this.tipoOperacionComboBox.TabIndex = 117;
            this.tipoOperacionComboBox.ValueMember = "Codigo";
            // 
            // gratuitasTextBox
            // 
            this.gratuitasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Gratuitas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gratuitasTextBox.Location = new System.Drawing.Point(80, 606);
            this.gratuitasTextBox.Name = "gratuitasTextBox";
            this.gratuitasTextBox.Size = new System.Drawing.Size(100, 22);
            this.gratuitasTextBox.TabIndex = 140;
            // 
            // inafectasTextBox
            // 
            this.inafectasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Inafectas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.inafectasTextBox.Location = new System.Drawing.Point(80, 580);
            this.inafectasTextBox.Name = "inafectasTextBox";
            this.inafectasTextBox.Size = new System.Drawing.Size(100, 22);
            this.inafectasTextBox.TabIndex = 138;
            // 
            // exoneradasTextBox
            // 
            this.exoneradasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Exoneradas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.exoneradasTextBox.Location = new System.Drawing.Point(80, 554);
            this.exoneradasTextBox.Name = "exoneradasTextBox";
            this.exoneradasTextBox.Size = new System.Drawing.Size(100, 22);
            this.exoneradasTextBox.TabIndex = 136;
            // 
            // gravadasTextBox
            // 
            this.gravadasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "Gravadas", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gravadasTextBox.Location = new System.Drawing.Point(80, 528);
            this.gravadasTextBox.Name = "gravadasTextBox";
            this.gravadasTextBox.Size = new System.Drawing.Size(100, 22);
            this.gravadasTextBox.TabIndex = 134;
            // 
            // montoEnLetrasTextBox
            // 
            this.montoEnLetrasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "MontoEnLetras", true));
            this.montoEnLetrasTextBox.Enabled = false;
            this.montoEnLetrasTextBox.Location = new System.Drawing.Point(301, 260);
            this.montoEnLetrasTextBox.Name = "montoEnLetrasTextBox";
            this.montoEnLetrasTextBox.Size = new System.Drawing.Size(244, 22);
            this.montoEnLetrasTextBox.TabIndex = 119;
            // 
            // dtpFecha
            // 
            this.dtpFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "FechaEmision", true));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(98, 257);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 22);
            this.dtpFecha.TabIndex = 113;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "Moneda", true));
            this.cboMoneda.DataSource = this.monedaBindingSource;
            this.cboMoneda.DisplayMember = "Descripcion";
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(98, 287);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(100, 21);
            this.cboMoneda.TabIndex = 115;
            this.cboMoneda.ValueMember = "Codigo";
            // 
            // textBox17
            // 
            this.textBox17.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "IdDocumento", true));
            this.textBox17.Location = new System.Drawing.Point(98, 225);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 22);
            this.textBox17.TabIndex = 111;
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoDocumento", true));
            this.cboTipoDoc.DataSource = this.tipoDocumentoBindingSource;
            this.cboTipoDoc.DisplayMember = "Descripcion";
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(133, 5);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(175, 21);
            this.cboTipoDoc.TabIndex = 107;
            this.cboTipoDoc.ValueMember = "Codigo";
            this.cboTipoDoc.SelectionChangeCommitted += new System.EventHandler(this.cboTipoDoc_SelectionChangeCommitted_1);
            // 
            // urbanizacionTextBox
            // 
            this.urbanizacionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Urbanizacion", true));
            this.urbanizacionTextBox.Location = new System.Drawing.Point(419, 8);
            this.urbanizacionTextBox.Name = "urbanizacionTextBox";
            this.urbanizacionTextBox.Size = new System.Drawing.Size(100, 22);
            this.urbanizacionTextBox.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(9, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 6;
            this.label9.Values.Text = "Ubigeo:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(324, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 16;
            this.label8.Values.Text = "Distrito:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(324, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 12;
            this.label7.Values.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(324, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 14;
            this.label6.Values.Text = "Provincia:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 8;
            this.label5.Values.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Values.Text = "Nombre Legal:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Values.Text = "Nro. Doc:";
            // 
            // txtUbigeoEm
            // 
            this.txtUbigeoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Ubigeo", true));
            this.txtUbigeoEm.Location = new System.Drawing.Point(218, 89);
            this.txtUbigeoEm.Name = "txtUbigeoEm";
            this.txtUbigeoEm.Size = new System.Drawing.Size(100, 22);
            this.txtUbigeoEm.TabIndex = 7;
            // 
            // txtDistritoEm
            // 
            this.txtDistritoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Distrito", true));
            this.txtDistritoEm.Location = new System.Drawing.Point(419, 88);
            this.txtDistritoEm.Name = "txtDistritoEm";
            this.txtDistritoEm.ReadOnly = true;
            this.txtDistritoEm.Size = new System.Drawing.Size(100, 22);
            this.txtDistritoEm.TabIndex = 17;
            // 
            // txtDptoEm
            // 
            this.txtDptoEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Departamento", true));
            this.txtDptoEm.Location = new System.Drawing.Point(419, 34);
            this.txtDptoEm.Name = "txtDptoEm";
            this.txtDptoEm.ReadOnly = true;
            this.txtDptoEm.Size = new System.Drawing.Size(100, 22);
            this.txtDptoEm.TabIndex = 13;
            // 
            // txtProvEm
            // 
            this.txtProvEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Provincia", true));
            this.txtProvEm.Location = new System.Drawing.Point(419, 59);
            this.txtProvEm.Name = "txtProvEm";
            this.txtProvEm.ReadOnly = true;
            this.txtProvEm.Size = new System.Drawing.Size(100, 22);
            this.txtProvEm.TabIndex = 15;
            // 
            // txtDirEm
            // 
            this.txtDirEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "Direccion", true));
            this.txtDirEm.Location = new System.Drawing.Point(127, 118);
            this.txtDirEm.Name = "txtDirEm";
            this.txtDirEm.ReadOnly = true;
            this.txtDirEm.Size = new System.Drawing.Size(191, 22);
            this.txtDirEm.TabIndex = 9;
            // 
            // txtNombreComEm
            // 
            this.txtNombreComEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreComercial", true));
            this.txtNombreComEm.Location = new System.Drawing.Point(127, 59);
            this.txtNombreComEm.Name = "txtNombreComEm";
            this.txtNombreComEm.Size = new System.Drawing.Size(191, 22);
            this.txtNombreComEm.TabIndex = 5;
            // 
            // txtNombreLegalEm
            // 
            this.txtNombreLegalEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NombreLegal", true));
            this.txtNombreLegalEm.Location = new System.Drawing.Point(127, 34);
            this.txtNombreLegalEm.Name = "txtNombreLegalEm";
            this.txtNombreLegalEm.ReadOnly = true;
            this.txtNombreLegalEm.Size = new System.Drawing.Size(191, 22);
            this.txtNombreLegalEm.TabIndex = 3;
            // 
            // txtNroDocEm
            // 
            this.txtNroDocEm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.emisorBindingSource, "NroDocumento", true));
            this.txtNroDocEm.Location = new System.Drawing.Point(218, 8);
            this.txtNroDocEm.Name = "txtNroDocEm";
            this.txtNroDocEm.ReadOnly = true;
            this.txtNroDocEm.Size = new System.Drawing.Size(100, 22);
            this.txtNroDocEm.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 4;
            this.label4.Values.Text = "Nombre Comercial:";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 25);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage2,
            this.kryptonPage3,
            this.kryptonPage4,
            this.kryptonPage5});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1114, 692);
            this.kryptonNavigator1.TabIndex = 52;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kryptonPanel1);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPage2.Text = "Facturas - Boletas";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "D5AC6809EE3D492D94884856C8D4FBCA";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnResetForm);
            this.kryptonPanel1.Controls.Add(this.btnCalcDetraccion);
            this.kryptonPanel1.Controls.Add(this.btnEliminar);
            this.kryptonPanel1.Controls.Add(this.btnDuplicar);
            this.kryptonPanel1.Controls.Add(this.btnAgregar);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.grpEmisor);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel12);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel11);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel10);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel9);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel8);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel7);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel6);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonPanel1.Controls.Add(this.cboTipoDoc);
            this.kryptonPanel1.Controls.Add(this.calculoDetraccionTextBox);
            this.kryptonPanel1.Controls.Add(this.calculoIscTextBox);
            this.kryptonPanel1.Controls.Add(this.calculoIgvTextBox);
            this.kryptonPanel1.Controls.Add(this.textBox17);
            this.kryptonPanel1.Controls.Add(this.btnGuia);
            this.kryptonPanel1.Controls.Add(this.cboMoneda);
            this.kryptonPanel1.Controls.Add(this.dtpFecha);
            this.kryptonPanel1.Controls.Add(this.montoDetraccionTextBox);
            this.kryptonPanel1.Controls.Add(this.montoEnLetrasTextBox);
            this.kryptonPanel1.Controls.Add(this.tbPaginas);
            this.kryptonPanel1.Controls.Add(this.gravadasTextBox);
            this.kryptonPanel1.Controls.Add(this.montoPercepcionTextBox);
            this.kryptonPanel1.Controls.Add(gravadasLabel);
            this.kryptonPanel1.Controls.Add(this.exoneradasTextBox);
            this.kryptonPanel1.Controls.Add(this.descuentoGlobalTextBox);
            this.kryptonPanel1.Controls.Add(exoneradasLabel);
            this.kryptonPanel1.Controls.Add(this.inafectasTextBox);
            this.kryptonPanel1.Controls.Add(inafectasLabel);
            this.kryptonPanel1.Controls.Add(this.gratuitasTextBox);
            this.kryptonPanel1.Controls.Add(totalVentaLabel);
            this.kryptonPanel1.Controls.Add(gratuitasLabel);
            this.kryptonPanel1.Controls.Add(this.totalVentaTextBox);
            this.kryptonPanel1.Controls.Add(this.tipoOperacionComboBox);
            this.kryptonPanel1.Controls.Add(totalOtrosTributosLabel);
            this.kryptonPanel1.Controls.Add(this.totalOtrosTributosTextBox);
            this.kryptonPanel1.Controls.Add(this.totalIgvTextBox);
            this.kryptonPanel1.Controls.Add(totalIscLabel);
            this.kryptonPanel1.Controls.Add(totalIgvLabel);
            this.kryptonPanel1.Controls.Add(this.totalIscTextBox);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPanel1.TabIndex = 156;
            // 
            // btnResetForm
            // 
            this.btnResetForm.Location = new System.Drawing.Point(433, 554);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.btnResetForm.Size = new System.Drawing.Size(121, 31);
            this.btnResetForm.TabIndex = 235;
            this.btnResetForm.Values.Image = global::FinalXML.Properties.Resources.UI_11_24;
            this.btnResetForm.Values.Text = "&Nueva Venta";
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // btnCalcDetraccion
            // 
            this.btnCalcDetraccion.AutoSize = true;
            this.btnCalcDetraccion.Location = new System.Drawing.Point(590, 290);
            this.btnCalcDetraccion.Name = "btnCalcDetraccion";
            this.btnCalcDetraccion.Size = new System.Drawing.Size(120, 24);
            this.btnCalcDetraccion.TabIndex = 222;
            this.btnCalcDetraccion.Values.Text = "&Calcular Detracción";
            this.btnCalcDetraccion.Click += new System.EventHandler(this.btnCalcDetraccion_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.Location = new System.Drawing.Point(989, 428);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 24);
            this.btnEliminar.TabIndex = 209;
            this.btnEliminar.Values.Image = global::FinalXML.Properties.Resources.delete;
            this.btnEliminar.Values.Text = "&Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnDuplicar
            // 
            this.btnDuplicar.AutoSize = true;
            this.btnDuplicar.Location = new System.Drawing.Point(989, 401);
            this.btnDuplicar.Name = "btnDuplicar";
            this.btnDuplicar.Size = new System.Drawing.Size(88, 24);
            this.btnDuplicar.TabIndex = 208;
            this.btnDuplicar.Values.Image = global::FinalXML.Properties.Resources.iconcopy;
            this.btnDuplicar.Values.Text = "&Duplicar";
            this.btnDuplicar.Click += new System.EventHandler(this.btnDuplicar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.Location = new System.Drawing.Point(989, 375);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 24);
            this.btnAgregar.TabIndex = 207;
            this.btnAgregar.Values.Image = global::FinalXML.Properties.Resources._new;
            this.btnAgregar.Values.Text = "&Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(754, 204);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(monedaAnticipoLabel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.tipoDocAnticipoComboBox);
            this.kryptonGroupBox2.Panel.Controls.Add(this.monedaAnticipoComboBox);
            this.kryptonGroupBox2.Panel.Controls.Add(tipoDocAnticipoLabel);
            this.kryptonGroupBox2.Panel.Controls.Add(montoAnticipoLabel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.docAnticipoTextBox);
            this.kryptonGroupBox2.Panel.Controls.Add(this.montoAnticipoTextBox);
            this.kryptonGroupBox2.Panel.Controls.Add(docAnticipoLabel);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(232, 128);
            this.kryptonGroupBox2.TabIndex = 194;
            this.kryptonGroupBox2.Values.Heading = "Regularización de Anticipos";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(547, 30);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.txttexto);
            this.kryptonGroupBox1.Panel.Controls.Add(this.pictureCapcha);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDirRec);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cboTipoDocRec);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label28);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtNroDocRec);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtNombreLegalRec);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label17);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label16);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(530, 176);
            this.kryptonGroupBox1.TabIndex = 181;
            this.kryptonGroupBox1.Values.Heading = "Datos del Receptor";
            // 
            // txttexto
            // 
            this.txttexto.Location = new System.Drawing.Point(316, 33);
            this.txttexto.Name = "txttexto";
            this.txttexto.Size = new System.Drawing.Size(70, 22);
            this.txttexto.TabIndex = 56;
            // 
            // pictureCapcha
            // 
            this.pictureCapcha.Location = new System.Drawing.Point(398, 6);
            this.pictureCapcha.Name = "pictureCapcha";
            this.pictureCapcha.Size = new System.Drawing.Size(104, 48);
            this.pictureCapcha.TabIndex = 55;
            this.pictureCapcha.TabStop = false;
            // 
            // txtDirRec
            // 
            this.txtDirRec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.receptorBindingSource, "Direccion", true));
            this.txtDirRec.Location = new System.Drawing.Point(115, 86);
            this.txtDirRec.Name = "txtDirRec";
            this.txtDirRec.Size = new System.Drawing.Size(376, 22);
            this.txtDirRec.TabIndex = 7;
            // 
            // cboTipoDocRec
            // 
            this.cboTipoDocRec.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.receptorBindingSource, "TipoDocumento", true));
            this.cboTipoDocRec.DataSource = this.tipoDocumentoContribuyenteBindingSource;
            this.cboTipoDocRec.DisplayMember = "Descripcion";
            this.cboTipoDocRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocRec.FormattingEnabled = true;
            this.cboTipoDocRec.Location = new System.Drawing.Point(114, 6);
            this.cboTipoDocRec.Name = "cboTipoDocRec";
            this.cboTipoDocRec.Size = new System.Drawing.Size(194, 21);
            this.cboTipoDocRec.TabIndex = 1;
            this.cboTipoDocRec.ValueMember = "Codigo";
            this.cboTipoDocRec.SelectedIndexChanged += new System.EventHandler(this.cboTipoDocRec_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(18, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 20);
            this.label28.TabIndex = 6;
            this.label28.Values.Text = "Dirección:";
            // 
            // txtNroDocRec
            // 
            this.txtNroDocRec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.receptorBindingSource, "NroDocumento", true));
            this.txtNroDocRec.Location = new System.Drawing.Point(115, 31);
            this.txtNroDocRec.MaxLength = 12;
            this.txtNroDocRec.Name = "txtNroDocRec";
            this.txtNroDocRec.Size = new System.Drawing.Size(194, 22);
            this.txtNroDocRec.TabIndex = 3;
            this.txtNroDocRec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroDocRec_KeyPress);
            // 
            // txtNombreLegalRec
            // 
            this.txtNombreLegalRec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.receptorBindingSource, "NombreLegal", true));
            this.txtNombreLegalRec.Location = new System.Drawing.Point(114, 59);
            this.txtNombreLegalRec.Name = "txtNombreLegalRec";
            this.txtNombreLegalRec.Size = new System.Drawing.Size(388, 22);
            this.txtNombreLegalRec.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Tipo Doc:";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(13, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 2;
            this.label17.Values.Text = "Nro. Doc.:";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(13, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 20);
            this.label16.TabIndex = 4;
            this.label16.Values.Text = "Nombre Legal:";
            // 
            // grpEmisor
            // 
            this.grpEmisor.Location = new System.Drawing.Point(12, 30);
            this.grpEmisor.Name = "grpEmisor";
            // 
            // grpEmisor.Panel
            // 
            this.grpEmisor.Panel.Controls.Add(this.urbanizacionTextBox);
            this.grpEmisor.Panel.Controls.Add(this.label2);
            this.grpEmisor.Panel.Controls.Add(urbanizacionLabel);
            this.grpEmisor.Panel.Controls.Add(this.label4);
            this.grpEmisor.Panel.Controls.Add(this.label9);
            this.grpEmisor.Panel.Controls.Add(this.txtNroDocEm);
            this.grpEmisor.Panel.Controls.Add(this.label8);
            this.grpEmisor.Panel.Controls.Add(this.txtNombreLegalEm);
            this.grpEmisor.Panel.Controls.Add(this.label7);
            this.grpEmisor.Panel.Controls.Add(this.txtNombreComEm);
            this.grpEmisor.Panel.Controls.Add(this.label6);
            this.grpEmisor.Panel.Controls.Add(this.txtDirEm);
            this.grpEmisor.Panel.Controls.Add(this.label5);
            this.grpEmisor.Panel.Controls.Add(this.txtProvEm);
            this.grpEmisor.Panel.Controls.Add(this.label3);
            this.grpEmisor.Panel.Controls.Add(this.txtDptoEm);
            this.grpEmisor.Panel.Controls.Add(this.txtDistritoEm);
            this.grpEmisor.Panel.Controls.Add(this.txtUbigeoEm);
            this.grpEmisor.Size = new System.Drawing.Size(532, 176);
            this.grpEmisor.TabIndex = 168;
            this.grpEmisor.Values.Heading = "Datos del Emisor";
            // 
            // kryptonWrapLabel12
            // 
            this.kryptonWrapLabel12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel12.Location = new System.Drawing.Point(220, 293);
            this.kryptonWrapLabel12.Name = "kryptonWrapLabel12";
            this.kryptonWrapLabel12.Size = new System.Drawing.Size(75, 15);
            this.kryptonWrapLabel12.Text = "Dcto. Global:";
            // 
            // kryptonWrapLabel11
            // 
            this.kryptonWrapLabel11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel11.Location = new System.Drawing.Point(40, 287);
            this.kryptonWrapLabel11.Name = "kryptonWrapLabel11";
            this.kryptonWrapLabel11.Size = new System.Drawing.Size(54, 15);
            this.kryptonWrapLabel11.Text = "Moneda:";
            // 
            // kryptonWrapLabel10
            // 
            this.kryptonWrapLabel10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel10.Location = new System.Drawing.Point(546, 264);
            this.kryptonWrapLabel10.Name = "kryptonWrapLabel10";
            this.kryptonWrapLabel10.Size = new System.Drawing.Size(106, 15);
            this.kryptonWrapLabel10.Text = "Monto Detracción:";
            // 
            // kryptonWrapLabel9
            // 
            this.kryptonWrapLabel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel9.Location = new System.Drawing.Point(199, 264);
            this.kryptonWrapLabel9.Name = "kryptonWrapLabel9";
            this.kryptonWrapLabel9.Size = new System.Drawing.Size(96, 15);
            this.kryptonWrapLabel9.Text = "Monto En Letras:";
            // 
            // kryptonWrapLabel8
            // 
            this.kryptonWrapLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel8.Location = new System.Drawing.Point(10, 262);
            this.kryptonWrapLabel8.Name = "kryptonWrapLabel8";
            this.kryptonWrapLabel8.Size = new System.Drawing.Size(86, 15);
            this.kryptonWrapLabel8.Text = "Fecha Emisión:";
            // 
            // kryptonWrapLabel7
            // 
            this.kryptonWrapLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel7.Location = new System.Drawing.Point(549, 226);
            this.kryptonWrapLabel7.Name = "kryptonWrapLabel7";
            this.kryptonWrapLabel7.Size = new System.Drawing.Size(108, 15);
            this.kryptonWrapLabel7.Text = "Monto Percepción:";
            // 
            // kryptonWrapLabel6
            // 
            this.kryptonWrapLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel6.Location = new System.Drawing.Point(204, 226);
            this.kryptonWrapLabel6.Name = "kryptonWrapLabel6";
            this.kryptonWrapLabel6.Size = new System.Drawing.Size(92, 15);
            this.kryptonWrapLabel6.Text = "Tipo Operación:";
            // 
            // kryptonWrapLabel5
            // 
            this.kryptonWrapLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel5.Location = new System.Drawing.Point(12, 228);
            this.kryptonWrapLabel5.Name = "kryptonWrapLabel5";
            this.kryptonWrapLabel5.Size = new System.Drawing.Size(86, 15);
            this.kryptonWrapLabel5.Text = "Id Documento:";
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(705, 5);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(110, 15);
            this.kryptonWrapLabel4.Text = "Calculo Detracción:";
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(526, 5);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(70, 15);
            this.kryptonWrapLabel3.Text = "Cálculo ISC:";
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(331, 5);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(71, 15);
            this.kryptonWrapLabel2.Text = "Cálculo IGV:";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(10, 8);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(116, 15);
            this.kryptonWrapLabel1.Text = "Tipo de Documento:";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kryptonPanel2);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPage3.Text = "Resumen Diario";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "EFEEC9CCB4B244C40F9DACF2002D46B2";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.cbmoneda);
            this.kryptonPanel2.Controls.Add(this.txtCorrel);
            this.kryptonPanel2.Controls.Add(this.label10);
            this.kryptonPanel2.Controls.Add(this.label11);
            this.kryptonPanel2.Controls.Add(this.dglista);
            this.kryptonPanel2.Controls.Add(this.label12);
            this.kryptonPanel2.Controls.Add(this.txtDocInicio);
            this.kryptonPanel2.Controls.Add(this.txtTotVentaGraba);
            this.kryptonPanel2.Controls.Add(this.label13);
            this.kryptonPanel2.Controls.Add(this.txtIGV);
            this.kryptonPanel2.Controls.Add(this.txtDocFin);
            this.kryptonPanel2.Controls.Add(this.txtTotVenta);
            this.kryptonPanel2.Controls.Add(this.label15);
            this.kryptonPanel2.Controls.Add(this.label23);
            this.kryptonPanel2.Controls.Add(this.txtSerie);
            this.kryptonPanel2.Controls.Add(this.label22);
            this.kryptonPanel2.Controls.Add(this.label14);
            this.kryptonPanel2.Controls.Add(this.GResumenDiario);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPanel2.TabIndex = 137;
            // 
            // cbmoneda
            // 
            this.cbmoneda.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "Moneda", true));
            this.cbmoneda.DataSource = this.monedaBindingSource;
            this.cbmoneda.DisplayMember = "Descripcion";
            this.cbmoneda.FormattingEnabled = true;
            this.cbmoneda.Location = new System.Drawing.Point(384, 77);
            this.cbmoneda.Name = "cbmoneda";
            this.cbmoneda.Size = new System.Drawing.Size(100, 21);
            this.cbmoneda.TabIndex = 135;
            this.cbmoneda.ValueMember = "Codigo";
            // 
            // txtCorrel
            // 
            this.txtCorrel.Location = new System.Drawing.Point(157, 33);
            this.txtCorrel.Name = "txtCorrel";
            this.txtCorrel.Size = new System.Drawing.Size(100, 22);
            this.txtCorrel.TabIndex = 117;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(301, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 134;
            this.label10.Values.Text = "Moneda:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(23, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 20);
            this.label11.TabIndex = 116;
            this.label11.Values.Text = "Correlativo Documento:";
            // 
            // dglista
            // 
            this.dglista.AllowUserToAddRows = false;
            this.dglista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dglista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipdoc,
            this.serie,
            this.inicio,
            this.fin,
            this.moneda,
            this.totventa,
            this.totigv,
            this.totgravadas});
            this.dglista.Location = new System.Drawing.Point(46, 244);
            this.dglista.Name = "dglista";
            this.dglista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglista.Size = new System.Drawing.Size(722, 150);
            this.dglista.TabIndex = 133;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 43;
            // 
            // tipdoc
            // 
            this.tipdoc.HeaderText = "Tipo Dcoumento";
            this.tipdoc.Name = "tipdoc";
            this.tipdoc.Width = 107;
            // 
            // serie
            // 
            this.serie.HeaderText = "Serie";
            this.serie.Name = "serie";
            this.serie.Width = 57;
            // 
            // inicio
            // 
            this.inicio.HeaderText = "Correl. Inicio";
            this.inicio.Name = "inicio";
            this.inicio.Width = 89;
            // 
            // fin
            // 
            this.fin.HeaderText = "Correl. Fin";
            this.fin.Name = "fin";
            this.fin.Width = 78;
            // 
            // moneda
            // 
            this.moneda.HeaderText = "Moneda";
            this.moneda.Name = "moneda";
            this.moneda.Width = 75;
            // 
            // totventa
            // 
            this.totventa.HeaderText = "Total Venta";
            this.totventa.Name = "totventa";
            this.totventa.Width = 83;
            // 
            // totigv
            // 
            this.totigv.HeaderText = "Total IGV";
            this.totigv.Name = "totigv";
            this.totigv.Width = 72;
            // 
            // totgravadas
            // 
            this.totgravadas.HeaderText = "Total Gravadas";
            this.totgravadas.Name = "totgravadas";
            this.totgravadas.Width = 98;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(83, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 118;
            this.label12.Values.Text = "Doc. Inicio";
            // 
            // txtDocInicio
            // 
            this.txtDocInicio.Location = new System.Drawing.Point(157, 112);
            this.txtDocInicio.Name = "txtDocInicio";
            this.txtDocInicio.Size = new System.Drawing.Size(100, 22);
            this.txtDocInicio.TabIndex = 119;
            // 
            // txtTotVentaGraba
            // 
            this.txtTotVentaGraba.Location = new System.Drawing.Point(625, 83);
            this.txtTotVentaGraba.Name = "txtTotVentaGraba";
            this.txtTotVentaGraba.Size = new System.Drawing.Size(100, 22);
            this.txtTotVentaGraba.TabIndex = 131;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(94, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 120;
            this.label13.Values.Text = "Doc. Fin";
            // 
            // txtIGV
            // 
            this.txtIGV.Location = new System.Drawing.Point(384, 148);
            this.txtIGV.Name = "txtIGV";
            this.txtIGV.Size = new System.Drawing.Size(100, 22);
            this.txtIGV.TabIndex = 130;
            // 
            // txtDocFin
            // 
            this.txtDocFin.Location = new System.Drawing.Point(157, 153);
            this.txtDocFin.Name = "txtDocFin";
            this.txtDocFin.Size = new System.Drawing.Size(100, 22);
            this.txtDocFin.TabIndex = 121;
            // 
            // txtTotVenta
            // 
            this.txtTotVenta.Location = new System.Drawing.Point(384, 115);
            this.txtTotVenta.Name = "txtTotVenta";
            this.txtTotVenta.Size = new System.Drawing.Size(100, 22);
            this.txtTotVenta.TabIndex = 129;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(107, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 20);
            this.label15.TabIndex = 124;
            this.label15.Values.Text = "Serie:";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(253, 119);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 20);
            this.label23.TabIndex = 128;
            this.label23.Values.Text = "Total Venta Grabada:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(157, 76);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 22);
            this.txtSerie.TabIndex = 125;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(293, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 20);
            this.label22.TabIndex = 127;
            this.label22.Values.Text = "Total IGV:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(544, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 20);
            this.label14.TabIndex = 126;
            this.label14.Values.Text = "Total Venta:";
            // 
            // GResumenDiario
            // 
            this.GResumenDiario.Location = new System.Drawing.Point(10, 5);
            this.GResumenDiario.Name = "GResumenDiario";
            // 
            // GResumenDiario.Panel
            // 
            this.GResumenDiario.Panel.Controls.Add(this.kryptonButton1);
            this.GResumenDiario.Panel.Controls.Add(this.btnAgregarLista);
            this.GResumenDiario.Size = new System.Drawing.Size(936, 438);
            this.GResumenDiario.TabIndex = 137;
            this.GResumenDiario.Values.Heading = "Datos";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(765, 289);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 1;
            this.kryptonButton1.Values.Image = global::FinalXML.Properties.Resources.delete1;
            this.kryptonButton1.Values.Text = "&Eliminar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btnAgregarLista
            // 
            this.btnAgregarLista.Location = new System.Drawing.Point(309, 176);
            this.btnAgregarLista.Name = "btnAgregarLista";
            this.btnAgregarLista.Size = new System.Drawing.Size(128, 25);
            this.btnAgregarLista.TabIndex = 0;
            this.btnAgregarLista.Values.Image = global::FinalXML.Properties.Resources._new;
            this.btnAgregarLista.Values.Text = "&Agregar a la Lista";
            this.btnAgregarLista.Click += new System.EventHandler(this.btnAgregarLista_Click);
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Controls.Add(this.kryptonPanel3);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPage4.Text = "Comunicación de Baja";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "598C650F5FA84007F1AEE9701A8521CA";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.txtcorrelativo2);
            this.kryptonPanel3.Controls.Add(this.label27);
            this.kryptonPanel3.Controls.Add(this.label26);
            this.kryptonPanel3.Controls.Add(this.label31);
            this.kryptonPanel3.Controls.Add(this.txtmotivo);
            this.kryptonPanel3.Controls.Add(this.textBox7);
            this.kryptonPanel3.Controls.Add(this.textBox1);
            this.kryptonPanel3.Controls.Add(this.label25);
            this.kryptonPanel3.Controls.Add(this.dglista2);
            this.kryptonPanel3.Controls.Add(this.label24);
            this.kryptonPanel3.Controls.Add(this.comboBox1);
            this.kryptonPanel3.Controls.Add(this.GComunicacionBaja);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPanel3.TabIndex = 145;
            // 
            // txtcorrelativo2
            // 
            this.txtcorrelativo2.Location = new System.Drawing.Point(165, 38);
            this.txtcorrelativo2.Name = "txtcorrelativo2";
            this.txtcorrelativo2.Size = new System.Drawing.Size(100, 22);
            this.txtcorrelativo2.TabIndex = 144;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(23, 40);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(140, 20);
            this.label27.TabIndex = 143;
            this.label27.Values.Text = "Correlativo Documento:";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(463, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(127, 20);
            this.label26.TabIndex = 142;
            this.label26.Values.Text = "Motivo de Anulación:";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(97, 122);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(40, 20);
            this.label31.TabIndex = 116;
            this.label31.Values.Text = "Serie:";
            // 
            // txtmotivo
            // 
            this.txtmotivo.Location = new System.Drawing.Point(362, 68);
            this.txtmotivo.Multiline = true;
            this.txtmotivo.Name = "txtmotivo";
            this.txtmotivo.Size = new System.Drawing.Size(350, 79);
            this.txtmotivo.TabIndex = 119;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(165, 115);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 117;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(165, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 118;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(64, 157);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 20);
            this.label25.TabIndex = 139;
            this.label25.Values.Text = "Numeración:";
            // 
            // dglista2
            // 
            this.dglista2.AllowUserToAddRows = false;
            this.dglista2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dglista2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglista2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.motivo});
            this.dglista2.Location = new System.Drawing.Point(31, 249);
            this.dglista2.Name = "dglista2";
            this.dglista2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglista2.Size = new System.Drawing.Size(722, 150);
            this.dglista2.TabIndex = 133;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 26.66996F;
            this.dataGridViewTextBoxColumn8.HeaderText = "ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 69.28292F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Tipo Documento";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 72.77803F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Serie";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 77.46198F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Correlativo";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // motivo
            // 
            this.motivo.FillWeight = 253.8071F;
            this.motivo.HeaderText = "Motivo";
            this.motivo.Name = "motivo";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(37, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(122, 20);
            this.label24.TabIndex = 137;
            this.label24.Values.Text = "Tipo de Documento:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "TipoDocumento", true));
            this.comboBox1.DataSource = this.tipoDocumentoBindingSource;
            this.comboBox1.DisplayMember = "Descripcion";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(165, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 138;
            this.comboBox1.ValueMember = "Codigo";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted_1);
            // 
            // GComunicacionBaja
            // 
            this.GComunicacionBaja.Location = new System.Drawing.Point(10, 11);
            this.GComunicacionBaja.Name = "GComunicacionBaja";
            // 
            // GComunicacionBaja.Panel
            // 
            this.GComunicacionBaja.Panel.Controls.Add(this.kryptonButton6);
            this.GComunicacionBaja.Panel.Controls.Add(this.kryptonButton3);
            this.GComunicacionBaja.Panel.Controls.Add(this.kryptonButton2);
            this.GComunicacionBaja.Size = new System.Drawing.Size(900, 444);
            this.GComunicacionBaja.TabIndex = 145;
            this.GComunicacionBaja.Values.Heading = "Datos";
            // 
            // kryptonButton6
            // 
            this.kryptonButton6.Location = new System.Drawing.Point(326, 379);
            this.kryptonButton6.Name = "kryptonButton6";
            this.kryptonButton6.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.kryptonButton6.Size = new System.Drawing.Size(146, 31);
            this.kryptonButton6.TabIndex = 236;
            this.kryptonButton6.Values.Image = global::FinalXML.Properties.Resources.UI_11_24;
            this.kryptonButton6.Values.Text = "&Nuevo Documento";
            this.kryptonButton6.Click += new System.EventHandler(this.kryptonButton6_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(748, 277);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton3.TabIndex = 1;
            this.kryptonButton3.Values.Image = global::FinalXML.Properties.Resources.delete;
            this.kryptonButton3.Values.Text = "&Eliminar";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(314, 179);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(123, 25);
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Image = global::FinalXML.Properties.Resources._new;
            this.kryptonButton2.Values.Text = "Agregar a la Lista";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonPage5
            // 
            this.kryptonPage5.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage5.Controls.Add(this.kryptonPanel4);
            this.kryptonPage5.Flags = 65534;
            this.kryptonPage5.LastVisibleSet = true;
            this.kryptonPage5.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage5.Name = "kryptonPage5";
            this.kryptonPage5.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPage5.Text = "Comprobante de Retención";
            this.kryptonPage5.ToolTipTitle = "Page ToolTip";
            this.kryptonPage5.UniqueName = "E5536866571547291787C292F7D9888E";
            this.kryptonPage5.Visible = false;
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Controls.Add(this.GDatosDocumento);
            this.kryptonPanel4.Controls.Add(this.GDatosReceptor);
            this.kryptonPanel4.Controls.Add(this.txtValorReten);
            this.kryptonPanel4.Controls.Add(this.label52);
            this.kryptonPanel4.Controls.Add(this.txtCorrelativo3);
            this.kryptonPanel4.Controls.Add(this.dgreten);
            this.kryptonPanel4.Controls.Add(this.label63);
            this.kryptonPanel4.Controls.Add(this.label62);
            this.kryptonPanel4.Controls.Add(this.dtpFecha2);
            this.kryptonPanel4.Controls.Add(this.GRetencion);
            this.kryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel4.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(1112, 665);
            this.kryptonPanel4.TabIndex = 140;
            // 
            // GDatosDocumento
            // 
            this.GDatosDocumento.Location = new System.Drawing.Point(29, 163);
            this.GDatosDocumento.Name = "GDatosDocumento";
            // 
            // GDatosDocumento.Panel
            // 
            this.GDatosDocumento.Panel.Controls.Add(this.kryptonButton4);
            this.GDatosDocumento.Panel.Controls.Add(this.txtMontoPago);
            this.GDatosDocumento.Panel.Controls.Add(this.txtNum);
            this.GDatosDocumento.Panel.Controls.Add(this.cboMoneda2);
            this.GDatosDocumento.Panel.Controls.Add(this.label49);
            this.GDatosDocumento.Panel.Controls.Add(this.label58);
            this.GDatosDocumento.Panel.Controls.Add(this.label51);
            this.GDatosDocumento.Panel.Controls.Add(this.label50);
            this.GDatosDocumento.Panel.Controls.Add(this.dtpFecha3);
            this.GDatosDocumento.Size = new System.Drawing.Size(1048, 96);
            this.GDatosDocumento.TabIndex = 141;
            this.GDatosDocumento.Values.Heading = "Datos del Documento";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(839, 19);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(129, 25);
            this.kryptonButton4.TabIndex = 123;
            this.kryptonButton4.Values.Image = global::FinalXML.Properties.Resources._new;
            this.kryptonButton4.Values.Text = "&Agregar a la Lista";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.Location = new System.Drawing.Point(506, 23);
            this.txtMontoPago.MaxLength = 11;
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(108, 22);
            this.txtMontoPago.TabIndex = 6;
            this.txtMontoPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPago_KeyPress_1);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(95, 21);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(112, 22);
            this.txtNum.TabIndex = 5;
            // 
            // cboMoneda2
            // 
            this.cboMoneda2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoElectronicoBindingSource, "Moneda", true));
            this.cboMoneda2.DataSource = this.monedaBindingSource;
            this.cboMoneda2.DisplayMember = "Descripcion";
            this.cboMoneda2.FormattingEnabled = true;
            this.cboMoneda2.Location = new System.Drawing.Point(698, 23);
            this.cboMoneda2.Name = "cboMoneda2";
            this.cboMoneda2.Size = new System.Drawing.Size(100, 21);
            this.cboMoneda2.TabIndex = 7;
            this.cboMoneda2.ValueMember = "Codigo";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(5, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(95, 20);
            this.label49.TabIndex = 0;
            this.label49.Values.Text = "Nº Documento:";
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(633, 25);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(59, 20);
            this.label58.TabIndex = 120;
            this.label58.Values.Text = "Moneda:";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(411, 23);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(101, 20);
            this.label51.TabIndex = 122;
            this.label51.Values.Text = "Monto del Pago:";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(210, 23);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(90, 20);
            this.label50.TabIndex = 120;
            this.label50.Values.Text = "Fecha Emisión:";
            // 
            // dtpFecha3
            // 
            this.dtpFecha3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "FechaEmision", true));
            this.dtpFecha3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha3.Location = new System.Drawing.Point(301, 21);
            this.dtpFecha3.Name = "dtpFecha3";
            this.dtpFecha3.Size = new System.Drawing.Size(100, 22);
            this.dtpFecha3.TabIndex = 121;
            // 
            // GDatosReceptor
            // 
            this.GDatosReceptor.Location = new System.Drawing.Point(26, 56);
            this.GDatosReceptor.Name = "GDatosReceptor";
            // 
            // GDatosReceptor.Panel
            // 
            this.GDatosReceptor.Panel.Controls.Add(this.cboTipoDocRec2);
            this.GDatosReceptor.Panel.Controls.Add(this.txtNomCliente);
            this.GDatosReceptor.Panel.Controls.Add(this.label61);
            this.GDatosReceptor.Panel.Controls.Add(this.txtNroCliente);
            this.GDatosReceptor.Panel.Controls.Add(this.label60);
            this.GDatosReceptor.Panel.Controls.Add(this.label59);
            this.GDatosReceptor.Size = new System.Drawing.Size(1052, 104);
            this.GDatosReceptor.TabIndex = 140;
            this.GDatosReceptor.Values.Heading = "Datos del Receptor";
            // 
            // cboTipoDocRec2
            // 
            this.cboTipoDocRec2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.receptorBindingSource, "TipoDocumento", true));
            this.cboTipoDocRec2.DataSource = this.tipoDocumentoContribuyenteBindingSource;
            this.cboTipoDocRec2.DisplayMember = "Descripcion";
            this.cboTipoDocRec2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocRec2.FormattingEnabled = true;
            this.cboTipoDocRec2.Location = new System.Drawing.Point(69, 26);
            this.cboTipoDocRec2.Name = "cboTipoDocRec2";
            this.cboTipoDocRec2.Size = new System.Drawing.Size(194, 21);
            this.cboTipoDocRec2.TabIndex = 2;
            this.cboTipoDocRec2.ValueMember = "Codigo";
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.Location = new System.Drawing.Point(680, 24);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.Size = new System.Drawing.Size(343, 22);
            this.txtNomCliente.TabIndex = 4;
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(293, 26);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(64, 20);
            this.label61.TabIndex = 8;
            this.label61.Values.Text = "Nro. Doc.:";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.Location = new System.Drawing.Point(376, 24);
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.Size = new System.Drawing.Size(194, 22);
            this.txtNroCliente.TabIndex = 3;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(583, 26);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(91, 20);
            this.label60.TabIndex = 9;
            this.label60.Values.Text = "Nombre Legal:";
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(6, 26);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(62, 20);
            this.label59.TabIndex = 7;
            this.label59.Values.Text = "Tipo Doc:";
            // 
            // txtValorReten
            // 
            this.txtValorReten.Location = new System.Drawing.Point(543, 33);
            this.txtValorReten.Name = "txtValorReten";
            this.txtValorReten.Size = new System.Drawing.Size(88, 22);
            this.txtValorReten.TabIndex = 139;
            this.txtValorReten.Text = "0.03";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(441, 35);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(100, 20);
            this.label52.TabIndex = 138;
            this.label52.Values.Text = "Valor Retencion:";
            // 
            // txtCorrelativo3
            // 
            this.txtCorrelativo3.Location = new System.Drawing.Point(107, 35);
            this.txtCorrelativo3.Name = "txtCorrelativo3";
            this.txtCorrelativo3.Size = new System.Drawing.Size(100, 22);
            this.txtCorrelativo3.TabIndex = 1;
            // 
            // dgreten
            // 
            this.dgreten.AllowUserToAddRows = false;
            this.dgreten.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgreten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgreten.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.correl,
            this.num,
            this.fecha,
            this.monedas,
            this.monto,
            this.retenido});
            this.dgreten.Location = new System.Drawing.Point(28, 263);
            this.dgreten.Name = "dgreten";
            this.dgreten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgreten.Size = new System.Drawing.Size(802, 150);
            this.dgreten.TabIndex = 134;
            // 
            // correl
            // 
            this.correl.FillWeight = 26.66996F;
            this.correl.HeaderText = "ID";
            this.correl.Name = "correl";
            // 
            // num
            // 
            this.num.HeaderText = "Numeración";
            this.num.Name = "num";
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha Emisión";
            this.fecha.Name = "fecha";
            // 
            // monedas
            // 
            this.monedas.HeaderText = "Moneda";
            this.monedas.Name = "monedas";
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto del Pago";
            this.monto.Name = "monto";
            // 
            // retenido
            // 
            this.retenido.HeaderText = "Importe Retenido";
            this.retenido.Name = "retenido";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(19, 36);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(91, 20);
            this.label63.TabIndex = 116;
            this.label63.Values.Text = "Id Documento:";
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(218, 37);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(90, 20);
            this.label62.TabIndex = 118;
            this.label62.Values.Text = "Fecha Emisión:";
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoElectronicoBindingSource, "FechaEmision", true));
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(322, 35);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(100, 22);
            this.dtpFecha2.TabIndex = 119;
            // 
            // GRetencion
            // 
            this.GRetencion.Location = new System.Drawing.Point(9, 3);
            this.GRetencion.Name = "GRetencion";
            // 
            // GRetencion.Panel
            // 
            this.GRetencion.Panel.Controls.Add(this.kryptonButton5);
            this.GRetencion.Size = new System.Drawing.Size(1097, 435);
            this.GRetencion.TabIndex = 142;
            this.GRetencion.Values.Heading = "Datos";
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.Location = new System.Drawing.Point(825, 294);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton5.TabIndex = 0;
            this.kryptonButton5.Values.Image = global::FinalXML.Properties.Resources.delete;
            this.kryptonButton5.Values.Text = "&Eliminar";
            this.kryptonButton5.Click += new System.EventHandler(this.kryptonButton5_Click);
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1415, 716);
            this.kryptonPage1.Text = "kryptonPage1";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "A2DF5C121083410569ADFD2081E15564";
            // 
            // FrmDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1114, 717);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmDocumento";
            this.Text = "Facturación V1.0";
            this.Load += new System.EventHandler(this.FrmDocumento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receptorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoContribuyenteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emisorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentoElectronicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoOperacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoAnticipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monedaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallesBindingSource)).EndInit();
            this.tbPaginas.ResumeLayout(false);
            this.tpDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.tpAdicionales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datoAdicionalesDataGridView)).EndInit();
            this.tpRelacionados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.relacionadosDataGridView)).EndInit();
            this.tbDiscrepancias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor.Panel)).EndInit();
            this.grpEmisor.Panel.ResumeLayout(false);
            this.grpEmisor.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmisor)).EndInit();
            this.grpEmisor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GResumenDiario.Panel)).EndInit();
            this.GResumenDiario.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GResumenDiario)).EndInit();
            this.GResumenDiario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.kryptonPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglista2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GComunicacionBaja.Panel)).EndInit();
            this.GComunicacionBaja.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GComunicacionBaja)).EndInit();
            this.GComunicacionBaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).EndInit();
            this.kryptonPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            this.kryptonPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosDocumento.Panel)).EndInit();
            this.GDatosDocumento.Panel.ResumeLayout(false);
            this.GDatosDocumento.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosDocumento)).EndInit();
            this.GDatosDocumento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GDatosReceptor.Panel)).EndInit();
            this.GDatosReceptor.Panel.ResumeLayout(false);
            this.GDatosReceptor.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDatosReceptor)).EndInit();
            this.GDatosReceptor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgreten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRetencion.Panel)).EndInit();
            this.GRetencion.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRetencion)).EndInit();
            this.GRetencion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolGenerar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource tipoDocumentoBindingSource;
        private System.Windows.Forms.BindingSource documentoElectronicoBindingSource;
        private System.Windows.Forms.BindingSource receptorBindingSource;
        private System.Windows.Forms.BindingSource tipoDocumentoContribuyenteBindingSource;
        private System.Windows.Forms.BindingSource datoAdicionalesBindingSource;
        private System.Windows.Forms.BindingSource relacionadosBindingSource;
        private System.Windows.Forms.BindingSource discrepanciasBindingSource;
        private System.Windows.Forms.BindingSource tipoOperacionBindingSource;
        private System.Windows.Forms.BindingSource tipoDocumentoAnticipoBindingSource;
        private System.Windows.Forms.BindingSource monedaBindingSource;
        private System.Windows.Forms.BindingSource detallesBindingSource;
        private System.Windows.Forms.BindingSource emisorBindingSource;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox calculoDetraccionTextBox;
        private System.Windows.Forms.TextBox calculoIscTextBox;
        private System.Windows.Forms.TextBox calculoIgvTextBox;
        private System.Windows.Forms.ComboBox monedaAnticipoComboBox;
        private System.Windows.Forms.TextBox montoAnticipoTextBox;
        private System.Windows.Forms.TextBox docAnticipoTextBox;
        private System.Windows.Forms.ComboBox tipoDocAnticipoComboBox;
        private System.Windows.Forms.Button btnGuia;
        private System.Windows.Forms.TextBox montoDetraccionTextBox;
        private System.Windows.Forms.TabControl tbPaginas;
        private System.Windows.Forms.TabPage tpDetalles;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioReferencialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPrecioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impuestoSelectivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otroImpuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tpAdicionales;
        private System.Windows.Forms.DataGridView datoAdicionalesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tpRelacionados;
        private System.Windows.Forms.DataGridView relacionadosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tbDiscrepancias;
        private System.Windows.Forms.DataGridView discrepanciasDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox montoPercepcionTextBox;
        private System.Windows.Forms.TextBox descuentoGlobalTextBox;
        private System.Windows.Forms.TextBox totalVentaTextBox;
        private System.Windows.Forms.TextBox totalOtrosTributosTextBox;
        private System.Windows.Forms.TextBox totalIscTextBox;
        private System.Windows.Forms.TextBox totalIgvTextBox;
        private System.Windows.Forms.ComboBox tipoOperacionComboBox;
        private System.Windows.Forms.TextBox gratuitasTextBox;
        private System.Windows.Forms.TextBox inafectasTextBox;
        private System.Windows.Forms.TextBox exoneradasTextBox;
        private System.Windows.Forms.TextBox gravadasTextBox;
        private System.Windows.Forms.TextBox montoEnLetrasTextBox;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox urbanizacionTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private System.Windows.Forms.TextBox txtUbigeoEm;
        private System.Windows.Forms.TextBox txtDistritoEm;
        private System.Windows.Forms.TextBox txtDptoEm;
        private System.Windows.Forms.TextBox txtProvEm;
        private System.Windows.Forms.TextBox txtDirEm;
        private System.Windows.Forms.TextBox txtNombreComEm;
        private System.Windows.Forms.TextBox txtNombreLegalEm;
        private System.Windows.Forms.TextBox txtNroDocEm;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage3;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage4;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private System.Windows.Forms.ComboBox cbmoneda;
        private System.Windows.Forms.TextBox txtCorrel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label11;
        private System.Windows.Forms.DataGridView dglista;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipdoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn totventa;
        private System.Windows.Forms.DataGridViewTextBoxColumn totigv;
        private System.Windows.Forms.DataGridViewTextBoxColumn totgravadas;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label12;
        private System.Windows.Forms.TextBox txtDocInicio;
        private System.Windows.Forms.TextBox txtTotVentaGraba;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label13;
        private System.Windows.Forms.TextBox txtIGV;
        private System.Windows.Forms.TextBox txtDocFin;
        private System.Windows.Forms.TextBox txtTotVenta;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label15;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label23;
        private System.Windows.Forms.TextBox txtSerie;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label22;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label14;
        private System.Windows.Forms.TextBox txtcorrelativo2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label27;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label26;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label31;
        private System.Windows.Forms.TextBox txtmotivo;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label25;
        private System.Windows.Forms.DataGridView dglista2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label24;
        private System.Windows.Forms.ComboBox comboBox1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage5;
        private System.Windows.Forms.TextBox txtValorReten;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label52;
        private System.Windows.Forms.TextBox txtCorrelativo3;
        private System.Windows.Forms.ComboBox cboTipoDocRec2;
        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtNroCliente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label59;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label60;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label61;
        private System.Windows.Forms.DataGridView dgreten;
        private System.Windows.Forms.DataGridViewTextBoxColumn correl;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedas;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn retenido;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label63;
        private System.Windows.Forms.TextBox txtMontoPago;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label51;
        private System.Windows.Forms.DateTimePicker dtpFecha3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label50;
        private System.Windows.Forms.TextBox txtNum;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label49;
        private System.Windows.Forms.ComboBox cboMoneda2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label58;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label62;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpEmisor;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.TextBox txtDirRec;
        private System.Windows.Forms.ComboBox cboTipoDocRec;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label28;
        private System.Windows.Forms.TextBox txtNroDocRec;
        private System.Windows.Forms.TextBox txtNombreLegalRec;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GResumenDiario;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GComunicacionBaja;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GDatosReceptor;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GDatosDocumento;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox GRetencion;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEliminar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDuplicar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcDetraccion;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregarLista;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnResetForm;
        private System.Windows.Forms.TextBox txttexto;
        private System.Windows.Forms.PictureBox pictureCapcha;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton6;
    }
}