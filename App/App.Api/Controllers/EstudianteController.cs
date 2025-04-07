using App.Api.Services;
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
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteService;
       
        public EstudiantesController(IEstudianteRepository estudianteService)
        {
            _estudianteService = estudianteService;
        }

        /// <summary>
        /// Obtiene todos los Estudiantes de la Tabla.
        /// </summary>
        [HttpGet]
        
        public async Task<IActionResult> GetEstudiantes()
        {
            var estudiantes = await _estudianteService.ObtenerTodosEstudiantesAsync();
            return Ok(estudiantes);
        }
        /// <summary>
        /// Obtiene un estudiante dependiendo del ID que se consulte
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudiante(int id)
        {
            var estudiante = await _estudianteService.ObtenerEstudiantePorIdAsync(id);
            if (estudiante == null) return NotFound();
            return Ok(estudiante);
        }
        /// <summary>
        /// Inserta registro en la tabla estudiante
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null) return BadRequest();

            var nuevoEstudiante = await _estudianteService.CrearEstudianteAsync(estudiante);
            return CreatedAtAction(nameof(GetEstudiante), new { id = nuevoEstudiante.IdEstudiante }, nuevoEstudiante);
        }
        /// <summary>
        /// Actualiza registro en la tabla estudiante
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEstudiante(int id, [FromBody] Estudiante estudiante)
        {
            if (estudiante == null || id != estudiante.IdEstudiante) return BadRequest();

            var estudianteActualizado = await _estudianteService.ActualizarEstudianteAsync(id, estudiante);
            if (estudianteActualizado == null) return NotFound();

            return Ok(estudianteActualizado);
        }
        /// <summary>
        /// EndPoint Elimina Usuarios del Sistema.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEstudiante(int id)
        {
            var eliminado = await _estudianteService.EliminarEstudianteAsync(id);
            if (!eliminado) return NotFound();

            return NoContent();
        }
    }
}

