
using netsysacad.Data;
using netsysacad.Services;
using Microsoft.AspNetCore.Mvc;
using netsysacad.Mapping;
using Sqids;

namespace netsysacad.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController(DatabaseContext dbContext,SqidsEncoder<int> sqids) : ControllerBase
{
    private readonly AlumnoService _service = new(new Repositories.AlumnoRepository(dbContext));
    private readonly AlumnoMapper _mapper = new(sqids);
    [HttpGet("{id}/html")]
    public IActionResult GetCertificateFromHTML(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var alumno = _service.SearchById(dbId);
        if (alumno == null)
            return NotFound();
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "certificado_pdf.html");
        var html = System.IO.File.ReadAllText(templatePath);

        html = html.Replace("{{alumno.nombre}}", alumno.Nombre)
                   .Replace("{{alumno.apellido}}", alumno.Apellido)
                   .Replace("{{alumno.tipo_documento.sigla}}",alumno.TipoDocumento.ToString())
                   .Replace("{{alumno.nrodocumento}}",alumno.NroDocumento)
                   .Replace("{{alumno.nro_legajo}}",alumno.NroLegajo.ToString());

        return File(pdf, "application/pdf", "certificado.pdf");
    }
}