using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GastosApp.Core.Entities;
using GastosApp.Infrastructure.Interfaces;
using GastosApp.Infrastructure.Repositories;

namespace GastosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly IGastoRepository _gastoRepo;

        public GastoController(IGastoRepository gastoRepo)
        {
            _gastoRepo = gastoRepo;
        }


        [HttpPost]
        public async Task<IActionResult> Crear(Gasto gasto)
        {
            var creado = await _gastoRepo.AddAsync(gasto);
            return Ok(creado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var gasto = await _gastoRepo.ObtenerPorIdAsync(id);
            if (gasto == null)
                return NotFound($"No se encontró el gasto con ID {id}");

            await _gastoRepo.EliminarAsync(gasto);
            return NoContent();
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ObtenerPorUsuarioId(int usuarioId)
        {
            var gastos = await _gastoRepo.ObtenerPorUsuarioIdAsync(usuarioId);

            if (!gastos.Any())
                return NotFound($"No se encontraron gastos para el usuario con ID {usuarioId}");

            return Ok(gastos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, Gasto gasto)
        {
            if (id != gasto.Id)
                return BadRequest("El ID de la URL no coincide con el del gasto enviado.");

            var existente = await _gastoRepo.ObtenerPorIdAsync(id);
            if (existente == null)
                return NotFound($"No se encontró el gasto con ID {id}");

            // Actualizamos campos
            existente.Descripcion = gasto.Descripcion;
            existente.Monto = gasto.Monto;
            existente.Fecha = gasto.Fecha;
            existente.UsuarioId = gasto.UsuarioId;

            await _gastoRepo.ActualizarAsync(existente);
            return Ok(existente);
        }

    }
}
