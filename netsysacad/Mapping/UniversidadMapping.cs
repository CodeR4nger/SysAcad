using netsysacad.Models;
using Sqids;


namespace netsysacad.Mapping;

public class UniversidadDTO
{
        public required string Id { get; set; }
        public required string Nombre { get; set;}
        public required string Sigla { get; set;}
}

public class UniversidadMapper
{
    private readonly SqidsEncoder<int> _sqids;

    public UniversidadMapper(SqidsEncoder<int> sqids)
    {
        _sqids = sqids;
    }

    public UniversidadDTO ToDto(Universidad universidad)
    {
        return new UniversidadDTO
        {
            Id = _sqids.Encode(universidad.Id),
            Nombre = universidad.Nombre,
            Sigla = universidad.Sigla
        };
    }

    public int DecodeId(string encodedId) => _sqids.Decode(encodedId).FirstOrDefault();
    public Universidad FromDto(UniversidadDTO dto)
    {
        return new Universidad
        {
            Id = DecodeId(dto.Id),
            Nombre = dto.Nombre,
            Sigla = dto.Sigla
        };
    }
}