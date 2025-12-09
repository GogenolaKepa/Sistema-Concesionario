using System;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades.ModulodeSeguridad;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Vista
{
    public partial class FormLogin : Form
    {
        private readonly Concesionario _context = new Concesionario();

        public FormLogin()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string contraseñaIngresada = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuarioIngresado) || string.IsNullOrEmpty(contraseñaIngresada))
            {
                MostrarMensajeError("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                // Buscar usuario en la base de datos
                var usuario = _context.Usuarios
                    .Include(u => u.Grupos) // 🔹 Carga los grupos del usuario
                    .ThenInclude(ug => ug.Grupo) // 🔹 Carga la información del grupo
                    .FirstOrDefault(u => u.NombreUsuario == usuarioIngresado);

                if (usuario == null)
                {
                    MostrarMensajeError("Usuario no encontrado.");

                    // 🔹 Registrar intento de inicio de sesión fallido en la auditoría
                    _context.RegistrarAuditoria(usuarioIngresado, "Intento de inicio de sesión fallido", "Usuario no encontrado.");
                    return;
                }

                if (string.IsNullOrEmpty(usuario.ContrasenaUsuario))
                {
                    MostrarMensajeError("Error: La contraseña del usuario no está almacenada correctamente.");
                    return;
                }

                // 🔐 Verificación de la contraseña
                bool esContraseñaCorrecta = false;
                try
                {
                    esContraseñaCorrecta = BCrypt.Net.BCrypt.Verify(contraseñaIngresada, usuario.ContrasenaUsuario);
                }
                catch (Exception)
                {
                    MostrarMensajeError("Error en la verificación de la contraseña.");
                    return;
                }

                if (esContraseñaCorrecta)
                {
                    MessageBox.Show("Inicio de sesión exitoso.", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Registrar inicio de sesión exitoso en la auditoría
                    _context.RegistrarAuditoria(usuario.NombreUsuario, "Inicio de sesión", "El usuario inició sesión correctamente.");

                    FormMenuPrincipal menu = new FormMenuPrincipal(usuario);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MostrarMensajeError("Usuario o contraseña incorrectos.");

                    // 🔹 Registrar intento fallido en la auditoría
                    _context.RegistrarAuditoria(usuario.NombreUsuario, "Intento de inicio de sesión fallido", "Contraseña incorrecta.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error inesperado: {ex.Message}");

                // 🔹 Registrar error en la auditoría
                _context.RegistrarAuditoria(usuarioIngresado, "Error en inicio de sesión", ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            // Alterna entre ocultar y mostrar la contraseña
            txtContraseña.PasswordChar = (txtContraseña.PasswordChar == '*') ? '\0' : '*';
        }

        /// <summary>
        /// Muestra un mensaje de error en la etiqueta correspondiente
        /// </summary>
        private void MostrarMensajeError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}
