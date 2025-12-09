namespace Vista
{
    partial class FormCliente
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvClientes;
        private TextBox txtNombreCliente, txtNumContacto, txtDNI;
        private Button btnAgregarCliente;
        private Label lblNombreCliente, lblNumContacto, lblDNI, lblTitulo;
        private GroupBox grpNuevoCliente;

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
            dgvClientes = new DataGridView();
            grpNuevoCliente = new GroupBox();
            lblNombreCliente = new Label();
            txtNombreCliente = new TextBox();
            lblDNI = new Label();
            txtDNI = new TextBox();
            lblNumContacto = new Label();
            txtNumContacto = new TextBox();
            btnAgregarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            grpNuevoCliente.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(311, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Clientes";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(20, 60);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 62;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(650, 200);
            dgvClientes.TabIndex = 1;
            dgvClientes.CellDoubleClick += dgvClientes_CellDoubleClick;
            // 
            // grpNuevoCliente
            // 
            grpNuevoCliente.BackColor = Color.FromArgb(236, 240, 241);
            grpNuevoCliente.Controls.Add(lblNombreCliente);
            grpNuevoCliente.Controls.Add(txtNombreCliente);
            grpNuevoCliente.Controls.Add(lblDNI);
            grpNuevoCliente.Controls.Add(txtDNI);
            grpNuevoCliente.Controls.Add(lblNumContacto);
            grpNuevoCliente.Controls.Add(txtNumContacto);
            grpNuevoCliente.Controls.Add(btnAgregarCliente);
            grpNuevoCliente.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            grpNuevoCliente.Location = new Point(20, 280);
            grpNuevoCliente.Name = "grpNuevoCliente";
            grpNuevoCliente.Size = new Size(650, 200);
            grpNuevoCliente.TabIndex = 2;
            grpNuevoCliente.TabStop = false;
            grpNuevoCliente.Text = "Agregar Nuevo Cliente";
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreCliente.Location = new Point(20, 40);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(100, 23);
            lblNombreCliente.TabIndex = 0;
            lblNombreCliente.Text = "Nombre:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCliente.Location = new Point(140, 40);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(220, 34);
            txtNombreCliente.TabIndex = 1;
            // 
            // lblDNI
            // 
            lblDNI.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblDNI.Location = new Point(20, 80);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(100, 23);
            lblDNI.TabIndex = 2;
            lblDNI.Text = "DNI:";
            // 
            // txtDNI
            // 
            txtDNI.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDNI.Location = new Point(140, 80);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(220, 34);
            txtDNI.TabIndex = 3;
            // 
            // lblNumContacto
            // 
            lblNumContacto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumContacto.Location = new Point(20, 120);
            lblNumContacto.Name = "lblNumContacto";
            lblNumContacto.Size = new Size(100, 23);
            lblNumContacto.TabIndex = 4;
            lblNumContacto.Text = "Teléfono:";
            // 
            // txtNumContacto
            // 
            txtNumContacto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumContacto.Location = new Point(140, 120);
            txtNumContacto.Name = "txtNumContacto";
            txtNumContacto.Size = new Size(220, 34);
            txtNumContacto.TabIndex = 5;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.FromArgb(41, 128, 185);
            btnAgregarCliente.FlatAppearance.BorderSize = 0;
            btnAgregarCliente.FlatStyle = FlatStyle.Flat;
            btnAgregarCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarCliente.ForeColor = Color.White;
            btnAgregarCliente.Location = new Point(400, 80);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(200, 40);
            btnAgregarCliente.TabIndex = 6;
            btnAgregarCliente.Text = "Agregar Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // FormCliente
            // 
            BackColor = Color.White;
            ClientSize = new Size(700, 550);
            Controls.Add(lblTitulo);
            Controls.Add(dgvClientes);
            Controls.Add(grpNuevoCliente);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            grpNuevoCliente.ResumeLayout(false);
            grpNuevoCliente.PerformLayout();
            ResumeLayout(false);
        }
    }
}
