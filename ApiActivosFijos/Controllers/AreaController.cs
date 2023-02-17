using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.Area;
using ApiActivosFijos.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiActivosFijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IActivoFijoRepository _activofijoRepository;

        public AreaController(IActivoFijoRepository activofijoRepository)
        {
            _activofijoRepository = activofijoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activofijoRepository.GetAllArea();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("AreaCiudad")]
        public async Task<IActionResult> GetAllAreaCiudad(int? idarea)
        {
            var result = await _activofijoRepository.GetAllAreaCiudad(idarea);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertArea([FromBody] AreaCreate areaCreate)
        {
            try
            {

                if (areaCreate == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _activofijoRepository.InsertArea(areaCreate);
                return Created("", created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AreaCiudad")]
        public async Task<IActionResult> InsertAreaCiudad([FromBody] AreaCiudadCreate areaciudadCreate)
        {
            try
            {

                if (areaciudadCreate == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _activofijoRepository.InsertAreaCiudad(areaciudadCreate);
                return Created("", created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
