using Microsoft.AspNetCore.Mvc;
using Portafolio.Model;
using Portafolio.Repositorie;
using Portafolio.Repositorie.Interfaces;

namespace Portafolio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TecnologiaProyectoController : Controller
    {
        private readonly ITecnologiaProyecto _tecp;

        public TecnologiaProyectoController(ITecnologiaProyecto tecp)
        {
            _tecp = tecp;
        }

        [HttpGet("GetTecnologiaProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTecnologiaProyecto()
        {
            var data = await _tecp.GetTecnologiaProyecto();
            return Ok(data);
        }

        [HttpPost("PostTecnologiaProyecto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostTecnologiaProyecto(TecnologiaProyecto tec)
        {
            try
            {
                var res = await _tecp.PostTecnologiaProyecto(tec);
                return Ok("guardado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("PutTecnologiaProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTecnologiaProyecto(TecnologiaProyecto tec)
        {
            try
            {
                var res = await _tecp.PutTecnologiaProyecto(tec);
                return Ok("Actualizado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("DeleteTecnologiaProyecto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTecnologiaProyecto(int id)
        {
            try
            {
                var res = await _tecp.DeleteTecnologiaProyecto(id);
                return Ok("Eliminado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
