using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api;

public class ColegioContext(IConfiguration configuration) : DbContext
{
   protected readonly IConfiguration Configuration = configuration;

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlite(configuration.GetConnectionString("WebApiDatabase"));
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.Entity<Grado>().HasKey(x => x.Id);
       modelBuilder.Entity<Alumno>().HasKey(x => x.Id);
       modelBuilder.Entity<Profesor>().HasKey(x => x.Id);
       modelBuilder.Entity<Grado>()
           .HasMany(g => g.Alumnos)
           .WithMany(a => a.Grados)
           .UsingEntity(t => t.ToTable("AlumnoGrado"));
       modelBuilder.Entity<Grado>()
           .HasOne(p => p.Profesor)
           .WithOne(gp => gp.Grado);
   }
   
   public DbSet<Alumno> Alumnos { get; set; }
   public DbSet<Profesor> Profesores { get; set; }
   public DbSet<Grado> Grados { get; set; }
}