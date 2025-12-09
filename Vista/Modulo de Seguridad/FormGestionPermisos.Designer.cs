namespace Vista.Modulo_de_Seguridad
{
    partial class FormGestionPermisos
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGrupo;
        private ComboBox cmbGrupos;
        private CheckedListBox clbPermisos;
        private Button btnGuardar;
        private Button btnCargarPermisos;
        private Button btnQuitarTodos;
        private Label lblPermisos;

        /// <summary>
        /// Limpiar los recursos utilizados
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicializar componentes del formulario
        /// </summary>
        private void InitializeComponent()
        {
            lblGrupo = new Label();
            cmbGrupos = new ComboBox();
            clbPermisos = new CheckedListBox();
            btnGuardar = new Button();
            btnCargarPermisos = new Button();
            btnQuitarTodos = new Button();
            lblPermisos = new Label();
            lblGestionDePermisos = new Label();
            SuspendLayout();
            // 
            // lblGrupo
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblGrupo.Location = new Point(30, 79);
            lblGrupo.Margin = new Padding(5, 0, 5, 0);
            lblGrupo.Name = "lblGrupo";
            lblGrupo.Size = new Size(72, 28);
            lblGrupo.TabIndex = 0;
            lblGrupo.Text = "Grupo:";
            // 
            // cmbGrupos
            // 
            cmbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGrupos.FormattingEnabled = true;
            cmbGrupos.Location = new Point(112, 76);
            cmbGrupos.Margin = new Padding(5, 6, 5, 6);
            cmbGrupos.Name = "cmbGrupos";
            cmbGrupos.Size = new Size(349, 36);
            cmbGrupos.TabIndex = 1;
            // 
            // clbPermisos
            // 
            clbPermisos.FormattingEnabled = true;
            clbPermisos.Location = new Point(33, 154);
            clbPermisos.Margin = new Padding(5, 6, 5, 6);
            clbPermisos.Name = "clbPermisos";
            clbPermisos.Size = new Size(664, 396);
            clbPermisos.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(52, 152, 219);
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(150, 562);
            btnGuardar.Margin = new Padding(5, 6, 5, 6);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 58);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCargarPermisos
            // 
            btnCargarPermisos.BackColor = Color.FromArgb(39, 174, 96);
            btnCargarPermisos.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnCargarPermisos.ForeColor = Color.White;
            btnCargarPermisos.Location = new Point(497, 71);
            btnCargarPermisos.Margin = new Padding(5, 6, 5, 6);
            btnCargarPermisos.Name = "btnCargarPermisos";
            btnCargarPermisos.Size = new Size(200, 41);
            btnCargarPermisos.TabIndex = 2;
            btnCargarPermisos.Text = "Cargar Permisos";
            btnCargarPermisos.UseVisualStyleBackColor = false;
            btnCargarPermisos.Click += btnCargarPermisos_Click;
            // 
            // btnQuitarTodos
            // 
            btnQuitarTodos.BackColor = Color.FromArgb(52, 152, 219);
            btnQuitarTodos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnQuitarTodos.ForeColor = Color.White;
            btnQuitarTodos.Location = new Point(371, 562);
            btnQuitarTodos.Margin = new Padding(5, 6, 5, 6);
            btnQuitarTodos.Name = "btnQuitarTodos";
            btnQuitarTodos.Size = new Size(200, 58);
            btnQuitarTodos.TabIndex = 6;
            btnQuitarTodos.Text = "Quitar Todos";
            btnQuitarTodos.UseVisualStyleBackColor = false;
            btnQuitarTodos.Click += btnQuitarTodos_Click;
            // 
            // lblPermisos
            // 
            lblPermisos.AutoSize = true;
            lblPermisos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPermisos.Location = new Point(30, 120);
            lblPermisos.Margin = new Padding(5, 0, 5, 0);
            lblPermisos.Name = "lblPermisos";
            lblPermisos.Size = new Size(93, 28);
            lblPermisos.TabIndex = 3;
            lblPermisos.Text = "Permisos:";
            // 
            // lblGestionDePermisos
            // 
            lblGestionDePermisos.AutoSize = true;
            lblGestionDePermisos.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionDePermisos.Location = new Point(33, 12);
            lblGestionDePermisos.Name = "lblGestionDePermisos";
            lblGestionDePermisos.Size = new Size(361, 48);
            lblGestionDePermisos.TabIndex = 7;
            lblGestionDePermisos.Text = "Gestion de Permisos";
            // 
            // FormGestionPermisos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(750, 635);
            Controls.Add(lblGestionDePermisos);
            Controls.Add(lblGrupo);
            Controls.Add(cmbGrupos);
            Controls.Add(btnCargarPermisos);
            Controls.Add(lblPermisos);
            Controls.Add(clbPermisos);
            Controls.Add(btnGuardar);
            Controls.Add(btnQuitarTodos);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormGestionPermisos";
            Text = "Gestión de Permisos";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblGestionDePermisos;
    }
}
