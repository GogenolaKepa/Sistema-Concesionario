using System;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades.ModulodeSeguridad;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormGestionGrupos : Form
    {
        private readonly Concesionario _context = new Concesionario();

        public FormGestionGrupos()
        {
            InitializeComponent();
            CargarGrupos();
        }

        private void CargarGrupos()
        {
            dgvGrupos.DataSource = _context.Grupos.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nuevoGrupo = txtNombreGrupo.Text.Trim();

            if (string.IsNullOrEmpty(nuevoGrupo))
            {
                MessageBox.Show("El nombre del grupo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_context.Grupos.Any(g => g.NombreGrupo == nuevoGrupo))
            {
                MessageBox.Show("Ya existe un grupo con este nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _context.Grupos.Add(new Grupo { NombreGrupo = nuevoGrupo });
            _context.SaveChanges();

            CargarGrupos();
            txtNombreGrupo.Clear();
            MessageBox.Show("Grupo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un grupo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int grupoId = (int)dgvGrupos.SelectedRows[0].Cells["GrupoId"].Value;
            var grupo = _context.Grupos.Find(grupoId);

            if (grupo == null) return;

            if (grupo.NombreGrupo == "Administrador")
            {
                MessageBox.Show("No puedes eliminar el grupo Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _context.Grupos.Remove(grupo);
            _context.SaveChanges();
            CargarGrupos();
            MessageBox.Show("Grupo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un grupo para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int grupoId = (int)dgvGrupos.SelectedRows[0].Cells["GrupoId"].Value;
            var grupo = _context.Grupos.Find(grupoId);

            if (grupo == null) return;

            string nuevoNombre = txtNombreGrupo.Text.Trim();
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            grupo.NombreGrupo = nuevoNombre;
            _context.SaveChanges();
            CargarGrupos();
            MessageBox.Show("Grupo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
