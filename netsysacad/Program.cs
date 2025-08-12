using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using netsysacad.Data;
using netsysacad.Utils;
using Sqids;

namespace netsysacad
{
    public partial class Program {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            var database = new DatabaseContextFactory().CreateDbContext([]);
            builder.Services.AddSingleton<DatabaseContext>(database);
            var envHandler = new EnvironmentHandler();
            builder.Services.AddSingleton(_ => new SqidsEncoder<int>(new SqidsOptions
            {
                Alphabet = envHandler.Get("SQID_ALPHABET"),
                MinLength = int.Parse(envHandler.Get("SQID_MIN_LENGTH"))
            }));
            database.Database.EnsureCreated();
            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}