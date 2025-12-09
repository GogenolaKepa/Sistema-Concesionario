using System;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades.ModulodeSeguridad;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormGestionPermisos : Form
    {
        private readonly Concesionario _context = new Concesionario();
        private readonly Usuario usuarioActual;

        public FormGestionPermisos(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario ?? throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            ConfigurarPermisos();
            CargarGrupos();
        }

        private void ConfigurarPermisos()
        {
            if (!usuarioActual.EsAdministrador())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder a esta sección.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }


        private void CargarGrupos()
        {
            cmbGrupos.DataSource = _context.Grupos.ToList();
            cmbGrupos.DisplayMember = "NombreGrupo";
            cmbGrupos.ValueMember = "GrupoId";
        }


        private void btnCargarPermisos_Click(object sender, EventArgs e)
        {
            if (cmbGrupos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grupo antes de cargar los permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int grupoId = (int)cmbGrupos.SelectedValue;
            clbPermisos.Items.Clear();

            using (var context = new Concesionario())
            {
                var permisos = context.Permisos.ToList();

                var permisosGrupo = context.GrupoPermisos
                    .Where(gp => gp.GrupoId == grupoId)
                    .Select(gp => gp.PermisoId)
                    .ToList();

                foreach (var permiso in permisos)
                {
                    bool asignado = permisosGrupo.Contains(permiso.PermisoId);
                    clbPermisos.Items.Add(permiso.NombrePermiso, asignado);
                }
            }
        }

        private void CargarPermisos(int grupoId)
        {
            clbPermisos.Items.Clear();

            var permisos = _context.Permisos.ToList();
            var permisosGrupo = _context.GrupoPermisos
                .Where(gp => gp.GrupoId == grupoId)
                .Select(gp => gp.PermisoId)
                .ToList();

            foreach (var permiso in permisos)
            {
                int index = clbPermisos.Items.Add(permiso.NombrePermiso, permisosGrupo.Contains(permiso.PermisoId));
                clbPermisos.SetItemChecked(index, permisosGrupo.Contains(permiso.PermisoId));
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbGrupos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un grupo primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int grupoId = (int)cmbGrupos.SelectedValue;

            using (var context = new Concesionario())
            {
                var permisosSeleccionados = clbPermisos.CheckedItems.Cast<string>().ToList();
                var permisosIds = context.Permisos
                    .Where(p => permisosSeleccionados.Contains(p.NombrePermiso))
                    .Select(p => p.PermisoId)
                    .ToList();

                var permisosActuales = context.GrupoPermisos.Where(gp => gp.GrupoId == grupoId).ToList();

                foreach (var permisoId in permisosIds)
                {
                    if (!permisosActuales.Any(gp => gp.PermisoId == permisoId))
                    {
                        context.GrupoPermisos.Add(new GrupoPermiso { GrupoId = grupoId, PermisoId = permisoId });
                    }
                }

                foreach (var permisoActual in permisosActuales)
                {
                    if (!permisosIds.Contains(permisoActual.PermisoId))
                    {
                        context.GrupoPermisos.Remove(permisoActual);
                    }
                }

                context.SaveChanges();
            }

            MessageBox.Show("Permisos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbPermisos.Items.Count; i++)
            {
                clbPermisos.SetItemChecked(i, false);
            }
        }
    }
}
