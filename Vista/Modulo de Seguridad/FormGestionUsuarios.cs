using System;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades.ModulodeSeguridad;
using BCrypt.Net;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormGestionUsuarios : Form
    {
        private readonly Concesionario _context = new Concesionario();
        private Usuario usuarioSeleccionado;


        public FormGestionUsuarios(Usuario usuario)
        {
            InitializeComponent();
            usuarioSeleccionado = usuario;
            CargarUsuarios();
            CargarGrupos();
        }

        /// <summary>
        /// Carga la lista de usuarios en el DataGridView
        /// </summary>
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = _context.Usuarios
                .Select(u => new
                {
                    u.UsuarioId,
                    u.NombreUsuario,
                    Grupo = _context.UsuarioGrupos
                        .Where(ug => ug.UsuarioId == u.UsuarioId)
                        .Select(ug => ug.Grupo.NombreGrupo)
                        .FirstOrDefault() // 🔹 Obtiene el primer grupo asignado al usuario
                })
                .ToList();
        }



        /// <summary>
        /// Carga los grupos desde la base de datos en el ComboBox
        /// </summary>
        private void CargarGrupos()
        {
            cmbGrupos.DataSource = _context.Grupos.ToList();
            cmbGrupos.DisplayMember = "NombreGrupo";
            cmbGrupos.ValueMember = "GrupoId";
        }

        /// <summary>
        /// Asigna un grupo seleccionado a un usuario seleccionado
        /// </summary>
        private void btnAsignarGrupo_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para asignarle un grupo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int usuarioId = (int)dgvUsuarios.SelectedRows[0].Cells["UsuarioId"].Value;
            int grupoId = (int)cmbGrupos.SelectedValue;

            // Verifica si el usuario ya está asignado a ese grupo
            var existeRelacion = _context.UsuarioGrupos.Any(ug => ug.UsuarioId == usuarioId && ug.GrupoId == grupoId);
            if (existeRelacion)
            {
                MessageBox.Show("El usuario ya pertenece a este grupo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var usuarioGrupo = new UsuarioGrupo { UsuarioId = usuarioId, GrupoId = grupoId };
            _context.UsuarioGrupos.Add(usuarioGrupo);
            _context.SaveChanges();

            MessageBox.Show("Grupo asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Guarda un nuevo usuario en la base de datos
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtContrasena.Text) || cmbGrupos.SelectedItem == null)
            {
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Crear nuevo usuario
            var usuarioNuevo = new Usuario
            {
                NombreUsuario = txtNombre.Text.Trim(),
                ContrasenaUsuario = BCrypt.Net.BCrypt.HashPassword(txtContrasena.Text.Trim())
            };

            _context.Usuarios.Add(usuarioNuevo);
            _context.SaveChanges(); // 🔹 Guardamos para obtener el ID del usuario

            // 🔹 Asignar grupo al usuario recién creado
            int usuarioId = usuarioNuevo.UsuarioId;
            int grupoId = (int)cmbGrupos.SelectedValue; // Asegurar que se toma el grupo correcto

            var usuarioGrupo = new UsuarioGrupo { UsuarioId = usuarioId, GrupoId = grupoId };
            _context.UsuarioGrupos.Add(usuarioGrupo);
            _context.SaveChanges(); // 🔹 Guardamos la relación usuario-grupo

            MessageBox.Show("Usuario y grupo guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarios(); // 🔹 Recargar la lista con los cambios
            LimpiarCampos();
        }



        /// <summary>
        /// Edita un usuario seleccionado
        /// </summary>
        /// <summary>
        /// Edita un usuario seleccionado y actualiza su grupo
        /// </summary>
        /// <summary>
        /// Edita un usuario seleccionado y actualiza su grupo
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario antes de editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuarioSeleccionado.NombreUsuario = txtNombre.Text.Trim();

            // 🔹 Verificar si se ingresó una nueva contraseña y actualizarla
            if (!string.IsNullOrEmpty(txtContrasena.Text))
            {
                usuarioSeleccionado.ContrasenaUsuario = BCrypt.Net.BCrypt.HashPassword(txtContrasena.Text.Trim());
            }

            _context.SaveChanges(); // Guardamos cambios en el usuario

            // 🔹 Obtener el nuevo grupo seleccionado en el ComboBox
            int nuevoGrupoId = (int)cmbGrupos.SelectedValue;

            // 🔹 Buscar si el usuario ya tiene un grupo asignado
            var usuarioGrupo = _context.UsuarioGrupos.FirstOrDefault(ug => ug.UsuarioId == usuarioSeleccionado.UsuarioId);

            if (usuarioGrupo != null)
            {
                // 🔹 Eliminar la relación anterior
                _context.UsuarioGrupos.Remove(usuarioGrupo);
                _context.SaveChanges();
            }

            // 🔹 Insertar nueva relación usuario-grupo
            var nuevoUsuarioGrupo = new UsuarioGrupo
            {
                UsuarioId = usuarioSeleccionado.UsuarioId,
                GrupoId = nuevoGrupoId
            };

            _context.UsuarioGrupos.Add(nuevoUsuarioGrupo);
            _context.SaveChanges(); // Guardamos la nueva relación

            MessageBox.Show("Usuario y grupo actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarios(); // Recargar lista de usuarios
            LimpiarCampos();
        }




        /// <summary>
        /// Elimina el usuario seleccionado
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["UsuarioId"].Value);

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este usuario?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                using (var context = new Concesionario()) // 🔹 Usamos un nuevo contexto
                {
                    var usuarioAEliminar = context.Usuarios
                        .FirstOrDefault(u => u.UsuarioId == usuarioId);

                    if (usuarioAEliminar != null)
                    {
                        context.Usuarios.Remove(usuarioAEliminar);
                        context.SaveChanges();

                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarUsuarios();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /*private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario antes de cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Ingrese una nueva contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CambiarContrasena(usuarioSeleccionado.UsuarioId, txtContrasena.Text.Trim());
        }

        private void CambiarContrasena(int usuarioId, string nuevaContrasena)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);

            if (usuario != null)
            {
                usuario.ContrasenaUsuario = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);
                _context.SaveChanges();
                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/


        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtContrasena.Text = "";
            usuarioSeleccionado = null;
        }

        /// <summary>
        /// Carga los datos del usuario seleccionado en el DataGridView
        /// </summary>
        /// <summary>
        /// Carga los datos del usuario seleccionado en los campos del formulario
        /// </summary>
        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int usuarioId = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["UsuarioId"].Value);

                // 🔹 Buscar el usuario en la base de datos y actualizar `usuarioSeleccionado`
                usuarioSeleccionado = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);

                if (usuarioSeleccionado != null)
                {
                    txtNombre.Text = usuarioSeleccionado.NombreUsuario;
                    cmbGrupos.SelectedValue = _context.UsuarioGrupos
                        .Where(ug => ug.UsuarioId == usuarioSeleccionado.UsuarioId)
                        .Select(ug => ug.GrupoId)
                        .FirstOrDefault(); // 🔹 Selecciona el grupo asignado al usuario

                    // Limpiar el campo de contraseña para no mostrar contraseñas en texto plano
                    txtContrasena.Text = "";
                }
            }
        }



        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
