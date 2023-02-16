using ApiActivosFijos.Dtos.Tipo;
using ApiActivosFijos.Models;

namespace ApiActivosFijos.Repository
{
    public interface ITipoRepository
    {
        Task<IEnumerable<TipoView>> GetAllTipo();
        Task<IEnumerable<TipoView>> GetByFilterTipo(TipoSearch tipoSearch);
       // Task<bool> UpdateTipo(int Id, ActivoFijo activoFijo);
        //Task<ActivoFijo> InsertTipo(ActivoFijoCreate activoFijo);

    }
}
