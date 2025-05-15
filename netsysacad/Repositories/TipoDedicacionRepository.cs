namespace netsysacad.Repositories;

using netsysacad.Data;
using netsysacad.Models;

///<summary> Repositorio para la entidad TipoDedicacion. </summary>
public class TipoDedicacionRepository : BaseRepository<TipoDedicacion>
{
    public TipoDedicacionRepository(DatabaseContext context) : base(context)
    {
    }
}