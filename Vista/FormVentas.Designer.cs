namespace Vista
{
    partial class FormVentas
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpCliente;
        private Button btnSeleccionarCliente;
        private Label lblClienteSeleccionado;
        private TextBox txtClienteSeleccionado;

        private GroupBox grpFinanciamiento;
        private Label lblFinanciamiento;
        private ComboBox cmbFinanciamiento;
        private Button btnGestionarFinanciamiento;

        private GroupBox grpVehiculo;

        private Button btnRegistrarVenta;
        private Button btnEliminarVenta;
        private DataGridView dgvAutosVendidos;
        private ComboBox cmbVehiculos;



        /// <summary>
        /// Liberar recursos.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Inicializar componentes del formulario.
        /// </summary>
        private void InitializeComponent()
        {
            grpCliente = new GroupBox();
            btnSeleccionarCliente = new Button();
            lblClienteSeleccionado = new Label();
            txtClienteSeleccionado = new TextBox();
            lblVehiculoSeleccionado = new Label();
            grpFinanciamiento = new GroupBox();
            lblFinanciamiento = new Label();
            cmbFinanciamiento = new ComboBox();
            btnGestionarFinanciamiento = new Button();
            grpVehiculo = new GroupBox();
            cmbVehiculos = new ComboBox();
            btnRegistrarVenta = new Button();
            btnEliminarVenta = new Button();
            dgvAutosVendidos = new DataGridView();
            lblGestionDeVentas = new Label();
            grpCliente.SuspendLayout();
            grpFinanciamiento.SuspendLayout();
            grpVehiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutosVendidos).BeginInit();
            SuspendLayout();
            // 
            // grpCliente
            // 
            grpCliente.Controls.Add(btnSeleccionarCliente);
            grpCliente.Controls.Add(lblClienteSeleccionado);
            grpCliente.Controls.Add(txtClienteSeleccionado);
            grpCliente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpCliente.Location = new Point(12, 138);
            grpCliente.Name = "grpCliente";
            grpCliente.Size = new Size(550, 80);
            grpCliente.TabIndex = 0;
            grpCliente.TabStop = false;
            grpCliente.Text = "Cliente";
            // 
            // btnSeleccionarCliente
            // 
            btnSeleccionarCliente.Location = new Point(390, 30);
            btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            btnSeleccionarCliente.Size = new Size(150, 34);
            btnSeleccionarCliente.TabIndex = 0;
            btnSeleccionarCliente.Text = "Seleccionar Cliente";
            btnSeleccionarCliente.Click += btnSeleccionarCliente_Click;
            // 
            // lblClienteSeleccionado
            // 
            lblClienteSeleccionado.Location = new Point(20, 33);
            lblClienteSeleccionado.Name = "lblClienteSeleccionado";
            lblClienteSeleccionado.Size = new Size(87, 27);
            lblClienteSeleccionado.TabIndex = 1;
            lblClienteSeleccionado.Text = "Cliente:";
            // 
            // txtClienteSeleccionado
            // 
            txtClienteSeleccionado.Location = new Point(113, 30);
            txtClienteSeleccionado.Name = "txtClienteSeleccionado";
            txtClienteSeleccionado.Size = new Size(268, 34);
            txtClienteSeleccionado.TabIndex = 2;
            // 
            // lblVehiculoSeleccionado
            // 
            lblVehiculoSeleccionado.Location = new Point(10, 32);
            lblVehiculoSeleccionado.Name = "lblVehiculoSeleccionado";
            lblVehiculoSeleccionado.Size = new Size(214, 33);
            lblVehiculoSeleccionado.TabIndex = 7;
            lblVehiculoSeleccionado.Text = "Vehículo seleccionado:";
            // 
            // grpFinanciamiento
            // 
            grpFinanciamiento.Controls.Add(lblFinanciamiento);
            grpFinanciamiento.Controls.Add(cmbFinanciamiento);
            grpFinanciamiento.Controls.Add(btnGestionarFinanciamiento);
            grpFinanciamiento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpFinanciamiento.Location = new Point(12, 242);
            grpFinanciamiento.Name = "grpFinanciamiento";
            grpFinanciamiento.Size = new Size(550, 80);
            grpFinanciamiento.TabIndex = 1;
            grpFinanciamiento.TabStop = false;
            grpFinanciamiento.Text = "Opciones de Financiamiento";
            // 
            // lblFinanciamiento
            // 
            lblFinanciamiento.Location = new Point(20, 32);
            lblFinanciamiento.Name = "lblFinanciamiento";
            lblFinanciamiento.Size = new Size(150, 26);
            lblFinanciamiento.TabIndex = 0;
            lblFinanciamiento.Text = "Financiamiento:";
            // 
            // cmbFinanciamiento
            // 
            cmbFinanciamiento.Location = new Point(176, 32);
            cmbFinanciamiento.Name = "cmbFinanciamiento";
            cmbFinanciamiento.Size = new Size(241, 36);
            cmbFinanciamiento.TabIndex = 1;
            // 
            // btnGestionarFinanciamiento
            // 
            btnGestionarFinanciamiento.Location = new Point(423, 30);
            btnGestionarFinanciamiento.Name = "btnGestionarFinanciamiento";
            btnGestionarFinanciamiento.Size = new Size(117, 38);
            btnGestionarFinanciamiento.TabIndex = 2;
            btnGestionarFinanciamiento.Text = "Gestionar";
            btnGestionarFinanciamiento.Click += btnGestionarFinanciamiento_Click;
            // 
            // grpVehiculo
            // 
            grpVehiculo.Controls.Add(cmbVehiculos);
            grpVehiculo.Controls.Add(lblVehiculoSeleccionado);
            grpVehiculo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpVehiculo.Location = new Point(12, 337);
            grpVehiculo.Name = "grpVehiculo";
            grpVehiculo.Size = new Size(550, 80);
            grpVehiculo.TabIndex = 2;
            grpVehiculo.TabStop = false;
            grpVehiculo.Text = "Selección de Vehículo";
            // 
            // cmbVehiculos
            // 
            cmbVehiculos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehiculos.FormattingEnabled = true;
            cmbVehiculos.Location = new Point(220, 32);
            cmbVehiculos.Name = "cmbVehiculos";
            cmbVehiculos.Size = new Size(320, 36);
            cmbVehiculos.TabIndex = 1;
            cmbVehiculos.SelectedIndexChanged += cmbVehiculos_SelectedIndexChanged;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.FromArgb(52, 152, 219);
            btnRegistrarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarVenta.ForeColor = Color.White;
            btnRegistrarVenta.Location = new Point(118, 479);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(143, 57);
            btnRegistrarVenta.TabIndex = 3;
            btnRegistrarVenta.Text = "Registrar";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // btnEliminarVenta
            // 
            btnEliminarVenta.BackColor = Color.FromArgb(52, 152, 219);
            btnEliminarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminarVenta.ForeColor = Color.White;
            btnEliminarVenta.Location = new Point(304, 479);
            btnEliminarVenta.Name = "btnEliminarVenta";
            btnEliminarVenta.Size = new Size(132, 57);
            btnEliminarVenta.TabIndex = 5;
            btnEliminarVenta.Text = "Eliminar";
            btnEliminarVenta.UseVisualStyleBackColor = false;
            // 
            // dgvAutosVendidos
            // 
            dgvAutosVendidos.AllowUserToAddRows = false;
            dgvAutosVendidos.AllowUserToDeleteRows = false;
            dgvAutosVendidos.AllowUserToResizeRows = false;
            dgvAutosVendidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutosVendidos.Location = new Point(576, 12);
            dgvAutosVendidos.MultiSelect = false;
            dgvAutosVendidos.Name = "dgvAutosVendidos";
            dgvAutosVendidos.ReadOnly = true;
            dgvAutosVendidos.RowHeadersWidth = 62;
            dgvAutosVendidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutosVendidos.Size = new Size(449, 605);
            dgvAutosVendidos.TabIndex = 10;
            // 
            // lblGestionDeVentas
            // 
            lblGestionDeVentas.AutoSize = true;
            lblGestionDeVentas.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGestionDeVentas.Location = new Point(107, 44);
            lblGestionDeVentas.Name = "lblGestionDeVentas";
            lblGestionDeVentas.Size = new Size(322, 48);
            lblGestionDeVentas.TabIndex = 11;
            lblGestionDeVentas.Text = "Gestion de Ventas";
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1037, 629);
            Controls.Add(lblGestionDeVentas);
            Controls.Add(dgvAutosVendidos);
            Controls.Add(grpCliente);
            Controls.Add(grpFinanciamiento);
            Controls.Add(grpVehiculo);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(btnEliminarVenta);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Ventas";
            grpCliente.ResumeLayout(false);
            grpCliente.PerformLayout();
            grpFinanciamiento.ResumeLayout(false);
            grpVehiculo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAutosVendidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblVehiculoSeleccionado;
        private Label lblGestionDeVentas;
    }
}
