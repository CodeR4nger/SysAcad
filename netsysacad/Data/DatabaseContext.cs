using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using netsysacad.Models;

namespace netsysacad.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Autoridad> Autoridades { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Env.Load();
                string connectionString = $"Host={Env.GetString("POSTGRES_HOST")};" +
                                          $"Username={Env.GetString("POSTGRES_USER")};" +
                                          $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                                          $"Database={Env.GetString("POSTGRES_DB")};";

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
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
