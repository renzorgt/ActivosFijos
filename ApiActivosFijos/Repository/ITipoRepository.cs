using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.Tipo;
using ApiActivosFijos.Models;

namespace ApiActivosFijos.Repository
{
    public interface ITipoRepository
    {
        Task<IEnumerable<TipoView>> GetAllTipo();
        Task<IEnumerable<TipoView>> GetByFilterTipo(TipoSearch tipoSearch);

        Task<Tipo> InsertTipo(TipoCreate tipoCreate);



    }
}
