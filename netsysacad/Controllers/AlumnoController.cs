
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
public class AlumnoController(DatabaseContext dbContext,SqidsEncoder<int> sqids) : ControllerBase
{
    private readonly AlumnoService _service = new(new Repositories.AlumnoRepository(dbContext));
    private readonly AlumnoMapper _mapper = new(sqids);

    [HttpPost]
    public IActionResult Create([FromBody] AlumnoDTO alumno)
    {
        var decodedAlumno = _mapper.FromDto(alumno);
        HtmlSanetizer.SanetizeObject(decodedAlumno);
        var dbAlumno = _service.Create(decodedAlumno);
        return Created("Alumno creado exitosamente", _mapper.ToDto(dbAlumno));
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var page = Request.Headers.TryGetValue("X-Page", out var pageStr) && int.TryParse(pageStr, out var parsedPage)
            ? parsedPage
            : -1;
        var perPage = Request.Headers.TryGetValue("X-Per-Page", out var perPageStr) && int.TryParse(perPageStr, out var parsedPerPage)
            ? parsedPerPage
            : -1;

        List<Alumno> alumnos;
        if (page > 0 && perPage > 0)
        {
            alumnos = _service.SearchPage(page,perPage);
        }
        else
        {
            alumnos = _service.SearchAll();
        }
        List<AlumnoDTO> encodedAlumnos = [.. alumnos.Select(_mapper.ToDto)];
        return Ok(encodedAlumnos);
    }
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var alumno = _service.SearchById(dbId);
        if (alumno == null)
            return NotFound();
        return Ok(_mapper.ToDto(alumno));
    }
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] AlumnoDTO updatedAlumno)
    {
        var decodedAlumno = _mapper.FromDto(updatedAlumno);
        HtmlSanetizer.SanetizeObject(decodedAlumno);
        var updated = _service.Update(decodedAlumno);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var success = _service.DeleteById(dbId);
        return Ok(success);
    }
}