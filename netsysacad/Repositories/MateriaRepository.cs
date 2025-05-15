namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad Materia. </summary>
public class MateriaRepository : BaseRepository<Materia>
{
    public MateriaRepository(DatabaseContext context) : base(context)
    {
    }
}