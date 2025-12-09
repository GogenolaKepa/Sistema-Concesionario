namespace Vista.Modulo_de_Seguridad
{
    partial class FormGestionGrupos
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombreGrupo;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnEditar;
        private DataGridView dgvGrupos;

        /// <summary>
        /// Limpiar recursos en uso.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados deben ser eliminados; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método de inicialización de componentes.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombreGrupo = new TextBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            dgvGrupos = new DataGridView();
            lblGestionDeGrupos = new Label();
            lblNombreGrupo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            SuspendLayout();
            // 
            // txtNombreGrupo
            // 
            txtNombreGrupo.Location = new Point(12, 446);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(277, 31);
            txtNombreGrupo.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(52, 152, 219);
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(295, 435);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 52);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(52, 152, 219);
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(537, 434);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(115, 52);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(52, 152, 219);
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(416, 435);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(115, 52);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // dgvGrupos
            // 
            dgvGrupos.AllowUserToAddRows = false;
            dgvGrupos.AllowUserToDeleteRows = false;
            dgvGrupos.ColumnHeadersHeight = 34;
            dgvGrupos.Location = new Point(12, 92);
            dgvGrupos.Name = "dgvGrupos";
            dgvGrupos.ReadOnly = true;
            dgvGrupos.RowHeadersWidth = 62;
            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupos.Size = new Size(640, 300);
            dgvGrupos.TabIndex = 4;
            // 
            // lblGestionDeGrupos
            // 
            lblGestionDeGrupos.AutoSize = true;
            lblGestionDeGrupos.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionDeGrupos.Location = new Point(12, 18);
            lblGestionDeGrupos.Name = "lblGestionDeGrupos";
            lblGestionDeGrupos.Size = new Size(332, 48);
            lblGestionDeGrupos.TabIndex = 5;
            lblGestionDeGrupos.Text = "Gestion de Grupos";
            // 
            // lblNombreGrupo
            // 
            lblNombreGrupo.AutoSize = true;
            lblNombreGrupo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreGrupo.Location = new Point(12, 405);
            lblNombreGrupo.Name = "lblNombreGrupo";
            lblNombreGrupo.Size = new Size(150, 28);
            lblNombreGrupo.TabIndex = 6;
            lblNombreGrupo.Text = "Nombre Grupo:";
            // 
            // FormGestionGrupos
            // 
            BackColor = Color.White;
            ClientSize = new Size(664, 518);
            Controls.Add(lblNombreGrupo);
            Controls.Add(lblGestionDeGrupos);
            Controls.Add(txtNombreGrupo);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(dgvGrupos);
            Name = "FormGestionGrupos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Grupos";
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblGestionDeGrupos;
        private Label lblNombreGrupo;
    }
}
