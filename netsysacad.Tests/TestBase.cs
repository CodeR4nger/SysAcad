using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using netsysacad.Data;
using DotNetEnv;
namespace netsysacad.Tests;


public abstract class TestBase : IDisposable
{
    protected readonly DatabaseContext Context;
    protected readonly IDbContextTransaction Transaction;
    static TestBase()
    {
        Env.Load();
    }
    protected TestBase()
    {
        string connectionString = $"Host={Env.GetString("POSTGRES_HOST")};" +
                                    $"Username={Env.GetString("POSTGRES_USER")};" +
                                    $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                                    $"Database={Env.GetString("POSTGRES_DB")};";

        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(connectionString)
            .Options;
        Context = new DatabaseContext(options);
        Context.Database.EnsureCreated();

        Transaction = Context.Database.BeginTransaction();
    }

    public void Dispose()
    {
        Transaction.Rollback();
        Transaction.Dispose();
        Context.Dispose();
    }
}