using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GastosApp.Core.Entities; 
using GastosApp.Infrastructure.Interfaces;
using GastosApp.API.Models; 

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
            // Nota: Para Registrar, también es buena idea usar un DTO de registro.
            // Por ahora lo dejamos así, pero tenlo en cuenta.
            var nuevo = await _usuarioRepo.AddAsync(usuario);
            return Ok(nuevo);
        }

        [HttpPost("login")]
        // Cambiamos el parámetro de entrada a LoginRequestDto
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request) // <--- Cambiado aquí
        {

            var existente = await _usuarioRepo.GetByEmailAsync(request.email); // <--- Usamos request.Email

            // Aquí es donde deberías validar la contraseña, idealmente con hash
            // Por ahora, usamos la comparación directa:
            if (existente == null || existente.Contraseña != request.contraseña) // <--- Usamos request.Contraseña
                return Unauthorized("Credenciales incorrectas");

            // Mapeamos el objeto de entidad 'Usuario' a nuestro DTO de respuesta
            var usuarioResponse = new UsuarioLoginResponseDto
            {
                id = existente.Id,
                nombre = existente.Nombre,
                apellido = existente.Apellido,
                email = existente.Email
            };

            // Si necesitaras los gastos, los mapearías aquí también, usando GastoDto
            // usuarioResponse.Gastos = existente.Gastos.Select(g => new GastoDto { ... }).ToList();

            return Ok(usuarioResponse); // <--- Devolvemos el DTO
        }
    }
}