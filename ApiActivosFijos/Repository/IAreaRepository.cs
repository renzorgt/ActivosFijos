using ApiActivosFijos.Models;

namespace ApiActivosFijos.Repository
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllArea();
        Task<Area> GetById(int id);
        Task<bool> UpdateArea(int Id ,Area Area); 
        Task<bool> InsertArea(Area Area);
    }
}
