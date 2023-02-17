using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiActivosFijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly IActivoFijoRepository _activofijoRepository;

        public CiudadController(IActivoFijoRepository activofijoRepository)
        {
            _activofijoRepository = activofijoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activofijoRepository.GetAllCiudad();

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> InsertCiudad([FromBody] CiudadCreate ciudadCreate)
        {
            try
            {

                if (ciudadCreate == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _activofijoRepository.InsertCiudad(ciudadCreate);
                return Created("", created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
