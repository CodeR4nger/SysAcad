using System.Net;
using UglyToad.PdfPig;
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
using System.Text;

namespace netsysacad.Tests.Controllers;

public class CertificadoControllerTests
    : IClassFixture<WebApplicationFactory<Program>>,IDisposable
{
    private readonly HttpClient _client;
    private readonly AlumnoService _service;
    private readonly DatabaseContext _context;
    private readonly AlumnoMapper _mapper;
    public readonly IDbContextTransaction _transaction;
    private readonly string uri = "/api/certificado";

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
    [Fact]
    public async Task CanGetPDFFromHTMLCertification()
    {
        var alumnoDb = _service.Create(TestDataFactory.CreateAlumno());
        var encodedAlumno = _mapper.ToDto(alumnoDb);
        var query = $@"{uri}/{encodedAlumno.Id}/html";
        var response = await _client.GetAsync(query);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response.Content.Headers.ContentType);
        Assert.Equal("application/pdf", response.Content.Headers.ContentType.MediaType);

        var content = await response.Content.ReadAsByteArrayAsync();
        Assert.NotNull(content);
        Assert.True(content.Length > 0);

        using var pdfStream = new MemoryStream(content);
        using var document = PdfDocument.Open(pdfStream);
        var pdfText = new StringBuilder();
        foreach (var page in document.GetPages())
        {
            pdfText.AppendLine(page.Text);
        }

        var fullText = pdfText.ToString();

        Assert.Contains(alumnoDb.Nombre, fullText);
        Assert.Contains(alumnoDb.Apellido, fullText);
        Assert.Contains(alumnoDb.NroDocumento, fullText);
        Assert.Contains(alumnoDb.NroLegajo.ToString(), fullText);
    }
    public void Dispose()
    {
        _transaction.Rollback();
        _transaction.Dispose();
    }
}