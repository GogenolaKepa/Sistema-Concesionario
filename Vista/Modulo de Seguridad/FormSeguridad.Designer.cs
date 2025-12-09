namespace Vista.Modulo_de_Seguridad
{
    partial class FormSeguridad
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnGestionUsuarios;
        private Button btnGestionPermisos;
        private Button btnGestionGrupos;
        private Button btnBackup;
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
            btnGestionUsuarios = new Button();
            btnGestionPermisos = new Button();
            btnGestionGrupos = new Button();
            btnBackup = new Button();
            btnAuditoria = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(71, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(342, 45);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de Seguridad";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.BackColor = Color.FromArgb(52, 152, 219);
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGestionUsuarios.ForeColor = Color.White;
            btnGestionUsuarios.Location = new Point(90, 100);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(300, 50);
            btnGestionUsuarios.TabIndex = 2;
            btnGestionUsuarios.Text = "👤 Gestión de Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = false;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnGestionPermisos
            // 
            btnGestionPermisos.BackColor = Color.FromArgb(52, 152, 219);
            btnGestionPermisos.FlatAppearance.BorderSize = 0;
            btnGestionPermisos.FlatStyle = FlatStyle.Flat;
            btnGestionPermisos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGestionPermisos.ForeColor = Color.White;
            btnGestionPermisos.Location = new Point(90, 170);
            btnGestionPermisos.Name = "btnGestionPermisos";
            btnGestionPermisos.Size = new Size(300, 50);
            btnGestionPermisos.TabIndex = 3;
            btnGestionPermisos.Text = "🔑 Gestión de Permisos";
            btnGestionPermisos.UseVisualStyleBackColor = false;
            btnGestionPermisos.Click += btnGestionPermisos_Click;
            // 
            // btnGestionGrupos
            // 
            btnGestionGrupos.BackColor = Color.FromArgb(52, 152, 219);
            btnGestionGrupos.FlatAppearance.BorderSize = 0;
            btnGestionGrupos.FlatStyle = FlatStyle.Flat;
            btnGestionGrupos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGestionGrupos.ForeColor = Color.White;
            btnGestionGrupos.Location = new Point(90, 240);
            btnGestionGrupos.Name = "btnGestionGrupos";
            btnGestionGrupos.Size = new Size(300, 50);
            btnGestionGrupos.TabIndex = 4;
            btnGestionGrupos.Text = "👥 Gestión de Grupos";
            btnGestionGrupos.UseVisualStyleBackColor = false;
            btnGestionGrupos.Click += btnGestionGrupos_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.FromArgb(52, 152, 219);
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(90, 310);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(300, 50);
            btnBackup.TabIndex = 5;
            btnBackup.Text = "⬇️ Gestión de Backups";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnAuditoria
            // 
            btnAuditoria.BackColor = Color.FromArgb(52, 152, 219);
            btnAuditoria.FlatStyle = FlatStyle.Flat;
            btnAuditoria.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAuditoria.ForeColor = Color.White;
            btnAuditoria.Location = new Point(90, 380);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Size = new Size(300, 50);
            btnAuditoria.TabIndex = 6;
            btnAuditoria.Text = "📜 Auditoría";
            btnAuditoria.UseVisualStyleBackColor = false;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // FormSeguridad
            // 
            BackColor = Color.White;
            ClientSize = new Size(500, 480);
            Controls.Add(btnAuditoria);
            Controls.Add(btnBackup);
            Controls.Add(lblTitulo);
            Controls.Add(btnGestionUsuarios);
            Controls.Add(btnGestionPermisos);
            Controls.Add(btnGestionGrupos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormSeguridad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Seguridad";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
