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
       modelBuilder.Entity<Grado>()
           .HasMany(a => a.Alumnos);
   }
   
   public DbSet<Alumno> Alumnos { get; set; }
   public DbSet<Profesor> Profesores { get; set; }
   public DbSet<Grado> Grados { get; set; }
}