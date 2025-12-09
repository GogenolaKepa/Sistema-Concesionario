using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades;
using Entidades.ModulodeSeguridad;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing;

namespace Vista
{
    public partial class FormCompras : Form
    {
        private readonly Concesionario _context = new Concesionario();
        private readonly Usuario usuarioActual;

        public FormCompras(Usuario usuario)
        {
            if (usuario == null || !usuario.EsAdministrador())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden gestionar compras.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent();
            CargarProveedores();
            HardcodearVehiculos();
            ActualizarEstadosOrdenes();
        }

        private void HardcodearVehiculos()
        {
            try
            {
                Concesionario.Instancia.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Error al guardar cambios: {innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            var proveedores = Concesionario.Instancia.Proveedores.ToList();

            if (proveedores.Count == 0)
            {
                MessageBox.Show("No hay proveedores disponibles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "NombreProveedor";
            cmbProveedores.ValueMember = "ProveedorId";
        }

        private void cmbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            lstHistorial.Items.Clear();
            var historialCompras = Concesionario.Instancia.OrdenesCompra
                .Select(o => $"Orden {o.OrdenCompraId} - {o.FechaPedido} - Estado: {o.EstadoOrdenCompra.EstadoActual}")
                .ToList();

            if (historialCompras.Any())
            {
                lstHistorial.Items.AddRange(historialCompras.ToArray());
            }
            else
            {
                lstHistorial.Items.Add("No hay compras registradas.");
            }
        }

        private void CargarVehiculos()
        {
            if (cmbProveedores.SelectedItem == null) return;

            int proveedorId = (int)cmbProveedores.SelectedValue;
            string filtro = txtBuscar.Text.Trim().ToLower();

            var vehiculos = Concesionario.Instancia.Vehiculos
                .Where(v => v.ProveedorId == proveedorId &&
                            (v.Marca.ToLower().Contains(filtro) || v.Modelo.ToLower().Contains(filtro)))
                .Select(v => new
                {
                    v.VehiculoId,
                    v.Marca,
                    v.Modelo,
                    Año = v.Anio,
                    v.Precio,
                    v.Disponibilidad
                })
                .ToList();

            if (vehiculos.Count == 0)
            {
                MessageBox.Show("No hay vehículos disponibles para este proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvVehiculos.DataSource = vehiculos;
        }
        private void ActualizarEstadosOrdenes()
        {
            Random rand = new Random();

            var ordenesPendientes = Concesionario.Instancia.OrdenesCompra
                .Where(o => o.EstadoOrdenCompra.EstadoActual == "Pendiente")
                .ToList();

            foreach (var orden in ordenesPendientes)
            {
                orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                    .FirstOrDefault(e => e.EstadoActual == "Confirmado")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
            }

            var ordenesConfirmadas = Concesionario.Instancia.OrdenesCompra
                .Where(o => o.EstadoOrdenCompra.EstadoActual == "Confirmado")
                .ToList();

            foreach (var orden in ordenesConfirmadas)
            {
                int decision = rand.Next(1, 101); // Genera un número entre 1 y 100

                if (decision <= 80) // 80% de chance de pasar a "Por Entregar"
                {
                    orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                        .FirstOrDefault(e => e.EstadoActual == "Por Entregar")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
                }
                else // 20% de chance de ser "Cancelado"
                {
                    orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                        .FirstOrDefault(e => e.EstadoActual == "Cancelado")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
                }
            }

            var ordenesPorEntregar = Concesionario.Instancia.OrdenesCompra
                .Where(o => o.EstadoOrdenCompra.EstadoActual == "Por Entregar")
                .ToList();

            foreach (var orden in ordenesPorEntregar)
            {
                int decision = rand.Next(1, 101); // Genera un número entre 1 y 100

                if (decision <= 70) // 70% chance de ser "Entregado"
                {
                    orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                        .FirstOrDefault(e => e.EstadoActual == "Entregado")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
                }
                else if (decision <= 85) // 15% chance de "Entregado con Faltante"
                {
                    orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                        .FirstOrDefault(e => e.EstadoActual == "Entregado con Faltante")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
                }
                else // 15% chance de "Parcialmente Entregado"
                {
                    orden.EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
                        .FirstOrDefault(e => e.EstadoActual == "Parcialmente Entregado")?.EstadoOrdenCompraId ?? orden.EstadoOrdenCompraId;
                }
            }

            Concesionario.Instancia.SaveChanges();
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vehiculoId = (int)dgvVehiculos.SelectedRows[0].Cells["VehiculoId"].Value;
            int cantidad = (int)nudCantidad.Value;

            var vehiculo = Concesionario.Instancia.Vehiculos.FirstOrDefault(v => v.VehiculoId == vehiculoId);
            if (vehiculo == null || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (vehiculo.ProveedorId <= 0)
            {
                MessageBox.Show("El vehículo seleccionado no tiene un proveedor válido.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal total = vehiculo.Precio * cantidad;
            DialogResult confirmacion = MessageBox.Show(
                $"Está a punto de comprar {cantidad} unidades del {vehiculo.Marca} {vehiculo.Modelo}.\n\nTotal: ${total:N2}\n\n¿Desea confirmar la compra?",
                "Confirmar Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No) return;

            try
            {
                var nuevaOrden = new OrdenCompra
                {
                    ProveedorId = vehiculo.ProveedorId,
                    FechaPedido = DateTime.Now.ToString("yyyy-MM-dd"),
                    EstadoOrdenCompraId = Concesionario.Instancia.EstadosOrdenCompra
        .FirstOrDefault(e => e.EstadoActual == "Pendiente")?.EstadoOrdenCompraId ?? 1,
                    MontoTotal = total
                };

                Concesionario.Instancia.OrdenesCompra.Add(nuevaOrden);
                Concesionario.Instancia.SaveChanges(); 

                var detalleCompra = new DetalleCompra
                {
                    OrdenCompraId = nuevaOrden.OrdenCompraId,
                    VehiculoId = vehiculo.VehiculoId,
                    Cantidad = cantidad,
                    PrecioUnitario = vehiculo.Precio
                };

                Concesionario.Instancia.DetallesCompra.Add(detalleCompra);
                Concesionario.Instancia.SaveChanges(); // ✅ Guardamos nuevamente

                MessageBox.Show("Compra registrada con éxito.", "Gestión de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnActualizarLista_Click(sender, e);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Error al guardar la compra: {innerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarVehiculos();
            btnVerHistorial_Click(sender, e); // También actualiza el historial de compras
            MessageBox.Show("Lista de vehículos y órdenes actualizada.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // 📌 1️⃣ Crear el primer gráfico circular (Compras por Proveedor)
            Chart pieChart = new Chart { Size = new Size(600, 400) };
            ChartArea chartArea1 = new ChartArea();
            pieChart.ChartAreas.Add(chartArea1);
            Series pieSeries = new Series { ChartType = SeriesChartType.Pie };
            pieChart.Series.Add(pieSeries);

            var comprasPorProveedor = Concesionario.Instancia.OrdenesCompra
                .GroupBy(o => o.Proveedor.NombreProveedor)
                .Select(g => new { Proveedor = g.Key, TotalCompras = g.Sum(o => o.MontoTotal) })
                .ToList();

            if (!comprasPorProveedor.Any())
            {
                MessageBox.Show("No hay compras registradas para generar el PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var compra in comprasPorProveedor)
            {
                pieSeries.Points.AddXY(compra.Proveedor, compra.TotalCompras);
            }
            pieSeries.IsValueShownAsLabel = true;

            // 📌 Guardar el gráfico circular como imagen
            string pieChartPath = Path.Combine(Path.GetTempPath(), "grafico_compras.png");
            pieChart.SaveImage(pieChartPath, ChartImageFormat.Png);

            // 📌 2️⃣ Crear el segundo gráfico de barras (Cantidad de vehículos comprados por marca)
            Chart barChart = new Chart { Size = new Size(600, 400) };
            ChartArea chartArea2 = new ChartArea();
            barChart.ChartAreas.Add(chartArea2);
            Series barSeries = new Series { ChartType = SeriesChartType.Column };
            barChart.Series.Add(barSeries);

            var comprasPorMarca = Concesionario.Instancia.DetallesCompra
                .GroupBy(d => d.Vehiculo.Marca)
                .Select(g => new { Marca = g.Key, Cantidad = g.Sum(d => d.Cantidad) })
                .ToList();

            foreach (var compra in comprasPorMarca)
            {
                barSeries.Points.AddXY(compra.Marca, compra.Cantidad);
            }
            barSeries.IsValueShownAsLabel = true;

            // 📌 Guardar el gráfico de barras como imagen
            string barChartPath = Path.Combine(Path.GetTempPath(), "grafico_vehiculos.png");
            barChart.SaveImage(barChartPath, ChartImageFormat.Png);

            // 📌 3️⃣ Definir la ruta específica para guardar en el Escritorio
            string desktopPath = @"C:\Users\kepag\OneDrive\Escritorio";
            string pdfPath = Path.Combine(desktopPath, "Reporte_Compras.pdf");

            // 📌 4️⃣ Generar el PDF con ambos gráficos
            Document pdfDoc = new Document(PageSize.A4.Rotate());
            try
            {
                using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
                {
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // 🔹 Título del reporte con iTextSharp.text.Font
                    iTextSharp.text.Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Paragraph title = new Paragraph("Reporte de Compras\n\n", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // 🔹 Insertar gráfico circular (Compras por proveedor)
                    iTextSharp.text.Image pieChartImage = iTextSharp.text.Image.GetInstance(pieChartPath);
                    pieChartImage.ScaleToFit(350f, 250f);
                    pieChartImage.Alignment = Element.ALIGN_LEFT;

                    // 🔹 Insertar gráfico de barras (Vehículos comprados por marca)
                    iTextSharp.text.Image barChartImage = iTextSharp.text.Image.GetInstance(barChartPath);
                    barChartImage.ScaleToFit(350f, 250f);
                    barChartImage.Alignment = Element.ALIGN_RIGHT;

                    // 🔹 Insertamos ambos gráficos en una tabla de 2 columnas
                    PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };
                    PdfPCell cell1 = new PdfPCell(pieChartImage) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                    PdfPCell cell2 = new PdfPCell(barChartImage) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER };
                    table.AddCell(cell1);
                    table.AddCell(cell2);
                    pdfDoc.Add(table);

                    // 🔹 Agregar detalles de las compras
                    pdfDoc.Add(new Paragraph("\nDetalles de las compras por proveedor:\n\n"));
                    foreach (var compra in comprasPorProveedor)
                    {
                        pdfDoc.Add(new Paragraph($"Proveedor: {compra.Proveedor} - Total Comprado: ${compra.TotalCompras:N2}\n"));
                    }

                    pdfDoc.Add(new Paragraph("\nDetalles de la cantidad de vehículos comprados por marca:\n\n"));
                    foreach (var compra in comprasPorMarca)
                    {
                        pdfDoc.Add(new Paragraph($"Marca: {compra.Marca} - Cantidad Comprada: {compra.Cantidad}\n"));
                    }

                    pdfDoc.Close();
                }

                // 📌 5️⃣ Abrir el PDF generado
                MessageBox.Show($"PDF generado con éxito en: {pdfPath}", "Gestión de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var process = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(process);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}