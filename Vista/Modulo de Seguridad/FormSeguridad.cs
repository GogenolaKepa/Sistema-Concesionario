using System;
using System.Windows.Forms;
using Entidades.ModulodeSeguridad;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormSeguridad : Form
    {
        private readonly Usuario usuarioActual;
        private System.Windows.Forms.Button btnAuditoria;

        public FormSeguridad(Usuario usuario)
        {
            if (usuario == null || !usuario.EsAdministrador())
            {
                MessageBox.Show("Acceso denegado. Solo los administradores pueden acceder.",
                                "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            usuarioActual = usuario;
            InitializeComponent();  // Se ejecuta solo si el usuario es válido
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormGestionUsuarios(usuarioActual));
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FormGestionPermisos(usuarioActual));
        }

        private void btnGestionGrupos_Click(object sender, EventArgs e)
        {
            using (FormGestionGrupos formGrupos = new FormGestionGrupos())
            {
                formGrupos.ShowDialog();
            }
        }

        /// <summary>
        /// 🔹 Método para abrir formularios con manejo de excepciones.
        /// </summary>
        private void AbrirFormulario(Func<Form> crearFormulario)
        {
            try
            {
                using (Form form = crearFormulario())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FormBackup formBackup = new FormBackup(usuarioActual);
            formBackup.AgregarObservador(new AuditoriaBackup());

            formBackup.ShowDialog();
        }
        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            FormAuditoria formAuditoria = new FormAuditoria();
            formAuditoria.ShowDialog();
        }

    }
}
