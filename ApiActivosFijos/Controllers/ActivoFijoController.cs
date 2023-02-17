using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Dtos.Estado;
using ApiActivosFijos.Models;
using ApiActivosFijos.Repository;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;



namespace ApiActivosFijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoFijoController : ControllerBase
    {
        private readonly IActivoFijoRepository _activofijoRepository;

        public ActivoFijoController(IActivoFijoRepository activofijoRepository)
        {
            _activofijoRepository = activofijoRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllGetAllActivoFijo()
        {
            var result = await _activofijoRepository.GetAllActivoFijo();

            if (result.Count() == 0)
            {
            return  NotFound();
            }

            return Ok(result);
        }

        [HttpGet()]
       public async Task<IActionResult> GetByFilter([FromQuery] SearchActivoFijo searchActivoFijo)
        {
            var result = await _activofijoRepository.GetByFilter(searchActivoFijo);
           if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
            ;
        }

        [HttpPost]
        public async Task<IActionResult> InsertActivoFijo([FromBody] ActivoFijoCreate activofijo)
        {
            try
            {

                if (activofijo == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _activofijoRepository.InsertActivoFijo(activofijo);
                return Created("", created);

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        
        public async Task<IActionResult> UpdateActivoFijo(int Id, [FromBody] ActivoFijoUpdate activofijo)
        {
            if (activofijo == null)
            {
                return BadRequest(new ApiResponse("Modelo no corresponde al requerido", 400));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse("Modelo no corresponde al requerido", ModelState, 400));
            }
            if (Id == null || Id == 0)
            {
                return BadRequest(new ApiResponse("La variable ID no se a establecido", Id, 400));
            }
            if (activofijo.fecha_baja == null)
            {
                return BadRequest(new ApiResponse("La variable ID no se a fecha_baja", Id, 400));
            }
            if (activofijo.serial == null)
            {
                return BadRequest(new ApiResponse("La variable ID no se a fecha_baja", Id, 400));
            }

            var created = await _activofijoRepository.UpdateActivoFijo(Id,activofijo);

            return NoContent();
        }

        [HttpPost("Estados")]
        public async Task<IActionResult> InsertEstado([FromBody] EstadoCreate estadoCreate)
        {
            try
            {

                if (estadoCreate == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _activofijoRepository.InsertEstado(estadoCreate);
                return Created("", created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Estados")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activofijoRepository.GetAllEstado();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
