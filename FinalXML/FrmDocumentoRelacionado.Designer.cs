namespace FinalXML
{
    partial class FrmDocumentoRelacionado
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel nroDocumentoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoDocumentoLabel;
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.documentoRelacionadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoDocumentoComboBox = new System.Windows.Forms.ComboBox();
            this.tipoDocumentoRelacionadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nroDocumentoTextBox = new System.Windows.Forms.TextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            nroDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoRelacionadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nroDocumentoLabel
            // 
            nroDocumentoLabel.Location = new System.Drawing.Point(9, 44);
            nroDocumentoLabel.Name = "nroDocumentoLabel";
            nroDocumentoLabel.Size = new System.Drawing.Size(101, 20);
            nroDocumentoLabel.TabIndex = 12;
            nroDocumentoLabel.Values.Text = "Nro Documento:";
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.Location = new System.Drawing.Point(9, 17);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new System.Drawing.Size(105, 20);
            tipoDocumentoLabel.TabIndex = 11;
            tipoDocumentoLabel.Values.Text = "Tipo Documento:";
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(379, 25);
            this.barraBotones.TabIndex = 10;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::FinalXML.Properties.Resources.ok;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            this.toolOk.Click += new System.EventHandler(this.toolOk_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::FinalXML.Properties.Resources.cancel;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            // 
            // documentoRelacionadoBindingSource
            // 
            this.documentoRelacionadoBindingSource.DataSource = typeof(FinalXML.DocumentoRelacionado);
            // 
            // tipoDocumentoComboBox
            // 
            this.tipoDocumentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.documentoRelacionadoBindingSource, "TipoDocumento", true));
            this.tipoDocumentoComboBox.DataSource = this.tipoDocumentoRelacionadoBindingSource;
            this.tipoDocumentoComboBox.DisplayMember = "Descripcion";
            this.tipoDocumentoComboBox.FormattingEnabled = true;
            this.tipoDocumentoComboBox.Location = new System.Drawing.Point(120, 14);
            this.tipoDocumentoComboBox.Name = "tipoDocumentoComboBox";
            this.tipoDocumentoComboBox.Size = new System.Drawing.Size(236, 21);
            this.tipoDocumentoComboBox.TabIndex = 13;
            this.tipoDocumentoComboBox.ValueMember = "Codigo";
            // 
            // tipoDocumentoRelacionadoBindingSource
            // 
            this.tipoDocumentoRelacionadoBindingSource.DataSource = typeof(FinalXML.TipoDocumentoRelacionado);
            // 
            // nroDocumentoTextBox
            // 
            this.nroDocumentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentoRelacionadoBindingSource, "NroDocumento", true));
            this.nroDocumentoTextBox.Location = new System.Drawing.Point(120, 41);
            this.nroDocumentoTextBox.Name = "nroDocumentoTextBox";
            this.nroDocumentoTextBox.Size = new System.Drawing.Size(152, 20);
            this.nroDocumentoTextBox.TabIndex = 14;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(nroDocumentoLabel);
            this.kryptonPanel1.Controls.Add(tipoDocumentoLabel);
            this.kryptonPanel1.Controls.Add(this.tipoDocumentoComboBox);
            this.kryptonPanel1.Controls.Add(this.nroDocumentoTextBox);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(379, 79);
            this.kryptonPanel1.TabIndex = 15;
            // 
            // FrmDocumentoRelacionado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 104);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumentoRelacionado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDocumentoRelacionado";
            this.Load += new System.EventHandler(this.FrmDocumentoRelacionado_Load);
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentoRelacionadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoRelacionadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.BindingSource documentoRelacionadoBindingSource;
        private System.Windows.Forms.ComboBox tipoDocumentoComboBox;
        private System.Windows.Forms.BindingSource tipoDocumentoRelacionadoBindingSource;
        private System.Windows.Forms.TextBox nroDocumentoTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}