
using Microsoft.EntityFrameworkCore;
using App.Dominio.Entities;

namespace App.Infraestructura.Context
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Calificaciones>().ToTable("Calificaciones");
            modelBuilder.Entity<Profesores>().ToTable("Profesores");
        }
    }
}
