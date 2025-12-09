using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Entidades;
using Entidades.ModulodeSeguridad;
using Modelo;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormBackup : Form
    {
        private readonly Usuario usuarioActual;
        private readonly BackupNotifier backupNotifier = new BackupNotifier();
        private readonly string connectionString = "Server=localhost;Database=ConcesionarioDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public FormBackup(Usuario usuario)
        {
            usuarioActual = usuario;

            if (!usuario.EsAdministrador())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden realizar backups.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            InitializeComponent();
        }

        public void AgregarObservador(IBackupObserver observador)
        {
            backupNotifier.AgregarObservador(observador);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string backupDirectory = @"C:\Users\kepag\OneDrive\Escritorio\Backups";
                Directory.CreateDirectory(backupDirectory); // Crea el directorio si no existe

                string backupPath = Path.Combine(backupDirectory, $"Backup_ConcesionarioDB_{DateTime.Now:yyyyMMdd_HHmm}.bak");

                string query = $"BACKUP DATABASE ConcesionarioDB TO DISK = '{backupPath}' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup';";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Backup completado con éxito.\nUbicación: {backupPath}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var contexto = new Concesionario())
                {
                    contexto.RegistrarAuditoria(usuarioActual.NombreUsuario, "Backup realizado", $"Backup guardado en {backupPath}");
                }
                backupNotifier.NotificarBackup(backupPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Backup (*.bak)|*.bak",
                Title = "Seleccionar archivo de backup"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string backupFile = openFileDialog.FileName;

                try
                {
                    string query = $@"
                        ALTER DATABASE ConcesionarioDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE ConcesionarioDB FROM DISK = '{backupFile}' WITH REPLACE;
                        ALTER DATABASE ConcesionarioDB SET MULTI_USER;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Restauración completada con éxito.", "Restauración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public interface IBackupObserver
    {
        void NotificarBackupRealizado(string rutaBackup);
    }

    public class BackupNotifier
    {
        private readonly List<IBackupObserver> observadores = new List<IBackupObserver>();

        public void AgregarObservador(IBackupObserver observador)
        {
            observadores.Add(observador);
        }

        public void NotificarBackup(string rutaBackup)
        {
            foreach (var observador in observadores)
            {
                observador.NotificarBackupRealizado(rutaBackup);
            }
        }
    }

    public class AuditoriaBackup : IBackupObserver
    {
        public void NotificarBackupRealizado(string rutaBackup)
        {
            Console.WriteLine($"[Auditoría] Se ha realizado un backup en: {rutaBackup}");
            // Aquí podrías registrar el backup en la base de datos o en un archivo de logs.
        }
    }
}