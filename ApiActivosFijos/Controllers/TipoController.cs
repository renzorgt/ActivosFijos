using ApiActivosFijos.Dtos;
using ApiActivosFijos.Dtos.Tipo;
using ApiActivosFijos.Repository;
using Microsoft.AspNetCore.Mvc;


namespace ApiActivosFijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoController(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

       [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            var result = await _tipoRepository.GetAllTipo();
            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertTipo([FromBody] TipoCreate tipoCreate)
        {
            try
            {

                if (tipoCreate == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var created = await _tipoRepository.InsertTipo(tipoCreate);
                return Created("", created);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
