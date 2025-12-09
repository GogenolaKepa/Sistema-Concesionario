using System;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Entidades.ModulodeSeguridad;
using Modelo; // Asegúrate de incluir el contexto de la base de datos

namespace Vista
{
    public partial class FormFinanciamiento : Form
    {
        private readonly Usuario usuarioActual;

        public FormFinanciamiento(Usuario usuario)
        {
            if (usuario == null || (!usuario.EsAdministrador() && !usuario.EsSubgerenteVentas()))
            {
                MessageBox.Show("Acceso denegado. Solo administradores y subgerentes de ventas pueden acceder.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent();
            CargarFinanciamientos();
        }

        /// <summary>
        /// 📌 Cargar los financiamientos en el DataGridView
        /// </summary>
        private void CargarFinanciamientos()
        {
            using (var _context = new Concesionario())
            {
                var lista = _context.Financiamientos
                    .Select(f => new
                    {
                        f.FinanciamientoId,
                        f.NombreFinanciamiento,
                        f.Interes,
                        f.CantidadCuotas
                    })
                    .ToList();

                dgvFinanciamientos.DataSource = lista;
            }
        }

        /// <summary>
        /// 📌 Agregar un nuevo financiamiento con validaciones
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var _context = new Concesionario())
            {
                string nombre = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del financiamiento", "Nuevo Financiamiento", "").Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del financiamiento no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_context.Financiamientos.Any(f => f.NombreFinanciamiento == nombre))
                {
                    MessageBox.Show("Ya existe un financiamiento con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la tasa de interés (%)", "Nuevo Financiamiento", "0"), out decimal tasaInteres) || tasaInteres < 0)
                {
                    MessageBox.Show("Debe ingresar un número válido para la tasa de interés.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad de cuotas", "Nuevo Financiamiento", "12"), out int cuotas) || cuotas <= 0)
                {
                    MessageBox.Show("Debe ingresar un número válido para las cuotas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevo = new Financiamiento
                {
                    NombreFinanciamiento = nombre,
                    Interes = tasaInteres,
                    CantidadCuotas = cuotas,
                    TerminosYCondicionesFinanciamiento = "aver"
                };

                Concesionario.Instancia.Financiamientos.Add(nuevo);
                Concesionario.Instancia.SaveChanges();
                MessageBox.Show("Financiamiento agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFinanciamientos();
            }
        }

        /// <summary>
        /// 📌 Editar financiamiento seleccionado con validaciones
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFinanciamientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un financiamiento para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = (int)dgvFinanciamientos.SelectedRows[0].Cells["FinanciamientoId"].Value;

            using (var _context = new Concesionario())
            {
                var financiamiento = _context.Financiamientos.Find(id);
                if (financiamiento == null) return;

                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Nuevo nombre del financiamiento", "Editar Financiamiento", financiamiento.NombreFinanciamiento).Trim();
                if (!string.IsNullOrWhiteSpace(nuevoNombre)) financiamiento.NombreFinanciamiento = nuevoNombre;

                if (!decimal.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Nueva tasa de interés (%)", "Editar Financiamiento", financiamiento.Interes.ToString()), out decimal nuevaTasa) || nuevaTasa < 0)
                {
                    MessageBox.Show("Debe ingresar un número válido para la tasa de interés.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                financiamiento.Interes = nuevaTasa;

                if (!int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Nueva cantidad de cuotas", "Editar Financiamiento", financiamiento.CantidadCuotas.ToString()), out int nuevasCuotas) || nuevasCuotas <= 0)
                {
                    MessageBox.Show("Debe ingresar un número válido para las cuotas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                financiamiento.CantidadCuotas = nuevasCuotas;

                _context.SaveChanges();
                MessageBox.Show("Financiamiento actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFinanciamientos();
            }
        }

        /// <summary>
        /// 📌 Eliminar financiamiento seleccionado con confirmación
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFinanciamientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un financiamiento para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = (int)dgvFinanciamientos.SelectedRows[0].Cells["FinanciamientoId"].Value;

            var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este financiamiento?", "Confirmar eliminación",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;

            using (var _context = new Concesionario())
            {
                var financiamiento = _context.Financiamientos.Find(id);
                if (financiamiento == null) return;

                _context.Financiamientos.Remove(financiamiento);
                _context.SaveChanges();
                MessageBox.Show("Financiamiento eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarFinanciamientos();
            }
        }
    }
}
