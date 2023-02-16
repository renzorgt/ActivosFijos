using ApiActivosFijos.Dtos.ActivoFijo;
using ApiActivosFijos.Models;
using ApiActivosFijos.Repository;
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
        public async Task<IActionResult> UpdateActivoFijo(int Id, [FromBody] ActivoFijo activofijo)
        {
            if (activofijo == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _activofijoRepository.UpdateActivoFijo(Id,activofijo);

            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
