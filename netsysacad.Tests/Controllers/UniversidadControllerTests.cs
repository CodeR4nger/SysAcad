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

public class UniversidadControllerTests
    : IClassFixture<WebApplicationFactory<Program>>,IDisposable
{
    private readonly HttpClient _client;
    private readonly UniversidadService _service;
    private readonly DatabaseContext _context;
    private readonly UniversidadMapper _mapper;
    public readonly IDbContextTransaction _transaction;
    private readonly string uri = "/api/universidad";

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };


    public UniversidadControllerTests(WebApplicationFactory<Program> factory) : base()
    {
        _client = factory.CreateClient();

        var scope = factory.Services.CreateScope();
        _context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        _transaction = _context.Database.BeginTransaction();
        _service = new UniversidadService(new UniversidadRepository(_context));
        var envHandler = new EnvironmentHandler();
        var encoder = new SqidsEncoder<int>(new SqidsOptions
        {
            Alphabet = envHandler.Get("SQID_ALPHABET"),
            MinLength = int.Parse(envHandler.Get("SQID_MIN_LENGTH"))
        });
        _mapper = new UniversidadMapper(encoder);

    }
    private static void CheckEntity(Universidad universidad)
    {
            Assert.NotNull(universidad);
            Assert.Equal("UTN",universidad.Nombre);
            Assert.Equal("FRSR",universidad.Sigla);
    }
    [Fact]
    public async Task CanCreateEntity()
    {
        
        Universidad universidad = TestDataFactory.CreateUniversidad();

        string json = JsonSerializer.Serialize(_mapper.ToDto(universidad));
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(uri, content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var universidadDb = _service.SearchAll();
        Assert.Single(universidadDb);
        CheckEntity(universidadDb[0]);
    }
    [Fact]
    public async Task CanGetAllEntity()
    {
        var universidadDb = _service.Create(TestDataFactory.CreateUniversidad());
        var response = await _client.GetAsync(uri);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var universidadesFromApi = JsonSerializer.Deserialize<List<UniversidadDTO>>(jsonString, JsonOptions);
        Assert.NotNull(universidadesFromApi);
        var universidadApi = universidadesFromApi?.FirstOrDefault();
        Assert.NotNull(universidadApi);
        CheckEntity(_mapper.FromDto(universidadApi));
        Assert.Equal(universidadDb.Id, _mapper.DecodeId(universidadApi.Id));
    }
    [Fact]
    public async Task CanGetAllPaginatedEntity()
    {
        var universidadDb = _service.Create(TestDataFactory.CreateUniversidad());
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.Headers.Add("X-Page", "1");
        request.Headers.Add("X-Per-Page", "30");
        var response = await _client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var universidadesFromApi = JsonSerializer.Deserialize<List<UniversidadDTO>>(jsonString, JsonOptions);
        Assert.NotNull(universidadesFromApi);
        var universidadApi = universidadesFromApi?.FirstOrDefault();
        Assert.NotNull(universidadApi);
        CheckEntity(_mapper.FromDto(universidadApi));
        Assert.Equal(universidadDb.Id, _mapper.DecodeId(universidadApi.Id));
    }
    [Fact]
    public async Task CanGetFilteredEntity()
    {
        var universidadToFind = TestDataFactory.CreateUniversidad();
        var extraUniversidad = TestDataFactory.CreateUniversidad();
        extraUniversidad.Nombre = "Test";
        var universidadDb = _service.Create(universidadToFind);
       _service.Create(extraUniversidad);
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.Headers.Add("X-Filter", $@"[{{""field"":""Nombre"", ""op"":""=="", ""value"":""{universidadDb.Nombre}""}}]");
        var response = await _client.SendAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var universidadesFromApi = JsonSerializer.Deserialize<List<UniversidadDTO>>(jsonString, JsonOptions);
        Assert.NotNull(universidadesFromApi);
        Assert.Single(universidadesFromApi);
        var universidadApi = universidadesFromApi?.FirstOrDefault();
        Assert.NotNull(universidadApi);
        CheckEntity(_mapper.FromDto(universidadApi));
        Assert.DoesNotMatch(extraUniversidad.Nombre, universidadApi.Nombre);
        Assert.Equal(universidadDb.Nombre, universidadApi.Nombre);
    }
    [Fact]
    public async Task CanGetEntity()
    {
        var universidadDb = _service.Create(TestDataFactory.CreateUniversidad());
        var encodedUniversidad = _mapper.ToDto(universidadDb);
        var query = String.Concat(uri, "/", encodedUniversidad.Id);
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var jsonString = await response.Content.ReadAsStringAsync();
        var universidadApi = JsonSerializer.Deserialize<UniversidadDTO>(jsonString, JsonOptions);
        Assert.NotNull(universidadApi);
        var decodedUniversidad = _mapper.FromDto(universidadApi);
        CheckEntity(decodedUniversidad);
        Assert.Equal(universidadDb.Id, decodedUniversidad.Id);
    }
    [Fact]
    public async Task CanUpdateEntity()
    {
        var universidadDb = _service.Create(TestDataFactory.CreateUniversidad());
        var universidad = TestDataFactory.CreateUniversidad();
        universidad.Id = universidadDb.Id;
        universidad.Nombre = "Jose";
        var encodedUniversidad = _mapper.ToDto(universidad);
        var query = String.Concat(uri, "/", encodedUniversidad.Id);
        var serializedUniversidad = JsonSerializer.Serialize(encodedUniversidad);
        var content = new StringContent(serializedUniversidad, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(query,content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var updatedUniversidad = _service.SearchById(universidad.Id);
        Assert.NotNull(updatedUniversidad);
        Assert.Equal(universidad.Nombre,updatedUniversidad.Nombre);
        Assert.Equal(universidad.Id, updatedUniversidad.Id);
    }
    [Fact]
    public async Task CanDeleteEntity()
    {
        var universidadDb = _service.Create(TestDataFactory.CreateUniversidad());
        var encodedUniversidad = _mapper.ToDto(universidadDb);
        var query = String.Concat(uri, "/", encodedUniversidad.Id);
        var response = await _client.DeleteAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var found = _service.SearchById(universidadDb.Id);
        Assert.Null(found);
    }
    public void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
}