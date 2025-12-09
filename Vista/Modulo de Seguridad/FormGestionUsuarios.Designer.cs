namespace Vista.Modulo_de_Seguridad
{
    partial class FormGestionUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvUsuarios;
        private TextBox txtNombre;
        private TextBox txtContrasena;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private ComboBox cmbGrupos;

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
            dgvUsuarios = new DataGridView();
            txtNombre = new TextBox();
            txtContrasena = new TextBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            cmbGrupos = new ComboBox();
            lblGrupo = new Label();
            lblGestionDeUsuarios = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeight = 34;
            dgvUsuarios.Location = new Point(33, 88);
            dgvUsuarios.Margin = new Padding(5, 6, 5, 6);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 62;
            dgvUsuarios.Size = new Size(833, 385);
            dgvUsuarios.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(71, 509);
            txtNombre.Margin = new Padding(5, 6, 5, 6);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre de usuario";
            txtNombre.Size = new Size(331, 31);
            txtNombre.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(71, 561);
            txtContrasena.Margin = new Padding(5, 6, 5, 6);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Contraseña";
            txtContrasena.Size = new Size(331, 31);
            txtContrasena.TabIndex = 3;
            txtContrasena.TextChanged += txtContrasena_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(52, 152, 219);
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(66, 615);
            btnGuardar.Margin = new Padding(5, 6, 5, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(167, 58);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(52, 152, 219);
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(250, 615);
            btnEditar.Margin = new Padding(5, 6, 5, 6);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(167, 58);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(52, 152, 219);
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(470, 615);
            btnEliminar.Margin = new Padding(5, 6, 5, 6);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(167, 58);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(52, 152, 219);
            btnLimpiar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(653, 615);
            btnLimpiar.Margin = new Padding(5, 6, 5, 6);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(167, 58);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cmbGrupos
            // 
            cmbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupos.Location = new Point(470, 559);
            cmbGrupos.Margin = new Padding(5, 6, 5, 6);
            cmbGrupos.Name = "cmbGrupos";
            cmbGrupos.Size = new Size(350, 33);
            cmbGrupos.TabIndex = 0;
            // 
            // lblGrupo
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblGrupo.Location = new Point(470, 512);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(169, 28);
            lblGrupo.TabIndex = 8;
            lblGrupo.Text = "Seleccione Grupo:";
            // 
            // lblGestionDeUsuarios
            // 
            lblGestionDeUsuarios.AutoSize = true;
            lblGestionDeUsuarios.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionDeUsuarios.Location = new Point(33, 23);
            lblGestionDeUsuarios.Name = "lblGestionDeUsuarios";
            lblGestionDeUsuarios.Size = new Size(355, 48);
            lblGestionDeUsuarios.TabIndex = 9;
            lblGestionDeUsuarios.Text = "Gestion de Usuarios";
            // 
            // FormGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(898, 686);
            Controls.Add(lblGestionDeUsuarios);
            Controls.Add(lblGrupo);
            Controls.Add(cmbGrupos);
            Controls.Add(dgvUsuarios);
            Controls.Add(txtNombre);
            Controls.Add(txtContrasena);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormGestionUsuarios";
            Text = "Gestión de Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblGrupo;
        private Label lblGestionDeUsuarios;
    }
}
