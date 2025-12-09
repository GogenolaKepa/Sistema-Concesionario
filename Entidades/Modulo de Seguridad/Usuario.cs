using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BCrypt.Net;

namespace Entidades.ModulodeSeguridad
{
    public class Usuario
    {
        private int usuarioId;
        private string nombreUsuario = string.Empty;
        private string cargoUsuario = string.Empty;
        private string contrasenaUsuario = string.Empty;
        private List<UsuarioGrupo> grupos = new List<UsuarioGrupo>();


        [Key]
        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string NombreUsuario
        {
            get => nombreUsuario;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre de usuario no puede estar vacío.");
                }
                nombreUsuario = value;
            }
        }


        [Required(ErrorMessage = "El cargo es obligatorio.")]
        public string CargoUsuario
        {
            get { return cargoUsuario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El cargo no puede estar vacío.");
                cargoUsuario = value;
            }
        }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string ContrasenaUsuario
        {
            get { return contrasenaUsuario; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                    throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");

                // ⚠️ Solo hasheamos si no está hasheada (BCrypt siempre comienza con "$2a$")
                if (!value.StartsWith("$2a$"))
                {
                    contrasenaUsuario = BCrypt.Net.BCrypt.HashPassword(value);
                }
                else
                {
                    contrasenaUsuario = value;
                }
            }
        }

        public List<UsuarioGrupo> Grupos
        {
            get { return grupos ?? new List<UsuarioGrupo>(); } 
            set { grupos = value ?? new List<UsuarioGrupo>(); }
        }

        public bool VerificarContraseña(string contraseñaIngresada)
        {
            return BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contrasenaUsuario);
        }
     
        public bool TieneGrupo(string nombreGrupo)
        {
            return Grupos.Any(g => g.Grupo.NombreGrupo == nombreGrupo);
        }

        public bool EsAdministrador()
        {
            return Grupos.Any(g => g.GrupoId == 1); // ✅ Comprueba si tiene GrupoId 1
        }

        public bool EsSubgerenteVentas()
        {
            return Grupos.Any(g => g.GrupoId == 2); // ✅ Asegúrate que 2 es el ID de Subgerente de Ventas
        }
        public bool EsGerenteVentas()
        {
            return Grupos.Any(g => g.GrupoId == 3); // ✅ Asegúrate que 2 es el ID de Subgerente de Ventas
        }
        public bool esEmpleadoNuevo()
        {
            return Grupos.Any(g => g.GrupoId == 5); // ✅ Asegúrate que 2 es el ID de Subgerente de Ventas
        }
    }
}
