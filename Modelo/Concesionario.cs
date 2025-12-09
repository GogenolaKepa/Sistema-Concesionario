using Microsoft.EntityFrameworkCore;
using Entidades;
using Entidades.ModulodeSeguridad;
using BCrypt.Net;
using System.Linq;

namespace Modelo
{
    public class Concesionario : DbContext
    {
        public Concesionario() { }
        public Concesionario(DbContextOptions<Concesionario> options) : base(options) { }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<EstadoOrdenCompra> EstadosOrdenCompra { get; set; }
        public DbSet<Financiamiento> Financiamientos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public DbSet<GrupoPermiso> GrupoPermisos { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }

        private static Concesionario instancia;
        public static Concesionario Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Concesionario();
                return instancia;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ConcesionarioDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioGrupo>().HasKey(ug => new { ug.UsuarioId, ug.GrupoId });
            modelBuilder.Entity<GrupoPermiso>().HasKey(gp => new { gp.GrupoId, gp.PermisoId });
            modelBuilder.Entity<Auditoria>().ToTable("Auditoria");

            modelBuilder.Entity<Grupo>().HasData(new Grupo
            {
                GrupoId = 1,
                NombreGrupo = "Administrador"
            });
            modelBuilder.Entity<OrdenCompra>()
                .HasOne(o => o.Proveedor)
                .WithMany()
                .HasForeignKey(o => o.ProveedorId);

            modelBuilder.Entity<OrdenCompra>()
                .HasOne(o => o.EstadoOrdenCompra)
                .WithMany()
                .HasForeignKey(o => o.EstadoOrdenCompraId);
            modelBuilder.Entity<DetallePedido>()
                .HasOne<Pedido>()
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey("PedidoId")
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Vehiculo)
                .WithMany()  // 🔹 Cambiado a WithMany para evitar duplicados
                .HasForeignKey(dp => dp.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict); // 🔥 NO en cascada
         
            modelBuilder.Entity<DetalleCompra>()
              .HasOne(dp => dp.Vehiculo)
              .WithMany()  // 🔹 Cambiado a WithMany para evitar duplicados
              .HasForeignKey(dp => dp.VehiculoId)
              .OnDelete(DeleteBehavior.Restrict); // 🔥 NO en cascada
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey(dp => dp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade); // Configurar eliminación en cascada si aplica



            modelBuilder.Entity<DetalleCompra>().Property(d => d.PrecioUnitario).HasPrecision(18, 2);
            modelBuilder.Entity<DetallePedido>().Property(d => d.PrecioUnitario).HasPrecision(18, 2);
            modelBuilder.Entity<OrdenCompra>().Property(o => o.MontoTotal).HasPrecision(18, 2);
            modelBuilder.Entity<Vehiculo>().Property(v => v.Precio).HasPrecision(18, 2);
            modelBuilder.Entity<OrdenCompra>().ToTable("OrdenesCompra");
            modelBuilder.Entity<EstadoOrdenCompra>().HasData(
            new EstadoOrdenCompra { EstadoOrdenCompraId = 1, EstadoActual = "Pendiente" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 2, EstadoActual = "Confirmado" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 3, EstadoActual = "Cancelado" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 4, EstadoActual = "Por Entregar" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 5, EstadoActual = "Entregado" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 6, EstadoActual = "Entregado con Faltante" },
            new EstadoOrdenCompra { EstadoOrdenCompraId = 7, EstadoActual = "Parcialmente Entregado" }
             );


            base.OnModelCreating(modelBuilder);
        }
        public void AsegurarUsuarioAdmin()
        {
            var usuarioExistente = Usuarios.FirstOrDefault(u => u.NombreUsuario == "Pedro");

            if (usuarioExistente == null)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword("pedrogogenola");

                var usuarioAdmin = new Usuario
                {
                    NombreUsuario = "Pedro",
                    CargoUsuario = "Dueño",
                    ContrasenaUsuario = hashedPassword
                };

                Usuarios.Add(usuarioAdmin);
                SaveChanges();
            }
            else
            {
                if (!usuarioExistente.ContrasenaUsuario.StartsWith("$2a$"))
                {
                    usuarioExistente.ContrasenaUsuario = BCrypt.Net.BCrypt.HashPassword("pedrogogenola");
                    SaveChanges();
                }
            }

            var grupoAdmin = Grupos.FirstOrDefault(g => g.GrupoId == 1);
            if (grupoAdmin == null)
            {
                grupoAdmin = new Grupo { GrupoId = 1, NombreGrupo = "Administrador" };
                Grupos.Add(grupoAdmin);
                SaveChanges();
            }

            var usuarioId = Usuarios.FirstOrDefault(u => u.NombreUsuario == "Pedro")?.UsuarioId;
            if (usuarioId != null)
            {
                var relacionExistente = UsuarioGrupos.FirstOrDefault(ug => ug.UsuarioId == usuarioId && ug.GrupoId == 1);
                if (relacionExistente == null)
                {
                    UsuarioGrupos.Add(new UsuarioGrupo
                    {
                        UsuarioId = usuarioId.Value,
                        GrupoId = 1
                    });
                    SaveChanges();
                }
            }
        }
        public void RegistrarAuditoria(string usuario, string accion, string detalle = null)
        {
            var registro = new Auditoria
            {
                Usuario = usuario,
                Accion = accion,
                Detalle = detalle
            };

            Auditorias.Add(registro);
            SaveChanges();
        }
        public void AsegurarUsuarioSubgerente()
        {
            using (var contexto = new Concesionario())
            {
                var grupoSubgerente = contexto.Grupos.FirstOrDefault(g => g.NombreGrupo == "Subgerente de Ventas");
                if (grupoSubgerente == null)
                {
                    grupoSubgerente = new Grupo { NombreGrupo = "Subgerente de Ventas" };
                    contexto.Grupos.Add(grupoSubgerente);
                    contexto.SaveChanges();
                }

                var usuarioExistente = contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == "Milton");
                if (usuarioExistente == null)
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword("milton123");

                    var usuarioSubgerente = new Usuario
                    {
                        NombreUsuario = "Milton",
                        CargoUsuario = "Subgerente de Ventas",
                        ContrasenaUsuario = hashedPassword
                    };

                    contexto.Usuarios.Add(usuarioSubgerente);
                    contexto.SaveChanges();

                    int usuarioId = usuarioSubgerente.UsuarioId;

                    contexto.UsuarioGrupos.Add(new UsuarioGrupo
                    {
                        UsuarioId = usuarioId,
                        GrupoId = grupoSubgerente.GrupoId
                    });
                    contexto.SaveChanges();
                }
            }
        }

    }
}