using FestivosPascua.Core.Servicios;
using FestivosPascua.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace FestivosPascua.Presentacion.Controllers
{
    [ApiController]
    [Route("api/tipos")]
    
    public class TiposController : ControllerBase
    {
        private readonly ITipoServicios servicio;

        public TiposController(ITipoServicios tipoServicio)
        {
            servicio = tipoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var tipos = await servicio.ObtenerTodos();
            return Ok(tipos);
        }

        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var tipo = await servicio.Obtener(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Agregar([FromBody] ClsTipo tipo)
        {
            var nuevoTipo = await servicio.Agregar(tipo);
            return CreatedAtAction(nameof(Obtener), new { id = nuevoTipo.Id }, nuevoTipo);
        }

        [HttpPut("modificar/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ClsTipo tipo)
        {
            if (id != tipo.Id) return BadRequest();

            var tipoActualizado = await servicio.Modificar(tipo);
            if (tipoActualizado == null) return NotFound();

            return Ok(tipoActualizado);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await servicio.Eliminar(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}
