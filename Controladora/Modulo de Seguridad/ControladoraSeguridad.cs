using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Modelo;
using Entidades.ModulodeSeguridad;

namespace Controladoras
{
    public class ControladoraSeguridad
    {
        private readonly Concesionario _contexto;

        public ControladoraSeguridad(Concesionario contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto), "El contexto no puede ser nulo.");
        }

        public void CrearUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
            Console.WriteLine("Usuario creado correctamente.");
        }

        public void AsignarUsuarioAGrupo(int usuarioId, int grupoId)
        {
            var usuario = _contexto.Usuarios.Find(usuarioId);
            var grupo = _contexto.Grupos.Find(grupoId);

            if (usuario == null) throw new ArgumentException("El usuario no existe.");
            if (grupo == null) throw new ArgumentException("El grupo no existe.");

            UsuarioGrupo usuarioGrupo = new UsuarioGrupo
            {
                UsuarioId = usuarioId,
                GrupoId = grupoId
            };

            _contexto.Add(usuarioGrupo);
            _contexto.SaveChanges();
            Console.WriteLine($"Usuario {usuarioId} asignado al grupo {grupoId} correctamente.");
        }

        public void AsignarPermisoAGrupo(int grupoId, int permisoId)
        {
            var grupo = _contexto.Grupos.Find(grupoId);
            var permiso = _contexto.Permisos.Find(permisoId);

            if (grupo == null) throw new ArgumentException("El grupo no existe.");
            if (permiso == null) throw new ArgumentException("El permiso no existe.");

            GrupoPermiso grupoPermiso = new GrupoPermiso
            {
                GrupoId = grupoId,
                PermisoId = permisoId
            };

            _contexto.Add(grupoPermiso);
            _contexto.SaveChanges();
            Console.WriteLine($"Permiso {permisoId} asignado al grupo {grupoId} correctamente.");
        }

        public bool UsuarioTienePermiso(int usuarioId, int permisoId)
        {
            return _contexto.UsuarioGrupos
                .Where(ug => ug.UsuarioId == usuarioId)
                .Join(_contexto.GrupoPermisos,
                      ug => ug.GrupoId,
                      gp => gp.GrupoId,
                      (ug, gp) => gp.PermisoId)
                .Contains(permisoId);
        }

        public void EliminarUsuario(int usuarioId)
        {
            var usuario = _contexto.Usuarios.Find(usuarioId);
            if (usuario == null) throw new ArgumentException("El usuario no existe.");

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
            Console.WriteLine($"Usuario {usuarioId} eliminado correctamente.");
        }
    }
}
