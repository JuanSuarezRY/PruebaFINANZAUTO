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
    public class CoursesController : ControllerBase
    {

        private readonly ICourseRepository _service;

        public CoursesController(ICourseRepository service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene todos los cursos de la Tabla.
        /// </summary>
        [HttpGet("cursos")]
        public async Task<ActionResult<List<Curso>>> ObtenerCursos()
        {
            var cursos = await _service.ObtenerCursosAsync();
            return Ok(cursos);
        }
        /// <summary>
        /// Obtiene todos los cursos de la Tabla por id.
        /// </summary>
        [HttpGet("cursos/{id}")]
        public async Task<ActionResult<Curso>> ObtenerCursoPorId(int id)
        {
            var curso = await _service.ObtenerCursoPorIdAsync(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }
        /// <summary>
        /// Inserta registro en la tabla cursos
        /// </summary>
        [HttpPost("cursos")]
        public async Task<ActionResult<Curso>> CrearCurso([FromBody] Curso curso)
        {
            var creado = await _service.CrearCursoAsync(curso);
            return CreatedAtAction(nameof(ObtenerCursoPorId), new { id = creado.IdCurso }, creado);
        }
        /// <summary>
        /// Actualiza registro en la tabla cursos
        /// </summary>
        [HttpPut("cursos/{id}")]
        public async Task<ActionResult<Curso>> ActualizarCurso(int id, [FromBody] Curso curso)
        {
            var actualizado = await _service.ActualizarCursoAsync(id, curso);
            if (actualizado == null) return NotFound();
            return Ok(actualizado);
        }
        /// <summary>
        /// Elimina registro en la tabla cursos
        /// </summary>
        [HttpDelete("cursos/{id}")]
        public async Task<ActionResult> EliminarCurso(int id)
        {
            var eliminado = await _service.EliminarCursoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}

