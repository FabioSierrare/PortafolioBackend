using Microsoft.AspNetCore.Mvc;
using Portafolio.Model;
using Portafolio.Repositorie.Interfaces;

namespace Portafolio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private readonly IProyecto _proyecto;

        public ProyectoController(IProyecto proyecto)
        {
            _proyecto = proyecto;
        }

        [HttpGet("GetProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProyectos()
        {
            var data = await _proyecto.GetProyectos();
            return Ok(data);
        }

        [HttpPost("PostProyecto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostProyecto(Proyecto proyect)
        {
            try
            {
                var res = await _proyecto.PostProyecto(proyect);
                return Ok("Proyecto guardado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("PutProyecto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutProyecto(Proyecto proyect)
        {
            try
            {
                var res = await _proyecto.PutProyecto(proyect);
                return Ok("Proyecto actualizado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("DeleteProyecto/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            try
            {
                var res = await _proyecto.DeleteProyecto(id);
                return Ok("El proyecto fue eliminada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("PostProyectoCompleto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostProyecto([FromForm] ProyectoTecPro proyect)
        {
            try
            {
                var res = await _proyecto.PostProyecto(proyect);
                return Ok("Proyecto guardado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("GetProyectoInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProyectosInfo()
        {
            var data = await _proyecto.GetProyectosInfo();
            return Ok(data);
        }

        [HttpGet("GetProyectoInfolimit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProyectosInfolimit()
        {
            var data = await _proyecto.GetProyectosInfolimit();
            return Ok(data);
        }
    }
}
