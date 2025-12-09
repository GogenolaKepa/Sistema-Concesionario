using System;
using System.Linq;
using System.Windows.Forms;
using Modelo;
using Entidades.ModulodeSeguridad;

namespace Vista.Modulo_de_Seguridad
{
    public partial class FormAuditoria : Form
    {
        public FormAuditoria()
        {
            InitializeComponent();
            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            using (var contexto = new Concesionario())
            {
                var auditoria = contexto.Auditorias
                    .OrderByDescending(a => a.FechaHora)
                    .Select(a => new
                    {
                        a.Usuario,
                        a.Accion,
                        a.Detalle,
                        FechaHora = a.FechaHora.ToString("yyyy-MM-dd HH:mm:ss")
                    })
                    .ToList();

                dataGridViewAuditoria.DataSource = auditoria;
            }
        }
    }
}
