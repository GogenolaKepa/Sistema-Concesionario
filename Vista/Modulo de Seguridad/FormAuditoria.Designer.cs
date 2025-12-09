namespace Vista.Modulo_de_Seguridad
{
    partial class FormAuditoria
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewAuditoria;
        private Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewAuditoria = new DataGridView();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuditoria).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAuditoria
            // 
            dataGridViewAuditoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAuditoria.Location = new Point(12, 70);
            dataGridViewAuditoria.Name = "dataGridViewAuditoria";
            dataGridViewAuditoria.RowHeadersWidth = 62;
            dataGridViewAuditoria.Size = new Size(693, 426);
            dataGridViewAuditoria.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(33, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Auditoría";
            // 
            // FormAuditoria
            // 
            ClientSize = new Size(717, 508);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridViewAuditoria);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormAuditoria";
            Text = "Historial de Auditoría";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAuditoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
