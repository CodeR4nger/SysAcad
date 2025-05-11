using Npgsql;
using DotNetEnv;

namespace netsysacad.Tests;

public class DatabaseTests : IDisposable
{
    private readonly NpgsqlConnection _connection;
    public DatabaseTests()
    {
        Env.Load();
        string connectionString = $"Host={Env.GetString("POSTGRES_HOST")};" +
                                $"Username={Env.GetString("POSTGRES_USER")};" +
                                $"Password={Env.GetString("POSTGRES_PASSWORD")};" +
                                $"Database={Env.GetString("POSTGRES_DB")}";
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }
    public void Dispose()
    {
        _connection.Close();
        _connection.Dispose();
    }
    [Fact]
    public void TestDbConnection()
    {
        using var cmd = new NpgsqlCommand("SELECT 'Hello world';", _connection);
        var result = cmd.ExecuteScalar()?.ToString();
        Assert.Equal("Hello world", result);
    }
}