namespace FinalXML
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chkVoz = new System.Windows.Forms.CheckBox();
            this.cboUrlServicio = new System.Windows.Forms.ComboBox();
            this.direccionSunatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.rbResumen = new System.Windows.Forms.RadioButton();
            this.rbRetenciones = new System.Windows.Forms.RadioButton();
            this.txtRutaCertificado = new System.Windows.Forms.TextBox();
            this.rbDocumentos = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtClaveSol = new System.Windows.Forms.TextBox();
            this.txtUsuarioSol = new System.Windows.Forms.TextBox();
            this.txtNroRuc = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txtSerieCorrelativo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnGetStatus = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGenerar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBrowseCert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonWrapLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonWrapLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.txtPassCertificado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.direccionSunatBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkVoz
            // 
            this.chkVoz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVoz.AutoSize = true;
            this.chkVoz.Checked = true;
            this.chkVoz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVoz.Location = new System.Drawing.Point(377, 599);
            this.chkVoz.Name = "chkVoz";
            this.chkVoz.Size = new System.Drawing.Size(118, 17);
            this.chkVoz.TabIndex = 51;
            this.chkVoz.Text = "Hablar en voz alta";
            this.chkVoz.UseVisualStyleBackColor = true;
            this.chkVoz.Visible = false;
            // 
            // cboUrlServicio
            // 
            this.cboUrlServicio.DataSource = this.direccionSunatBindingSource;
            this.cboUrlServicio.DisplayMember = "Codigo";
            this.cboUrlServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUrlServicio.Location = new System.Drawing.Point(12, 22);
            this.cboUrlServicio.Name = "cboUrlServicio";
            this.cboUrlServicio.Size = new System.Drawing.Size(453, 21);
            this.cboUrlServicio.TabIndex = 27;
            this.cboUrlServicio.ValueMember = "Descripcion";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.Items.AddRange(new object[] {
            "Factura",
            "Boleta",
            "Nota de Crédito",
            "Nota de Débito",
            "Retención",
            "Percepción",
            "Resumen Diario",
            "Comunicacion de Baja"});
            this.cboTipoDoc.Location = new System.Drawing.Point(182, 177);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(201, 21);
            this.cboTipoDoc.TabIndex = 36;
            // 
            // rbResumen
            // 
            this.rbResumen.AutoSize = true;
            this.rbResumen.Location = new System.Drawing.Point(14, 70);
            this.rbResumen.Name = "rbResumen";
            this.rbResumen.Size = new System.Drawing.Size(197, 17);
            this.rbResumen.TabIndex = 2;
            this.rbResumen.Text = "Resumen y Comunicacion de baja";
            this.rbResumen.UseVisualStyleBackColor = true;
            // 
            // rbRetenciones
            // 
            this.rbRetenciones.AutoSize = true;
            this.rbRetenciones.Location = new System.Drawing.Point(14, 43);
            this.rbRetenciones.Name = "rbRetenciones";
            this.rbRetenciones.Size = new System.Drawing.Size(166, 17);
            this.rbRetenciones.TabIndex = 1;
            this.rbRetenciones.Text = "Retenciones y Percepciones";
            this.rbRetenciones.UseVisualStyleBackColor = true;
            // 
            // txtRutaCertificado
            // 
            this.txtRutaCertificado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRutaCertificado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRutaCertificado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtRutaCertificado.Location = new System.Drawing.Point(12, 239);
            this.txtRutaCertificado.Name = "txtRutaCertificado";
            this.txtRutaCertificado.ReadOnly = true;
            this.txtRutaCertificado.Size = new System.Drawing.Size(319, 22);
            this.txtRutaCertificado.TabIndex = 38;
            // 
            // rbDocumentos
            // 
            this.rbDocumentos.AutoSize = true;
            this.rbDocumentos.Checked = true;
            this.rbDocumentos.Location = new System.Drawing.Point(14, 18);
            this.rbDocumentos.Name = "rbDocumentos";
            this.rbDocumentos.Size = new System.Drawing.Size(145, 17);
            this.rbDocumentos.TabIndex = 0;
            this.rbDocumentos.TabStop = true;
            this.rbDocumentos.Text = "Factura, Boleta, NC, ND";
            this.rbDocumentos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbResumen);
            this.groupBox1.Controls.Add(this.rbRetenciones);
            this.groupBox1.Controls.Add(this.rbDocumentos);
            this.groupBox1.Location = new System.Drawing.Point(182, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 104);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo de Documentos";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.SystemColors.Info;
            this.txtResult.Location = new System.Drawing.Point(12, 464);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(310, 143);
            this.txtResult.TabIndex = 48;
            // 
            // txtClaveSol
            // 
            this.txtClaveSol.Location = new System.Drawing.Point(12, 176);
            this.txtClaveSol.Name = "txtClaveSol";
            this.txtClaveSol.PasswordChar = '*';
            this.txtClaveSol.ReadOnly = true;
            this.txtClaveSol.Size = new System.Drawing.Size(153, 22);
            this.txtClaveSol.TabIndex = 33;
            // 
            // txtUsuarioSol
            // 
            this.txtUsuarioSol.AutoCompleteCustomSource.AddRange(new string[] {
            "MODDATOS"});
            this.txtUsuarioSol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUsuarioSol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUsuarioSol.Location = new System.Drawing.Point(12, 125);
            this.txtUsuarioSol.Name = "txtUsuarioSol";
            this.txtUsuarioSol.ReadOnly = true;
            this.txtUsuarioSol.Size = new System.Drawing.Size(153, 22);
            this.txtUsuarioSol.TabIndex = 31;
            // 
            // txtNroRuc
            // 
            this.txtNroRuc.Location = new System.Drawing.Point(12, 67);
            this.txtNroRuc.MaxLength = 11;
            this.txtNroRuc.Name = "txtNroRuc";
            this.txtNroRuc.ReadOnly = true;
            this.txtNroRuc.Size = new System.Drawing.Size(153, 22);
            this.txtNroRuc.TabIndex = 29;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSource.Location = new System.Drawing.Point(12, 351);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(319, 22);
            this.txtSource.TabIndex = 43;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.chkVoz);
            this.kryptonPanel1.Controls.Add(this.txtSerieCorrelativo);
            this.kryptonPanel1.Controls.Add(this.btnGetStatus);
            this.kryptonPanel1.Controls.Add(this.btnGen);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.btnGenerar);
            this.kryptonPanel1.Controls.Add(this.btnBrowseCert);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel9);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel8);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel7);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel6);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel3);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(514, 659);
            this.kryptonPanel1.TabIndex = 55;
            // 
            // txtSerieCorrelativo
            // 
            this.txtSerieCorrelativo.Location = new System.Drawing.Point(11, 414);
            this.txtSerieCorrelativo.Name = "txtSerieCorrelativo";
            this.txtSerieCorrelativo.Size = new System.Drawing.Size(320, 20);
            this.txtSerieCorrelativo.TabIndex = 82;
            // 
            // btnGetStatus
            // 
            this.btnGetStatus.Location = new System.Drawing.Point(343, 508);
            this.btnGetStatus.Name = "btnGetStatus";
            this.btnGetStatus.Size = new System.Drawing.Size(151, 53);
            this.btnGetStatus.TabIndex = 81;
            this.btnGetStatus.Values.Text = "Consultar N° Ticket";
            this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click_1);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(343, 452);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(151, 32);
            this.btnGen.TabIndex = 80;
            this.btnGen.Values.Image = global::FinalXML.Properties.Resources._199_20;
            this.btnGen.Values.Text = "&Enviar...";
            this.btnGen.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(343, 402);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(151, 32);
            this.kryptonButton2.TabIndex = 79;
            this.kryptonButton2.Values.Image = global::FinalXML.Properties.Resources.pdfs_20;
            this.kryptonButton2.Values.Text = "Generar PDF";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(343, 341);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(152, 32);
            this.kryptonButton1.TabIndex = 78;
            this.kryptonButton1.Values.Image = global::FinalXML.Properties.Resources.examine_24;
            this.kryptonButton1.Values.Text = "Exami&nar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(343, 288);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(152, 32);
            this.btnGenerar.TabIndex = 68;
            this.btnGenerar.Values.Image = global::FinalXML.Properties.Resources._142_xml_export_20;
            this.btnGenerar.Values.Text = "&Emitir Comprobante";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnBrowseCert
            // 
            this.btnBrowseCert.Location = new System.Drawing.Point(343, 229);
            this.btnBrowseCert.Name = "btnBrowseCert";
            this.btnBrowseCert.Size = new System.Drawing.Size(152, 32);
            this.btnBrowseCert.TabIndex = 67;
            this.btnBrowseCert.Values.Image = global::FinalXML.Properties.Resources.examine_24;
            this.btnBrowseCert.Values.Text = "E&xaminar";
            this.btnBrowseCert.Click += new System.EventHandler(this.btnBrowseCert_Click_2);
            // 
            // kryptonWrapLabel9
            // 
            this.kryptonWrapLabel9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel9.Location = new System.Drawing.Point(182, 159);
            this.kryptonWrapLabel9.Name = "kryptonWrapLabel9";
            this.kryptonWrapLabel9.Size = new System.Drawing.Size(116, 15);
            this.kryptonWrapLabel9.Text = "Tipo de Documento:";
            // 
            // kryptonWrapLabel8
            // 
            this.kryptonWrapLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel8.Location = new System.Drawing.Point(15, 394);
            this.kryptonWrapLabel8.Name = "kryptonWrapLabel8";
            this.kryptonWrapLabel8.Size = new System.Drawing.Size(183, 15);
            this.kryptonWrapLabel8.Text = "Serie-Correlativo del Documento:";
            // 
            // kryptonWrapLabel7
            // 
            this.kryptonWrapLabel7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel7.Location = new System.Drawing.Point(12, 333);
            this.kryptonWrapLabel7.Name = "kryptonWrapLabel7";
            this.kryptonWrapLabel7.Size = new System.Drawing.Size(159, 15);
            this.kryptonWrapLabel7.Text = "Seleccione Documento XML:";
            // 
            // kryptonWrapLabel6
            // 
            this.kryptonWrapLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel6.Location = new System.Drawing.Point(15, 280);
            this.kryptonWrapLabel6.Name = "kryptonWrapLabel6";
            this.kryptonWrapLabel6.Size = new System.Drawing.Size(150, 15);
            this.kryptonWrapLabel6.Text = "Contraseña del Certificado:";
            // 
            // kryptonWrapLabel5
            // 
            this.kryptonWrapLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel5.Location = new System.Drawing.Point(12, 221);
            this.kryptonWrapLabel5.Name = "kryptonWrapLabel5";
            this.kryptonWrapLabel5.Size = new System.Drawing.Size(127, 15);
            this.kryptonWrapLabel5.Text = "Seleccione Certificado:";
            // 
            // kryptonWrapLabel4
            // 
            this.kryptonWrapLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel4.Location = new System.Drawing.Point(12, 153);
            this.kryptonWrapLabel4.Name = "kryptonWrapLabel4";
            this.kryptonWrapLabel4.Size = new System.Drawing.Size(63, 15);
            this.kryptonWrapLabel4.Text = "Clave SOL:";
            // 
            // kryptonWrapLabel2
            // 
            this.kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel2.Location = new System.Drawing.Point(12, 107);
            this.kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            this.kryptonWrapLabel2.Size = new System.Drawing.Size(74, 15);
            this.kryptonWrapLabel2.Text = "Usuario SOL:";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(12, 46);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(96, 15);
            this.kryptonWrapLabel1.Text = "Número de RUC:";
            // 
            // kryptonWrapLabel3
            // 
            this.kryptonWrapLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel3.Location = new System.Drawing.Point(12, 4);
            this.kryptonWrapLabel3.Name = "kryptonWrapLabel3";
            this.kryptonWrapLabel3.Size = new System.Drawing.Size(94, 15);
            this.kryptonWrapLabel3.Text = "URL del Servicio:";
            // 
            // txtPassCertificado
            // 
            this.txtPassCertificado.Location = new System.Drawing.Point(12, 298);
            this.txtPassCertificado.Name = "txtPassCertificado";
            this.txtPassCertificado.PasswordChar = '*';
            this.txtPassCertificado.ReadOnly = true;
            this.txtPassCertificado.Size = new System.Drawing.Size(319, 22);
            this.txtPassCertificado.TabIndex = 41;
            this.txtPassCertificado.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 659);
            this.Controls.Add(this.cboUrlServicio);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.txtPassCertificado);
            this.Controls.Add(this.txtRutaCertificado);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtClaveSol);
            this.Controls.Add(this.txtUsuarioSol);
            this.Controls.Add(this.txtNroRuc);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Facturación V1.0 - SGE SYSTEM\'S";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.direccionSunatBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkVoz;
        private System.Windows.Forms.ComboBox cboUrlServicio;
        private System.Windows.Forms.BindingSource direccionSunatBindingSource;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.RadioButton rbResumen;
        private System.Windows.Forms.RadioButton rbRetenciones;
        private System.Windows.Forms.TextBox txtRutaCertificado;
        private System.Windows.Forms.RadioButton rbDocumentos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtClaveSol;
        private System.Windows.Forms.TextBox txtUsuarioSol;
        private System.Windows.Forms.TextBox txtNroRuc;
        private System.Windows.Forms.TextBox txtSource;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel8;
        private System.Windows.Forms.TextBox txtPassCertificado;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowseCert;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGenerar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSerieCorrelativo;
    }
}

