using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Models;

namespace ApiActivosFijos.Repository
{
    public interface IActivoFijoRepository
    {
        Task<IEnumerable<ActivoFijoView>> GetAllActivoFijo();
        Task<IEnumerable<ActivoFijoView>> GetByFilter(SearchActivoFijo searchActivoFijo);
        Task<bool> UpdateActivoFijo(int Id ,ActivoFijo activoFijo); 
        Task<ActivoFijo> InsertActivoFijo(ActivoFijoCreate activoFijo);
    }
}
