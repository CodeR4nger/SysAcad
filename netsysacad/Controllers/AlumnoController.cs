
using netsysacad.Data;
using netsysacad.Models;
using netsysacad.Services;
using Microsoft.AspNetCore.Mvc;

namespace netsysacad.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController : ControllerBase
{

    [HttpPost]
    public IActionResult Create([FromBody] Alumno alumno)
    {
        var service = new AlumnoService(new Repositories.AlumnoRepository(new DatabaseContextFactory().CreateDbContext([])));
        var dbAlumno = service.Create(alumno);
        return Created("Alumno creado exitosamente", dbAlumno);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var service = new AlumnoService(new Repositories.AlumnoRepository(new DatabaseContextFactory().CreateDbContext([])));
        var alumnos = service.SearchAll();
        return Ok(alumnos);
    }
}