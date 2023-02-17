using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Dtos.Area;
using ApiActivosFijos.Dtos.Estado;
using ApiActivosFijos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiActivosFijos.Repository
{
    public interface IActivoFijoRepository
    {
        Task<IEnumerable<ActivoFijoView>> GetAllActivoFijo();
        Task<IEnumerable<ActivoFijoView>> GetByFilter(SearchActivoFijo searchActivoFijo);
        Task<bool> UpdateActivoFijo(int Id , ActivoFijoUpdate activoFijo); 
        Task<ActivoFijo> InsertActivoFijo(ActivoFijoCreate activoFijo);
        Task<IEnumerable<Area>> GetAllArea();

        Task<IEnumerable<Persona>> GetAllPersona();

        Task<IEnumerable<Ciudad>> GetAllCiudad();

        Task<IEnumerable<Estado>> GetAllEstado();

        Task<IEnumerable<AreaCiudadView>> GetAllAreaCiudad(int? idarea);

        Task<Ciudad> InsertCiudad(CiudadCreate ciudadCreate);

        Task<Area> InsertArea(AreaCreate areaCreate);

        Task<Persona> InsertPersona(PersonaCreate personaCreate);

        Task<Estado> InsertEstado(EstadoCreate estadoCreate);

        Task<AreaCiudadView> InsertAreaCiudad(AreaCiudadCreate areaciudadCreate);

    }
}
