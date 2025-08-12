using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using netsysacad.Data;

namespace netsysacad
{
    public partial class Program {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            var database = new DatabaseContextFactory().CreateDbContext([]);
            builder.Services.AddSingleton<DatabaseContext>(database);
            database.Database.EnsureCreated();
            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}