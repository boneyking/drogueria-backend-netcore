using Drogueria.Core.Dominio.Entidades;
using Drogueria.Core.Infraestructura.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Drogueria.Core.Infraestructura.Contextos
{
    public class DrogueriaContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<RolUsuario> RolUsuario { get; set; }
        public DbSet<Autorizacion> Autorizacion { get; set; }
        public DbSet<InformacionPersonal> InformacionPersonal { get; set; }
        public DbSet<Arsenal> Arsenal { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Lote> Lote { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<RolUsuario>().ToTable("RolesUsuarios");
            modelBuilder.Entity<Autorizacion>().ToTable("Autorizaciones");
            modelBuilder.Entity<InformacionPersonal>().ToTable("InformacionPersonal");
            modelBuilder.Entity<Arsenal>().ToTable("Arsenales");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Articulo>().ToTable("Articulos");
            modelBuilder.Entity<Lote>().ToTable("Lotes");

            var usuarioAdministrador = CrearUsuarioAdministrador();

            modelBuilder.Entity<Usuario>().HasData(usuarioAdministrador);
            modelBuilder.Entity<Proveedor>().HasData(CrearProveedores(usuarioAdministrador));
            modelBuilder.Entity<Arsenal>().HasData(CrearArsenales(usuarioAdministrador));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("Desarrollo");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString).EnableSensitiveDataLogging(true);
            }
            
        }

        public Usuario CrearUsuarioAdministrador()
        {
            var usuario = new Usuario()
            {
                Id = Guid.NewGuid(),
                Rut = "15789559-1",
                Password = Encriptar.EncriptarTexto("123456"),
                Roles = new List<RolUsuario>(),
                InformacionPersonal = null,
                Autorizaciones = new List<Autorizacion>()
            };
            return usuario;
        }

        public List<Proveedor> CrearProveedores(Usuario responsable)
        {
            var proveedores = new List<Proveedor>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var ruta = configuration.GetSection("JsonDataInicial:Proveedores").Value;

            var jsonProveedores = File.ReadAllText(ruta);
            var objProveedores = JObject.Parse(jsonProveedores);
            foreach (var item in objProveedores["proveedores"])
            {
                var nombreProveedor = item["nombre"].ToString();
                var rutProveedor = item["rut"].ToString();

                proveedores.Add(new Proveedor
                {
                    Id = Guid.NewGuid(),
                    Nombre = nombreProveedor.Trim(),
                    Rut = rutProveedor.Replace(".", "").Replace("-",""),
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow,
                    ResponsableId = responsable.Id,
                });
            }

            return proveedores;
        }

        public List<Arsenal> CrearArsenales(Usuario responsable)
        {
            var arsenales = new List<Arsenal>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var ruta = configuration.GetSection("JsonDataInicial:Arsenales").Value;

            var jsonArsenales = File.ReadAllText(ruta);
            var objArsenales = JObject.Parse(jsonArsenales);
            foreach (var item in objArsenales["arsenales"])
            {
                var descripcionArsenal = item["nombre"].ToString();
                var arsenalTipo = Convert.ToInt32(item["arsenalTipo"].ToString());

                arsenales.Add(new Arsenal
                {
                    Id = Guid.NewGuid(),
                    Activo = true,
                    Descripcion = descripcionArsenal.Trim().Replace("�","°"),
                    ArsenalTipo = (ArsenalTipo)arsenalTipo,
                    ResponsableId = responsable.Id,
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = DateTime.UtcNow
                });
            }
            return arsenales;
        }

    }
}
