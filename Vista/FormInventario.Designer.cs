namespace Vista
{
    partial class FormInventario
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private ComboBox cmbDisponibilidad;
        private Label lblDisponibilidad;
        private DataGridView dgvInventario;
        private Button btnActualizar;
        private Button btnVender;
        private Button btnGenerarPDF;


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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblDisponibilidad = new Label();
            cmbDisponibilidad = new ComboBox();
            dgvInventario = new DataGridView();
            btnActualizar = new Button();
            btnVender = new Button();
            btnGenerarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(20, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(414, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inventario de Vehículos";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblBuscar.Location = new Point(20, 60);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(120, 28);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar Auto:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(144, 60);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(200, 31);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblDisponibilidad
            // 
            lblDisponibilidad.AutoSize = true;
            lblDisponibilidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDisponibilidad.Location = new Point(379, 60);
            lblDisponibilidad.Name = "lblDisponibilidad";
            lblDisponibilidad.Size = new Size(198, 28);
            lblDisponibilidad.TabIndex = 3;
            lblDisponibilidad.Text = "Filtrar disponibilidad:";
            // 
            // cmbDisponibilidad
            // 
            cmbDisponibilidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisponibilidad.Location = new Point(583, 58);
            cmbDisponibilidad.Name = "cmbDisponibilidad";
            cmbDisponibilidad.Size = new Size(237, 33);
            cmbDisponibilidad.TabIndex = 4;
            cmbDisponibilidad.SelectedIndexChanged += cmbDisponibilidad_SelectedIndexChanged;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeight = 34;
            dgvInventario.Location = new Point(20, 100);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowHeadersWidth = 62;
            dgvInventario.Size = new Size(800, 416);
            dgvInventario.TabIndex = 4;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(99, 522);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(161, 76);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "🔄 Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnVender
            // 
            btnVender.BackColor = Color.FromArgb(52, 152, 219);
            btnVender.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnVender.ForeColor = Color.White;
            btnVender.Location = new Point(353, 522);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(155, 76);
            btnVender.TabIndex = 6;
            btnVender.Text = "🚗 Marcar como Vendido";
            btnVender.UseVisualStyleBackColor = false;
            btnVender.Click += btnVender_Click;
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.BackColor = Color.FromArgb(211, 84, 0);
            btnGenerarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarPDF.ForeColor = Color.White;
            btnGenerarPDF.Location = new Point(596, 522);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(161, 76);
            btnGenerarPDF.TabIndex = 7;
            btnGenerarPDF.Text = "📄 Generar PDF";
            btnGenerarPDF.UseVisualStyleBackColor = false;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // FormInventario
            // 
            BackColor = Color.White;
            ClientSize = new Size(840, 610);
            Controls.Add(lblTitulo);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblDisponibilidad);
            Controls.Add(cmbDisponibilidad);
            Controls.Add(dgvInventario);
            Controls.Add(btnActualizar);
            Controls.Add(btnVender);
            Controls.Add(btnGenerarPDF);
            Name = "FormInventario";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
