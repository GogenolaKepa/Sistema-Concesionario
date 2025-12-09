using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormCliente : Form
    {
        private readonly Concesionario _context = new Concesionario();
        public Cliente ClienteSeleccionado { get; private set; }

        public FormCliente()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idCliente = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["IdCliente"].Value);
                ClienteSeleccionado = _context.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);

                if (ClienteSeleccionado != null)
                {
                    MessageBox.Show($"Cliente seleccionado: {ClienteSeleccionado.NombreCliente} (DNI: {ClienteSeleccionado.DNI})",
                                    "Selección Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNumContacto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtDNI.Text.All(char.IsDigit) || txtDNI.Text.Length < 7 || txtDNI.Text.Length > 8)
            {
                MessageBox.Show("El DNI debe contener solo números y tener entre 7 y 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente nuevoCliente = new Cliente
            {
                NombreCliente = txtNombreCliente.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                NumContacto = txtNumContacto.Text.Trim()
            };

            try
            {
                _context.Clientes.Add(nuevoCliente);
                _context.SaveChanges();

                MessageBox.Show("Cliente agregado con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = _context.Clientes
                .Select(c => new { c.IdCliente, c.NombreCliente, c.DNI, c.NumContacto })
                .ToList();
        }
    }
}
