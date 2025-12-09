using System;
using System.Linq;
using System.Windows.Forms;
using Entidades.ModulodeSeguridad;
using Modelo;
using Vista.Modulo_de_Seguridad;

namespace Vista
{
    public partial class FormMenuPrincipal : Form
    {
        private readonly Usuario usuarioActual;

        public FormMenuPrincipal(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("Error: Usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent(); // Asegura que el formulario se inicializa correctamente

            lblBienvenida.Text = $"Bienvenido, {usuarioActual.NombreUsuario}";

            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (usuarioActual == null) return;

            // 🔹 Ocultamos todos los botones por defecto
            btnSeguridad.Visible = false;
            btnCompras.Visible = false;
            btnInventario.Visible = false;
            btnVentas.Visible = false;
            btnFinanciamiento.Visible = false;

            // 🔹 Administrador: acceso total
            if (usuarioActual.EsAdministrador())
            {
                btnSeguridad.Visible = true;
                btnCompras.Visible = true;
                btnInventario.Visible = true;
                btnVentas.Visible = true;
                btnFinanciamiento.Visible = true;
                return;
            }
            if (usuarioActual.EsSubgerenteVentas())
            {
                btnInventario.Visible = true;
                btnVentas.Visible = true;
                btnFinanciamiento.Visible = true;
                return;
            }
            if (usuarioActual.EsGerenteVentas())
            {
                btnInventario.Visible = true;
                btnVentas.Visible = true;
                btnFinanciamiento.Visible = true;
                return;
            }
            if (usuarioActual.esEmpleadoNuevo())
            {
                btnInventario.Visible = true;
                return;
            }
        }


        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormInventario(usuarioActual)); // 🔹 Pasamos usuario
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormCompras(usuarioActual));
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormVentas(usuarioActual));
        }

        private void btnFinanciamiento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormFinanciamiento(usuarioActual));
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormSeguridad(usuarioActual));
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                this.Dispose();  // Liberamos recursos del formulario
                Concesionario.Instancia.RegistrarAuditoria(usuarioActual.NombreUsuario, "Cierre de sesión", "El usuario cerró sesión.");

                FormLogin login = new FormLogin();
                login.Show();
            }
        }

        /// <summary>
        /// 🔹 Método para abrir formularios con manejo de errores
        /// </summary>
        private void AbrirFormulario(Func<Form> crearFormulario)
        {
            try
            {
                using (Form form = crearFormulario())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
