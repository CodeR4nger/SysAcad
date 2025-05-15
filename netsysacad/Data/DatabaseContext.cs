using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using netsysacad.Models;

namespace netsysacad.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Autoridad> Autoridades { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CategoriaCargo> CategoriasCargo { get; set; }
        public DbSet<TipoDedicacion> TiposDedicacion { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
    }

        
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            Env.Load();

            string connectionString = $"Host={Env.GetString("POSTGRES_HOST")};" +
                                    $"Username={Env.GetString("POSTGRES_USER")};" +
                                    $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                                    $"Database={Env.GetString("POSTGRES_DB")};";

            optionsBuilder.UseNpgsql(connectionString);

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
