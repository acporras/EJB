namespace FinalXML
{
    partial class FrmDiscrepancia
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel descripcionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel nroReferenciaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoLabel;
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.discrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.tipoDiscrepanciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.nroReferenciaTextBox = new System.Windows.Forms.TextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            descripcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            nroReferenciaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.Location = new System.Drawing.Point(2, 65);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(77, 20);
            descripcionLabel.TabIndex = 15;
            descripcionLabel.Values.Text = "Descripcion:";
            // 
            // nroReferenciaLabel
            // 
            nroReferenciaLabel.Location = new System.Drawing.Point(2, 39);
            nroReferenciaLabel.Name = "nroReferenciaLabel";
            nroReferenciaLabel.Size = new System.Drawing.Size(94, 20);
            nroReferenciaLabel.TabIndex = 13;
            nroReferenciaLabel.Values.Text = "Nro Referencia:";
            // 
            // tipoLabel
            // 
            tipoLabel.Location = new System.Drawing.Point(2, 12);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new System.Drawing.Size(37, 20);
            tipoLabel.TabIndex = 12;
            tipoLabel.Values.Text = "Tipo:";
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(377, 25);
            this.barraBotones.TabIndex = 11;
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
            // discrepanciaBindingSource
            // 
            this.discrepanciaBindingSource.DataSource = typeof(FinalXML.Discrepancia);
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.discrepanciaBindingSource, "Tipo", true));
            this.tipoComboBox.DataSource = this.tipoDiscrepanciaBindingSource;
            this.tipoComboBox.DisplayMember = "Descripcion";
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Location = new System.Drawing.Point(102, 9);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(265, 21);
            this.tipoComboBox.TabIndex = 14;
            this.tipoComboBox.ValueMember = "Codigo";
            // 
            // tipoDiscrepanciaBindingSource
            // 
            this.tipoDiscrepanciaBindingSource.DataSource = typeof(FinalXML.TipoDiscrepancia);
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(100, 62);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(265, 20);
            this.descripcionTextBox.TabIndex = 17;
            // 
            // nroReferenciaTextBox
            // 
            this.nroReferenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.discrepanciaBindingSource, "NroReferencia", true));
            this.nroReferenciaTextBox.Location = new System.Drawing.Point(102, 36);
            this.nroReferenciaTextBox.Name = "nroReferenciaTextBox";
            this.nroReferenciaTextBox.Size = new System.Drawing.Size(100, 20);
            this.nroReferenciaTextBox.TabIndex = 16;
            this.nroReferenciaTextBox.TextChanged += new System.EventHandler(this.nroReferenciaTextBox_TextChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(descripcionLabel);
            this.kryptonPanel1.Controls.Add(nroReferenciaLabel);
            this.kryptonPanel1.Controls.Add(tipoLabel);
            this.kryptonPanel1.Controls.Add(this.tipoComboBox);
            this.kryptonPanel1.Controls.Add(this.descripcionTextBox);
            this.kryptonPanel1.Controls.Add(this.nroReferenciaTextBox);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(377, 107);
            this.kryptonPanel1.TabIndex = 18;
            // 
            // FrmDiscrepancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 132);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.barraBotones);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDiscrepancia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDiscrepancia";
            this.Load += new System.EventHandler(this.FrmDiscrepancia_Load);
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrepanciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDiscrepanciaBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource discrepanciaBindingSource;
        private System.Windows.Forms.ComboBox tipoComboBox;
        private System.Windows.Forms.BindingSource tipoDiscrepanciaBindingSource;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox nroReferenciaTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}