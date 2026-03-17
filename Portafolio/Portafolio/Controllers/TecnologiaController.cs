using Microsoft.AspNetCore.Mvc;
using Portafolio.Repositorie.Interfaces;
using Portafolio.Model;
using Portafolio.Repositorie;

namespace Portafolio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TecnologiaController : Controller
    {
        private readonly ITecnologia _Tecnologia;

        public TecnologiaController(ITecnologia tecnologia)
        {
            _Tecnologia = tecnologia;
        }

        [HttpGet("GetTecnologia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTecnologia()
        {
            var data = await _Tecnologia.GetTecnologia();
            return Ok(data);
        }

        [HttpPost("PostTecnologia")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostTecnologia(Tecnologia tec)
        {
            try
            {
                var res = await _Tecnologia.PostTecnologia(tec);
                return Ok("Tecnologia agregado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("PutTecnologia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTecnologia(Tecnologia tec)
        {
            try
            {
                var res = await _Tecnologia.PutTecnologia(tec);
                return Ok("Tecnologia Actualizada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("DeleteTecnologia/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTecnologia(int id)
        {
            try
            {
                var res = await _Tecnologia.DeleteTecnologia(id);
                return Ok("Tecnologia fue eliminada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
