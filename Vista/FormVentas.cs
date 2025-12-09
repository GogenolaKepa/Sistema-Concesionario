using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Entidades;
using Modelo;
using Entidades.ModulodeSeguridad;

namespace Vista
{
    public partial class FormVentas : Form
    {
        private readonly Usuario usuarioActual;
        private Vehiculo vehiculoSeleccionado;
        private Cliente clienteSeleccionado;

        public FormVentas(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("Error: Usuario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent();
            CargarVehiculos();
            CargarAutosVendidos();
            CargarOpcionesFinanciamiento();
        }

        private void CargarVehiculos()
        {

            var vehiculosDisponibles = Concesionario.Instancia.Inventarios
                .SelectMany(i => i.Vehiculos)
                .Where(v => v.Disponibilidad && Concesionario.Instancia.DetallesCompra.Any(dc => dc.VehiculoId == v.VehiculoId))
                .Select(v => new { v.VehiculoId, Nombre = v.Marca + " " + v.Modelo })
                .Distinct()
                .ToList();

            cmbVehiculos.DataSource = vehiculosDisponibles;
            cmbVehiculos.DisplayMember = "Nombre";
            cmbVehiculos.ValueMember = "VehiculoId";

        }

        private void CargarOpcionesFinanciamiento()
        {
            using (var _context = new Concesionario())
            {
                var opciones = Concesionario.Instancia.Financiamientos
                    .Select(f => new { f.FinanciamientoId, f.NombreFinanciamiento })
                    .ToList();

                opciones.Insert(0, new { FinanciamientoId = 0, NombreFinanciamiento = "Pago de contado" });

                cmbFinanciamiento.DataSource = opciones;
                cmbFinanciamiento.DisplayMember = "NombreFinanciamiento";
                cmbFinanciamiento.ValueMember = "FinanciamientoId";
            }
        }

        private void CargarAutosVendidos()
        {
            using (var _context = new Concesionario())
            {
                var autosVendidos = Concesionario.Instancia.Pedidos
                    .Include(p => p.Cliente)
                    .Include(p => p.DetallesPedido)
                    .ThenInclude(d => d.Vehiculo)
                    .Where(p => p.EstadoPedido.EstadoActual == "Aprobado")
                    .SelectMany(p => p.DetallesPedido)
                    .Select(d => new
                    {
                        Cliente = d.Pedido.Cliente.NombreCliente,
                        Vehiculo = d.Vehiculo.Marca + " " + d.Vehiculo.Modelo,
                        FechaVenta = d.Pedido.FechaPedido.ToString("dd/MM/yyyy"),
                        Precio = d.PrecioUnitario
                    })
                    .ToList();

                dgvAutosVendidos.DataSource = autosVendidos;
            }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            using (var formCliente = new FormCliente())
            {
                formCliente.ShowDialog();
                if (formCliente.ClienteSeleccionado != null)
                {
                    clienteSeleccionado = formCliente.ClienteSeleccionado;
                    txtClienteSeleccionado.Text = clienteSeleccionado.NombreCliente;
                }
            }
        }

        private void cmbVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehiculos.SelectedValue != null && int.TryParse(cmbVehiculos.SelectedValue.ToString(), out int idVehiculo))
            {
                using (var _context = new Concesionario())
                {
                    vehiculoSeleccionado = Concesionario.Instancia.Vehiculos.FirstOrDefault(v => v.VehiculoId == idVehiculo);
                }
            }
        }

        private void btnGestionarFinanciamiento_Click(object sender, EventArgs e)
        {
            using (var formFinanciamiento = new FormFinanciamiento(usuarioActual))
            {
                formFinanciamiento.ShowDialog();
                CargarOpcionesFinanciamiento();
            }
        }

        private void btnAprobarVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botón de aprobar venta clickeado.");
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null || cmbVehiculos.SelectedValue == null || cmbFinanciamiento.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente, un vehículo y un financiamiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int vehiculoId = (int)cmbVehiculos.SelectedValue;
            int financiamientoId = (int)cmbFinanciamiento.SelectedValue;

            using (var _context = new Concesionario())
            {
                var clienteEnBD = Concesionario.Instancia.Clientes.FirstOrDefault(c => c.IdCliente == clienteSeleccionado.IdCliente);
                var vehiculoEnBD = Concesionario.Instancia.Vehiculos.FirstOrDefault(v => v.VehiculoId == vehiculoId);
                var estadoPendiente = Concesionario.Instancia.EstadosPedido.FirstOrDefault(e => e.EstadoActual == "Aprobado");
                var financiamientoSeleccionado = Concesionario.Instancia.Financiamientos.FirstOrDefault(f => f.FinanciamientoId == financiamientoId);

                if (clienteEnBD == null || vehiculoEnBD == null || estadoPendiente == null || financiamientoSeleccionado == null)
                {
                    MessageBox.Show("Error al cargar datos de la BD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevoPedido = new Pedido
                {
                    Cliente = clienteEnBD,
                    FechaPedido = DateTime.Now,
                    EstadoPedido = estadoPendiente,
                    FinanciamientoId = financiamientoSeleccionado.FinanciamientoId,
                    PagoDeContado = financiamientoSeleccionado.FinanciamientoId == 0
                };

                Concesionario.Instancia.Pedidos.Add(nuevoPedido);
                Concesionario.Instancia.SaveChanges();

                var detalle = new DetallePedido
                {
                    Pedido = nuevoPedido,
                    VehiculoId = vehiculoEnBD.VehiculoId,
                    Cantidad = 1,
                    PrecioUnitario = vehiculoEnBD.Precio
                };

                Concesionario.Instancia.DetallesPedido.Add(detalle);
                Concesionario.Instancia.SaveChanges();

                vehiculoEnBD.Disponibilidad = false;
                Concesionario.Instancia.Vehiculos.Update(vehiculoEnBD);
                Concesionario.Instancia.SaveChanges();

                MessageBox.Show("Pedido registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAutosVendidos();
                CargarVehiculos();
            }
        }
    }
}
