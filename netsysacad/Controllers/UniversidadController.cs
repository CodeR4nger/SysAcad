
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
public class UniversidadController(DatabaseContext dbContext,SqidsEncoder<int> sqids) : ControllerBase
{
    private readonly UniversidadService _service = new(new Repositories.UniversidadRepository(dbContext));
    private readonly UniversidadMapper _mapper = new(sqids);

    [HttpPost]
    public IActionResult Create([FromBody] UniversidadDTO universidad)
    {
        var decodedUniversidad = _mapper.FromDto(universidad);
        HtmlSanetizer.SanetizeObject(decodedUniversidad);
        var dbUniversidad = _service.Create(decodedUniversidad);
        return Created("Universidad creado exitosamente", _mapper.ToDto(dbUniversidad));
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        int? page = Request.Headers.TryGetValue("X-Page", out var pageStr) && int.TryParse(pageStr, out var parsedPage) && parsedPage > 0
            ? parsedPage
            : null;
        int? perPage = Request.Headers.TryGetValue("X-Per-Page", out var perPageStr) && int.TryParse(perPageStr, out var parsedPerPage) && parsedPerPage > 0
            ? parsedPerPage
            : null;
        string? serializedFilters = Request.Headers.TryGetValue("X-Filter", out var filterStr)
            ? filterStr.ToString() 
            : null;
        List<ApiFilter>? filters = ApiFilterMapper.DecodeFilter(serializedFilters);
        List<Universidad> universidades;
        if ((page.HasValue && perPage.HasValue) || (filters != null && filters.Count != 0))
        {
            universidades = _service.SearchPage(page,perPage,filters);
        }
        else
        {
            universidades = _service.SearchAll();
        }
        List<UniversidadDTO> encodedUniversidades = [.. universidades.Select(_mapper.ToDto)];
        return Ok(encodedUniversidades);
    }
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var dbId = _mapper.DecodeId(id);
        var universidad = _service.SearchById(dbId);
        if (universidad == null)
            return NotFound();
        return Ok(_mapper.ToDto(universidad));
    }
    [HttpPut("{id}")]
    public IActionResult Put(string id, [FromBody] UniversidadDTO updatedUniversidad)
    {
        var decodedUniversidad = _mapper.FromDto(updatedUniversidad);
        HtmlSanetizer.SanetizeObject(decodedUniversidad);
        var updated = _service.Update(decodedUniversidad);
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