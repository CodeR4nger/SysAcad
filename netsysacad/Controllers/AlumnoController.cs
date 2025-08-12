
using netsysacad.Data;
using netsysacad.Models;
using netsysacad.Services;
using Microsoft.AspNetCore.Mvc;

namespace netsysacad.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController(DatabaseContext dbContext) : ControllerBase
{
    private readonly AlumnoService _alumnoService = new(new Repositories.AlumnoRepository(dbContext));

    [HttpPost]
    public IActionResult Create([FromBody] Alumno alumno)
    {
        var dbAlumno = _alumnoService.Create(alumno);
        return Created("Alumno creado exitosamente", dbAlumno);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var alumnos = _alumnoService.SearchAll();
        return Ok(alumnos);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var alumno = _alumnoService.SearchById(id);
        return Ok(alumno);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id,[FromBody] Alumno updatedAlumno)
    {
        var updated = _alumnoService.Update(updatedAlumno);
        return Ok();
    }
}