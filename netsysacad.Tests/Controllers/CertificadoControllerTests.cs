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
using Sqids;
using netsysacad.Utils;
using netsysacad.Mapping;

namespace netsysacad.Tests.Controllers;

public class CertificadoControllerTests
    : IClassFixture<WebApplicationFactory<Program>>,IDisposable
{
    private readonly HttpClient _client;
    private readonly AlumnoService _service;
    private readonly DatabaseContext _context;
    private readonly AlumnoMapper _mapper;
    public readonly IDbContextTransaction _transaction;
    private readonly string uri = "/api/alumno";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public CertificadoControllerTests(WebApplicationFactory<Program> factory) : base()
    {
        _client = factory.CreateClient();

        var scope = factory.Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        _transaction = _context.Database.BeginTransaction();
        _service = new AlumnoService(new AlumnoRepository(_context));
        var envHandler = new EnvironmentHandler();
        var encoder = new SqidsEncoder<int>(new SqidsOptions
        {
            Alphabet = envHandler.Get("SQID_ALPHABET"),
            MinLength = int.Parse(envHandler.Get("SQID_MIN_LENGTH"))
        });
        _mapper = new AlumnoMapper(encoder);

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
    public async Task CanGetPDFFromHTMLCertification()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var encodedAlumno = _mapper.ToDto(alumnoDb);
        var query = $@"{uri}/{encodedAlumno.Id}/html";
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var alumnoApi = JsonSerializer.Deserialize<AlumnoDTO>(jsonString, JsonOptions);
        Assert.NotNull(alumnoApi);
        var decodedAlumno = _mapper.FromDto(alumnoApi);
        CheckEntity(decodedAlumno);
        Assert.Equal(alumnoDb.Id, decodedAlumno.Id);
    }
    [Fact]
    public async Task CanGetPDFFromDocCertification()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var encodedAlumno = _mapper.ToDto(alumnoDb);
        var query = $@"{uri}/{encodedAlumno.Id}/doc";
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var alumnoApi = JsonSerializer.Deserialize<AlumnoDTO>(jsonString, JsonOptions);
        Assert.NotNull(alumnoApi);
        var decodedAlumno = _mapper.FromDto(alumnoApi);
        CheckEntity(decodedAlumno);
        Assert.Equal(alumnoDb.Id, decodedAlumno.Id);
    }
    [Fact]
    public async Task CanGetPDFFromOdtCertification()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var encodedAlumno = _mapper.ToDto(alumnoDb);
        var query = $@"{uri}/{encodedAlumno.Id}/odt";
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var alumnoApi = JsonSerializer.Deserialize<AlumnoDTO>(jsonString, JsonOptions);
        Assert.NotNull(alumnoApi);
        var decodedAlumno = _mapper.FromDto(alumnoApi);
        CheckEntity(decodedAlumno);
        Assert.Equal(alumnoDb.Id, decodedAlumno.Id);
    }
    public void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
}