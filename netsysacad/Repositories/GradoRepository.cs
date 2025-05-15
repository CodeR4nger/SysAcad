namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Grado. </summary>
public class GradoRepository : BaseRepository<Grado>
{
    public GradoRepository(DatabaseContext context) : base(context)
    {
    }
}