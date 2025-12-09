namespace Vista
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnIngresar;
        private Button btnCancelar;
        private Button btnMostrarContraseña;
        private Label lblUsuario;
        private Label lblContraseña;
        private Label lblError;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private PictureBox pictureBoxGogenola;

        /// <summary>
        ///  Cleanup de recursos.
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
        ///  Inicialización del formulario
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            btnIngresar = new Button();
            btnCancelar = new Button();
            btnMostrarContraseña = new Button();
            lblUsuario = new Label();
            lblContraseña = new Label();
            lblError = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            pictureBoxGogenola = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGogenola).BeginInit();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(52, 152, 219);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(59, 415);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(144, 50);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(231, 76, 60);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(209, 415);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(144, 50);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnMostrarContraseña
            // 
            btnMostrarContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMostrarContraseña.Location = new Point(376, 290);
            btnMostrarContraseña.Name = "btnMostrarContraseña";
            btnMostrarContraseña.Size = new Size(62, 39);
            btnMostrarContraseña.TabIndex = 5;
            btnMostrarContraseña.Text = "👁";
            btnMostrarContraseña.Click += btnMostrarContraseña_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.Location = new Point(50, 180);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(102, 32);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblContraseña.Location = new Point(50, 260);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(143, 32);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(50, 343);
            lblError.Name = "lblError";
            lblError.Size = new Size(301, 28);
            lblError.TabIndex = 6;
            lblError.Text = "Usuario o contraseña incorrectos.";
            lblError.Visible = false;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(50, 210);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(310, 39);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtContraseña.Location = new Point(50, 290);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(310, 39);
            txtContraseña.TabIndex = 4;
            txtContraseña.PasswordChar = '*';  // 📌 Se oculta la contraseña por defecto

            // 
            // pictureBoxGogenola
            // 
            pictureBoxGogenola.Image = (Image)resources.GetObject("pictureBoxGogenola.Image");
            pictureBoxGogenola.Location = new Point(10, 20);
            pictureBoxGogenola.Name = "pictureBoxGogenola";
            pictureBoxGogenola.Size = new Size(440, 140);
            pictureBoxGogenola.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGogenola.TabIndex = 0;
            pictureBoxGogenola.TabStop = false;
            // 
            // FormLogin
            // 
            BackColor = Color.White;
            ClientSize = new Size(460, 498);
            Controls.Add(pictureBoxGogenola);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContraseña);
            Controls.Add(txtContraseña);
            Controls.Add(btnMostrarContraseña);
            Controls.Add(lblError);
            Controls.Add(btnIngresar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            ((System.ComponentModel.ISupportInitialize)pictureBoxGogenola).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
