
using netsysacad.Data;
using netsysacad.Models;
using netsysacad.Services;
using Microsoft.AspNetCore.Mvc;
using netsysacad.Mapping;
using Sqids;
using netsysacad.Utils;

namespace netsysacad.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController(DatabaseContext dbContext,SqidsEncoder<int> sqids) : ControllerBase
{
    private readonly AlumnoService _service = new(new Repositories.AlumnoRepository(dbContext));
    private readonly AlumnoMapper _mapper = new(sqids);
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var alumno = _service.SearchById(dbId);
        if (alumno == null)
            return NotFound();
        return Ok(_mapper.ToDto(alumno));
    }
}