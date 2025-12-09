namespace Vista
{
    partial class FormCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private Button btnActualizarLista;
        private Button btnRegistrarCompra;
        private Button btnGenerarPDF;
        private void InitializeComponent()
        {
            btnActualizarLista = new Button();
            lblTitulo = new Label();
            dgvVehiculos = new DataGridView();
            dgvOrdenes = new DataGridView();
            cmbProveedores = new ComboBox();
            txtBuscar = new TextBox();
            nudCantidad = new NumericUpDown();
            btnRegistrarCompra = new Button();
            lblProveedores = new Label();
            lblBuscar = new Label();
            lblCantidad = new Label();
            lstHistorial = new ListBox();
            lblHistorial = new Label();
            btnGenerarPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // btnActualizarLista
            // 
            btnActualizarLista.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizarLista.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnActualizarLista.ForeColor = Color.White;
            btnActualizarLista.Location = new Point(404, 416);
            btnActualizarLista.Name = "btnActualizarLista";
            btnActualizarLista.Size = new Size(180, 65);
            btnActualizarLista.TabIndex = 0;
            btnActualizarLista.Text = "🔄Actualizar Lista";
            btnActualizarLista.UseVisualStyleBackColor = false;
            btnActualizarLista.Click += btnActualizarLista_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(30, 6);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(358, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Compras";
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(30, 100);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersWidth = 62;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new Size(740, 180);
            dgvVehiculos.TabIndex = 5;
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new Point(30, 290);
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersWidth = 62;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new Size(740, 120);
            dgvOrdenes.TabIndex = 6;
            // 
            // cmbProveedores
            // 
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedores.Location = new Point(132, 57);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(200, 33);
            cmbProveedores.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(471, 57);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(213, 31);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(128, 424);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(80, 31);
            nudCantidad.TabIndex = 7;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnRegistrarCompra
            // 
            btnRegistrarCompra.BackColor = Color.FromArgb(39, 174, 96);
            btnRegistrarCompra.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarCompra.ForeColor = Color.White;
            btnRegistrarCompra.Location = new Point(218, 416);
            btnRegistrarCompra.Name = "btnRegistrarCompra";
            btnRegistrarCompra.Size = new Size(180, 65);
            btnRegistrarCompra.TabIndex = 9;
            btnRegistrarCompra.Text = "\U0001f6d2Registrar Compra";
            btnRegistrarCompra.UseVisualStyleBackColor = false;
            btnRegistrarCompra.Click += btnRegistrarCompra_Click;
            // 
            // lblProveedores
            // 
            lblProveedores.AutoSize = true;
            lblProveedores.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblProveedores.Location = new Point(19, 60);
            lblProveedores.Name = "lblProveedores";
            lblProveedores.Size = new Size(107, 28);
            lblProveedores.TabIndex = 2;
            lblProveedores.Text = "Proveedor:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblBuscar.Location = new Point(345, 60);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(120, 28);
            lblBuscar.TabIndex = 4;
            lblBuscar.Text = "Buscar Auto:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.Location = new Point(31, 424);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(95, 28);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 25;
            lstHistorial.Location = new Point(30, 490);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(740, 129);
            lstHistorial.TabIndex = 10;
            // 
            // lblHistorial
            // 
            lblHistorial.AutoSize = true;
            lblHistorial.Location = new Point(30, 463);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(183, 25);
            lblHistorial.TabIndex = 11;
            lblHistorial.Text = "Historial de Compras:";
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.BackColor = Color.FromArgb(211, 84, 0);
            btnGenerarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarPDF.ForeColor = Color.White;
            btnGenerarPDF.Location = new Point(590, 416);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(180, 65);
            btnGenerarPDF.TabIndex = 10;
            btnGenerarPDF.Text = "📄 Generar PDF";
            btnGenerarPDF.UseVisualStyleBackColor = false;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // FormCompras
            // 
            BackColor = Color.White;
            ClientSize = new Size(800, 650);
            Controls.Add(btnGenerarPDF);
            Controls.Add(btnActualizarLista);
            Controls.Add(lblTitulo);
            Controls.Add(cmbProveedores);
            Controls.Add(lblProveedores);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(dgvVehiculos);
            Controls.Add(dgvOrdenes);
            Controls.Add(nudCantidad);
            Controls.Add(lblCantidad);
            Controls.Add(btnRegistrarCompra);
            Controls.Add(lstHistorial);
            Controls.Add(lblHistorial);
            Name = "FormCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Compras";
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo, lblProveedores, lblBuscar, lblCantidad, lblHistorial;
        private ComboBox cmbProveedores;
        private TextBox txtBuscar;
        private DataGridView dgvVehiculos, dgvOrdenes;
        private NumericUpDown nudCantidad;
        private ListBox lstHistorial;
    }
}
