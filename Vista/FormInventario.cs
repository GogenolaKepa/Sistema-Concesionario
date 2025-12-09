using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using Modelo;
using Entidades;
using Entidades.ModulodeSeguridad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;
using Font = iTextSharp.text.Font;

namespace Vista
{
    public partial class FormInventario : Form
    {
        private readonly Concesionario _context = new Concesionario();
        private readonly Usuario usuarioActual;
        public Vehiculo VehiculoSeleccionado { get; private set; }

        public FormInventario(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("Acceso denegado. Se requiere un usuario válido.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent();
            CargarFiltroDisponibilidad();
            CargarInventario();
        }

        private void CargarFiltroDisponibilidad()
        {
            cmbDisponibilidad.Items.Clear();
            cmbDisponibilidad.Items.Add("Todos");
            cmbDisponibilidad.Items.Add("Disponibles");
            cmbDisponibilidad.Items.Add("Vendidos");
            cmbDisponibilidad.SelectedIndex = 0;
        }

        private void CargarInventario()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            string filtroDisponibilidad = cmbDisponibilidad.SelectedItem.ToString();

            var consulta = _context.DetallesCompra
                .Select(dc => dc.Vehiculo)
                .Distinct();

            if (!string.IsNullOrEmpty(filtro))
            {
                consulta = consulta.Where(v => v.Marca.ToLower().Contains(filtro) || v.Modelo.ToLower().Contains(filtro));
            }

            if (filtroDisponibilidad == "Disponibles")
            {
                consulta = consulta.Where(v => v.Disponibilidad);
            }
            else if (filtroDisponibilidad == "Vendidos")
            {
                consulta = consulta.Where(v => !v.Disponibilidad);
            }

            var inventario = consulta
                .Select(v => new
                {
                    v.VehiculoId,
                    v.Marca,
                    v.Modelo,
                    Año = v.Anio,
                    v.Precio,
                    Disponibilidad = v.Disponibilidad ? "Disponible" : "Vendido",
                    Proveedor = v.Proveedor.NombreProveedor
                })
                .ToList();

            dgvInventario.DataSource = inventario;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void cmbDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un vehículo para marcarlo como vendido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vehiculoId = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells["VehiculoId"].Value);

            var vehiculo = _context.Vehiculos.FirstOrDefault(v => v.VehiculoId == vehiculoId);
            if (vehiculo != null && vehiculo.Disponibilidad)
            {
                vehiculo.Disponibilidad = false;
                _context.SaveChanges();
                MessageBox.Show("Vehículo marcado como vendido.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventario();
            }
            else
            {
                MessageBox.Show("El vehículo ya ha sido vendido o no está disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private string GenerarGraficoInventario()
        {
            string rutaImagen = Path.Combine(Path.GetTempPath(), "GraficoInventario.png");
            Bitmap bitmap = new Bitmap(500, 300);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            var disponibles = dgvInventario.Rows.Cast<DataGridViewRow>().Count(r => r.Cells["Disponibilidad"].Value.ToString() == "Disponible");
            var vendidos = dgvInventario.Rows.Cast<DataGridViewRow>().Count(r => r.Cells["Disponibilidad"].Value.ToString() == "Vendido");

            int alturaDisponibles = disponibles > 0 ? Math.Max(disponibles * 5, 30) : 0;
            int alturaVendidos = vendidos > 0 ? Math.Max(vendidos * 5, 10) : 0;

            g.FillRectangle(Brushes.Blue, 50, 150 - alturaDisponibles, 100, alturaDisponibles);
            g.FillRectangle(Brushes.Red, 200, 150 - alturaVendidos, 100, alturaVendidos);
            g.FillRectangle(Brushes.Blue, 50, 150 - (disponibles * 5), 100, disponibles * 5);
            g.FillRectangle(Brushes.Red, 200, 150 - (vendidos * 5), 100, vendidos * 5);
            g.DrawString("Disponibles", new System.Drawing.Font("Arial", 10), Brushes.Black, 50, 160);
            g.DrawString("Vendidos", new System.Drawing.Font("Arial", 10), Brushes.Black, 200, 160);

            bitmap.Save(rutaImagen);
            return rutaImagen;
        }

        private void GenerarReporteInventario()
        {
            try
            {
                Document documento = new Document(PageSize.A4.Rotate());
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reporte_Inventario.pdf");
                PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
                documento.Open();

                Paragraph fecha = new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"),
                    FontFactory.GetFont(FontFactory.HELVETICA, 10));
                fecha.Alignment = Element.ALIGN_RIGHT;
                documento.Add(fecha);


                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Paragraph titulo = new Paragraph("Reporte de Inventario de Vehículos", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20f;
                documento.Add(titulo);

                PdfPTable tabla = new PdfPTable(dgvInventario.Columns.Count);
                tabla.WidthPercentage = 100;


                foreach (DataGridViewColumn columna in dgvInventario.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText));
                    celda.BackgroundColor = new BaseColor(200, 200, 200);
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(celda);
                }

                foreach (DataGridViewRow fila in dgvInventario.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            tabla.AddCell(new Phrase(celda.Value?.ToString() ?? ""));
                        }
                    }
                }

                documento.Add(tabla);

                string rutaGrafico = GenerarGraficoInventario();
                Image grafico = Image.GetInstance(rutaGrafico);
                grafico.ScaleToFit(500f, 300f);
                grafico.Alignment = Element.ALIGN_CENTER;
                documento.Add(grafico);

                titulo.SpacingAfter = 10f; // Reducir espacio después del título
                grafico.SpacingBefore = 10f; // Agregar menos espacio antes del gráfico

                documento.Close();
                writer.Close();

                MessageBox.Show($"Reporte generado exitosamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            GenerarReporteInventario();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
