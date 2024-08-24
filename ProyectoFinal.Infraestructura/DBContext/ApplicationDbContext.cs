using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Infraestructura.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.UsuarioAsignado)
                .WithMany()
                .HasForeignKey(s => s.UsuarioAsignadoId);
        }
    }

}
