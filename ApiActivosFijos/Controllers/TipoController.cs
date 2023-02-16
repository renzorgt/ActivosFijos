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

       
    }
}
