using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GastosApp.Core.Entities;
using GastosApp.Infrastructure.Interfaces;

namespace GastosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            var nuevo = await _usuarioRepo.AddAsync(usuario);
            return Ok(nuevo);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var existente = await _usuarioRepo.GetByEmailAsync(usuario.Email);
            if (existente == null || existente.Contraseña != usuario.Contraseña)
                return Unauthorized("Credenciales incorrectas");

            return Ok(existente);
        }
    }
}
