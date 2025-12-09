using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Auditoria
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHora { get; set; } = DateTime.Now;

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Accion { get; set; }

        public string Detalle { get; set; }
    }
}
