
using netsysacad.Data;
using netsysacad.Models;
using netsysacad.Services;
using Microsoft.AspNetCore.Mvc;
using netsysacad.Mapping;
using Sqids;
using netsysacad.Utils;
using System.Text.Json;

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
        int? page;
        if (Request.Headers.TryGetValue("X-Page", out var pageStr) && int.TryParse(pageStr, out var parsedPage) && parsedPage > 0)
        {
            page = parsedPage;
        }
        else
        {
            page = null;
        }
        int? perPage;
        if (Request.Headers.TryGetValue("X-Page", out var perPageStr) && int.TryParse(perPageStr, out var parsedPerPage) && parsedPerPage > 0)
        {
            perPage = parsedPerPage;
        }
        else
        {
            perPage = null;
        }
        string? serializedFilters;
        if (Request.Headers.TryGetValue("X-Filter", out var filterStr))
        {
            serializedFilters = filterStr.ToString();
        }
        else
        {
            serializedFilters = null;
        }
        List<ApiFilter>? filters = ApiFilterMapper.DecodeFilter(serializedFilters);
        List<Alumno> alumnos;
        if ((page.HasValue && perPage.HasValue) || (filters != null && filters.Count != 0))
        {
            alumnos = _service.SearchPage(page,perPage,filters);
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
    [HttpGet("{id}/pdf")]
    public IActionResult GetPDF(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var alumno = _service.SearchById(dbId);
        if (alumno == null)
            return NotFound();
        var alumnoDTO = _mapper.ToDto(alumno);
        var file = HtmlConverter.ConvertHtmlToPdf(_mapper.ToHTMLTable(alumno));
        return File(file, "application/pdf", $@"{alumnoDTO.Id}.pdf");
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