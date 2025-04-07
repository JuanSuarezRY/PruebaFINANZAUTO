using App.Dominio.Entities;
using App.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Api.Services
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly DbAppContext _context;

        public EstudianteRepository(DbAppContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> ObtenerTodosEstudiantesAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante> ObtenerEstudiantePorIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task<Estudiante> CrearEstudianteAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return estudiante;
        }

        public async Task<Estudiante> ActualizarEstudianteAsync(int id, Estudiante estudiante)
        {
            var estudianteExistente = await _context.Estudiantes.FindAsync(id);
            if (estudianteExistente == null) return null;

            estudianteExistente.Nombre = estudiante.Nombre;
            estudianteExistente.Documento = estudiante.Documento;

            _context.Estudiantes.Update(estudianteExistente);
            await _context.SaveChangesAsync();
            return estudianteExistente;
        }

        public async Task<bool> EliminarEstudianteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return false;

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
