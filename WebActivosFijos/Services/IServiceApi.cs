using System.Collections.Generic;
using WebActivosFijos.Dtos;
using WebActivosFijos.Models;

namespace WebActivosFijos.Services
{
    public interface IServiceApi
    {
        Task<List<ActivoFijo>> GetAll();

        Task<ActivoFijo> Get(int id);

        Task<List<ActivoFijo>> Insert(ActivoFijoInsert activoFijoInsert);

        Task<bool> Update(int Id, ActivoFijoPut activoFijoPut);
    }
}
