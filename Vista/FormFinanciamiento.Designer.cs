namespace Vista
{
    partial class FormFinanciamiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Método requerido para el diseñador de Windows Forms.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFinanciamientos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            lblGestionDeFinanciamientos = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFinanciamientos).BeginInit();
            SuspendLayout();
            // 
            // dgvFinanciamientos
            // 
            dgvFinanciamientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinanciamientos.Location = new Point(12, 67);
            dgvFinanciamientos.Name = "dgvFinanciamientos";
            dgvFinanciamientos.RowHeadersWidth = 62;
            dgvFinanciamientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinanciamientos.Size = new Size(757, 273);
            dgvFinanciamientos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(52, 152, 219);
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(117, 358);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 53);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(52, 152, 219);
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(319, 358);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(142, 53);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(52, 152, 219);
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(512, 358);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(142, 53);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblGestionDeFinanciamientos
            // 
            lblGestionDeFinanciamientos.AutoSize = true;
            lblGestionDeFinanciamientos.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionDeFinanciamientos.Location = new Point(12, 16);
            lblGestionDeFinanciamientos.Name = "lblGestionDeFinanciamientos";
            lblGestionDeFinanciamientos.Size = new Size(484, 48);
            lblGestionDeFinanciamientos.TabIndex = 4;
            lblGestionDeFinanciamientos.Text = "Gestion de Financiamientos";
            // 
            // FormFinanciamiento
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(781, 423);
            Controls.Add(lblGestionDeFinanciamientos);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvFinanciamientos);
            Name = "FormFinanciamiento";
            Text = "Gestión de Financiamientos";
            ((System.ComponentModel.ISupportInitialize)dgvFinanciamientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFinanciamientos;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Label lblGestionDeFinanciamientos;
    }
}
