using netsysacad.Models;
using Sqids;


namespace netsysacad.Mapping;

public class AlumnoDTO
{
    public required string Id { get; set; }
    public required string Apellido { get; set; }
    public required string Nombre { get; set; }
    public required string NroDocumento { get; set; }
    public required TipoDocumento TipoDocumento { get; set; }
    public required string FechaNacimiento { get; set; }
    public required string Sexo { get; set; }
    public required int NroLegajo { get; set; }
    public required DateTime FechaIngreso { get; set; }
}

public class AlumnoMapper
{
    private readonly SqidsEncoder<int> _sqids;

    public AlumnoMapper(SqidsEncoder<int> sqids)
    {
        _sqids = sqids;
    }

    public AlumnoDTO ToDto(Alumno alumno)
    {
        return new AlumnoDTO
        {
            Id = _sqids.Encode(alumno.Id),
            Nombre = alumno.Nombre,
            Apellido = alumno.Apellido,
            NroDocumento = alumno.NroDocumento,
            TipoDocumento = alumno.TipoDocumento,
            FechaNacimiento = alumno.FechaNacimiento,
            Sexo = alumno.Sexo,
            NroLegajo = alumno.NroLegajo,
            FechaIngreso = alumno.FechaIngreso
        };
    }

    public int DecodeId(string encodedId) => _sqids.Decode(encodedId).FirstOrDefault();
    public Alumno FromDto(AlumnoDTO dto)
    {
        return new Alumno
        {
            Id = DecodeId(dto.Id),
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            NroDocumento = dto.NroDocumento,
            TipoDocumento = dto.TipoDocumento,
            FechaNacimiento = dto.FechaNacimiento,
            Sexo = dto.Sexo,
            NroLegajo = dto.NroLegajo,
            FechaIngreso = dto.FechaIngreso
        };
    }
}