using Portafolio.Repositorie.Interfaces;
using Portafolio.Model;
using Microsoft.AspNetCore.Mvc;

namespace Portafolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepositorie;

        public UsuarioController(IUsuario usuarioRepositorie)
        {
            _usuarioRepositorie = usuarioRepositorie;
        }

        [HttpGet("GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuario()
        {
            var data = await _usuarioRepositorie.GetUsuario();
            return Ok(data);
        }

        [HttpPost("PostUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostUsuario(Usuario user)
        {
            try
            {
                var res = await _usuarioRepositorie.PostUsuario(user);
                return Ok("Usuario guardado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("PutUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutUsuario(Usuario user)
        {
            try
            {
                var res = await _usuarioRepositorie.PutUsuario(user);
                return Ok("Usuario actualizado correctamente");
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("DeleteUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var res = await _usuarioRepositorie.DeleteUsuario(id);
                return Ok("El usuario fue eliminado correctamente");
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
