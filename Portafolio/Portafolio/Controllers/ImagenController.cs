using Microsoft.AspNetCore.Mvc;
using Portafolio.Model;
using Portafolio.Repositorie.Interfaces;


namespace Portafolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : Controller
    {
        private readonly IImagen _imagen;

        public ImagenController(IImagen imagen)
        {
            _imagen = imagen;
        }

        [HttpGet("GetImagen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImagenes()
        {
            var data = await _imagen.GetImagenes();
            return Ok(data);
        }

        [HttpPost("PostImagen")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostImagen(Imagen img)
        {
            try
            {
                var res = await _imagen.PostImagen(img);
                return Ok("Imagen guardada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("PutImagen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutImagen(Imagen img)
        {
            try
            {
                var res = await _imagen.PutImagen(img);
                return Ok("Imagen actualizada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("DeleteImagen/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            try
            {
                var res = await _imagen.DeleteImagen(id);
                return Ok("La imagen fue eliminada correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
