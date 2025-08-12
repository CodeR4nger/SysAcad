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
            builder.Services.AddSingleton<DatabaseContext>(new DatabaseContextFactory().CreateDbContext([]));
            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}