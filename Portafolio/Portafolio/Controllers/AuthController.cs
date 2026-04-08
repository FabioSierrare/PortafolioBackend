using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BCrypt.Net;
using Portafolio.Model;
using Portafolio.Context;

namespace Portafolio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ContextDB _context;

        public AuthController(IConfiguration config, ContextDB context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if(login == null || string.IsNullOrEmpty(login.Correo) || string.IsNullOrEmpty(login.Contraseña))
            {
                return BadRequest("Error en la petición");
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == login.Correo);

            if(usuario == null || !BCrypt.Net.BCrypt.Verify(login.Contraseña, usuario.Contraseña))
            {
                return Unauthorized("Correo o Contraseña incorrectos");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var firma = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var option = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: firma
                );

            var tk = new JwtSecurityTokenHandler().WriteToken(option);


            return Ok(new { token = tk });
        }
    }
}
