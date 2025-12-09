namespace Vista
{
    partial class FormMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBienvenida;
        private Button btnCompras, btnInventario, btnVentas, btnFinanciamiento, btnSeguridad, btnCerrarSesion;
        private PictureBox pictureBoxGogenola;

        /// <summary>
        /// Limpieza de recursos.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            lblBienvenida = new Label();
            pictureBoxGogenola = new PictureBox();
            btnCompras = new Button();
            btnInventario = new Button();
            btnVentas = new Button();
            btnFinanciamiento = new Button();
            btnSeguridad = new Button();
            btnCerrarSesion = new Button();

            ((System.ComponentModel.ISupportInitialize)pictureBoxGogenola).BeginInit();
            SuspendLayout();

            // 📌 Formulario
            this.ClientSize = new Size(850, 550);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.BackColor = Color.White;

            // 📌 Logo Gogenola Automotores
            pictureBoxGogenola.Image = (Image)resources.GetObject("pictureBoxGogenola.Image");
            pictureBoxGogenola.Location = new Point(175, 20);
            pictureBoxGogenola.Size = new Size(500, 120);
            pictureBoxGogenola.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGogenola.TabStop = false;

            // 📌 Etiqueta Bienvenida
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenida.Location = new Point(280, 150);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(250, 38);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido, [Usuario]";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;

            // 📌 Configuración de botones
            ConfigurarBoton(btnCompras, "Gestión de Compras", 90, 220, "📦");
            ConfigurarBoton(btnInventario, "Gestión de Inventario", 320, 220, "📋");
            ConfigurarBoton(btnVentas, "Gestión de Ventas", 550, 220, "🛒");
            ConfigurarBoton(btnFinanciamiento, "Financiamiento", 90, 320, "💰");
            ConfigurarBoton(btnSeguridad, "Gestión de Seguridad", 320, 320, "🔒");
            ConfigurarBoton(btnCerrarSesion, "Cerrar Sesión", 550, 320, "🚪");

            // 📌 Asignar eventos de clic
            btnCompras.Click += btnCompras_Click;
            btnInventario.Click += btnInventario_Click;
            btnVentas.Click += btnVentas_Click;
            btnFinanciamiento.Click += btnFinanciamiento_Click;
            btnSeguridad.Click += btnSeguridad_Click;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // 📌 Agregar controles al formulario
            Controls.Add(pictureBoxGogenola);
            Controls.Add(lblBienvenida);
            Controls.Add(btnCompras);
            Controls.Add(btnInventario);
            Controls.Add(btnVentas);
            Controls.Add(btnFinanciamiento);
            Controls.Add(btnSeguridad);
            Controls.Add(btnCerrarSesion);

            ((System.ComponentModel.ISupportInitialize)pictureBoxGogenola).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Configura los botones con estilos modernos y un ícono.
        /// </summary>
        private void ConfigurarBoton(Button boton, string texto, int x, int y, string icono)
        {
            boton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            boton.ForeColor = Color.White;
            boton.BackColor = Color.FromArgb(52, 152, 219);
            boton.FlatStyle = FlatStyle.Flat;
            boton.Size = new Size(220, 80);
            boton.Text = $"{icono} {texto}";
            boton.Location = new Point(x, y);
            boton.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(boton); // 📌 Asegurar que se agregan correctamente
        }
    }
}
