namespace Vista.Modulo_de_Seguridad
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnBackup;
        private Button btnRestaurar;

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
            lblTitulo = new Label();
            btnBackup = new Button();
            btnRestaurar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(96, 56);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(313, 45);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Backups";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.FromArgb(52, 152, 219);
            btnBackup.FlatAppearance.BorderSize = 0;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(101, 150);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(300, 50);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "⬇️ Realizar Backup";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.BackColor = Color.FromArgb(52, 152, 219);
            btnRestaurar.FlatAppearance.BorderSize = 0;
            btnRestaurar.FlatStyle = FlatStyle.Flat;
            btnRestaurar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRestaurar.ForeColor = Color.White;
            btnRestaurar.Location = new Point(101, 230);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(300, 50);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Text = "🔄 Restaurar Backup";
            btnRestaurar.UseVisualStyleBackColor = false;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // FormBackup
            // 
            BackColor = Color.White;
            ClientSize = new Size(500, 350);
            Controls.Add(lblTitulo);
            Controls.Add(btnBackup);
            Controls.Add(btnRestaurar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormBackup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Backups";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
