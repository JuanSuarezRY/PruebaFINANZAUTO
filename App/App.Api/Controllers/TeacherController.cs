using App.Aplicacion.Interfaces;
using App.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar estudiantes en el sistema.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _service;

        public TeacherController(ITeacherRepository service)
        {
            _service = service;
        }
        /// <summary>
        /// Obtiene todos los profesores de la Tabla.
        /// </summary>
        [HttpGet("profesores")]
        public async Task<ActionResult<List<Profesores>>> ObtenerProfesores()
        {
            var profesores = await _service.ObtenerProfesoresAsync();
            return Ok(profesores);
        }
        /// <summary>
        /// Obtiene todos los profesores de la Tabla por id.
        /// </summary>
        [HttpGet("profesores/{id}")]
        public async Task<ActionResult<Profesores>> ObtenerProfesorPorId(int id)
        {
            var profesor = await _service.ObtenerProfesorPorIdAsync(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }
        /// <summary>
        /// Inserta registro en la tabla profesores
        /// </summary>
        [HttpPost("profesores")]
        public async Task<ActionResult<Profesores>> CrearProfesor([FromBody] Profesores profesor)
        {
            var creado = await _service.CrearProfesorAsync(profesor);
            return CreatedAtAction(nameof(ObtenerProfesorPorId), new { id = creado.IdProfesor }, creado);
        }
        /// <summary>
        /// Actualiza registro en la tabla profesores
        /// </summary>
        [HttpPut("profesores/{id}")]
        public async Task<ActionResult<Profesores>> ActualizarProfesor(int id, [FromBody] Profesores profesor)
        {
            var actualizado = await _service.ActualizarProfesorAsync(id, profesor);
            if (actualizado == null) return NotFound();
            return Ok(actualizado);
        }
        /// <summary>
        /// Elimina registro en la tabla profesores
        /// </summary>
        [HttpDelete("profesores/{id}")]
        public async Task<ActionResult> EliminarProfesor(int id)
        {
            var eliminado = await _service.EliminarProfesorAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }

    }
}

