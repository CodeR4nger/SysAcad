using System.Net;
using System.Text;
using System.Text.Json;
using netsysacad.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using netsysacad.Repositories;
using netsysacad.Services;
using netsysacad.Tests.Utils;
using Microsoft.Extensions.DependencyInjection;
using netsysacad.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace netsysacad.Tests.Controllers;

public class AlumnoControllerTests
    : IClassFixture<WebApplicationFactory<Program>>,IDisposable
{
    private readonly HttpClient _client;
    private readonly AlumnoService _service;
    private readonly DatabaseContext _context;
    public readonly IDbContextTransaction _transaction;
    private readonly string uri = "/api/alumno";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public AlumnoControllerTests(WebApplicationFactory<Program> factory) : base()
    {
        _client = factory.CreateClient();

        var scope = factory.Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        _transaction = _context.Database.BeginTransaction();
        _service = new AlumnoService(new AlumnoRepository(_context));
    }
    private static void CheckEntity(Alumno alumno)
    {
        Assert.NotNull(alumno);
        Assert.Equal("Gomez", alumno.Apellido);
        Assert.Equal("Juan", alumno.Nombre);
        Assert.Equal("12345678", alumno.NroDocumento);
        Assert.Equal(TipoDocumento.DNI, alumno.TipoDocumento);
        Assert.Equal("2000-01-01", alumno.FechaNacimiento);
        Assert.Equal("M", alumno.Sexo);
        Assert.Equal(1001, alumno.NroLegajo);
        Assert.Equal(new DateTime(2020, 3, 1), alumno.FechaIngreso);
    }
    [Fact]
    public async Task CanCreateEntity()
    {
        
        Alumno alumno = TestDataFactory.CreateAlumno();
        string json = JsonSerializer.Serialize(alumno);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(uri, content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var alumnosDb = _service.SearchAll();
        Assert.Single(alumnosDb);
        CheckEntity(alumnosDb[0]);
    }
    [Fact]
    public async Task CanGetAllEntity()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var response = await _client.GetAsync(uri);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var alumnosFromApi = JsonSerializer.Deserialize<List<Alumno>>(jsonString, JsonOptions);
        Assert.NotNull(alumnosFromApi);
        var alumnoApi = alumnosFromApi?.FirstOrDefault();
        Assert.NotNull(alumnoApi);
        CheckEntity(alumnoApi);
        Assert.Equal(alumnoDb.Id, alumnoApi.Id);
    }
    [Fact]
    public async Task CanGetEntity()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var query = String.Concat(uri, "/", alumnoDb.Id);
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var alumnoApi = JsonSerializer.Deserialize<Alumno>(jsonString, JsonOptions);
        Assert.NotNull(alumnoApi);
        CheckEntity(alumnoApi);
        Assert.Equal(alumnoDb.Id, alumnoApi.Id);
    }
    [Fact]
    public async Task CanUpdateEntity()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var alumno = TestDataFactory.CreateAlumno();
        alumno.Id = alumnoDb.Id;
        alumno.Nombre = "Jose";

        var serializedAlumno = JsonSerializer.Serialize(alumno);
        var query = String.Concat(uri, "/", alumno.Id);
        var content = new StringContent(serializedAlumno, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(query,content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var updatedAlumno = _service.SearchById(alumno.Id);
        Assert.NotNull(updatedAlumno);
        Assert.Equal(alumno.Nombre,updatedAlumno.Nombre);
        Assert.Equal(alumno.Id, updatedAlumno.Id);
    }
    [Fact]
    public async Task CanDeleteEntity()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var query = String.Concat(uri, "/", alumnoDb.Id);
        var response = await _client.DeleteAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var found = _service.SearchById(alumnoDb.Id);
        Assert.Null(found);
    }
    public void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
}