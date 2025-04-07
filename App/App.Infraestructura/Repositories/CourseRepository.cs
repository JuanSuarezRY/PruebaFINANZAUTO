using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Aplicacion.Interfaces;
using App.Dominio.Entities;
using App.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructura.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DbAppContext _context;

        public CourseRepository(DbAppContext context)
        {
            _context = context;
        }
        public async Task<List<Curso>> ObtenerCursosAsync()
    {
            return await _context.Cursos.ToListAsync();
        }

    public async Task<Curso> ObtenerCursoPorIdAsync(int id)
    {
        return await _context.Cursos
            .Include(c => c.IdCurso)
            .FirstOrDefaultAsync(c => c.IdCurso == id);
    }

    public async Task<Curso> CrearCursoAsync(Curso curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
        return curso;
    }

    public async Task<Curso> ActualizarCursoAsync(int id, Curso curso)
    {
        var cursoExistente = await _context.Cursos.FindAsync(id);
        if (cursoExistente == null) return null;

        cursoExistente.Nombre = curso.Nombre;
       
        cursoExistente.IdProfesor = curso.IdProfesor;

        await _context.SaveChangesAsync();
        return cursoExistente;
    }

    public async Task<bool> EliminarCursoAsync(int id)
    {
        var curso = await _context.Cursos.FindAsync(id);
        if (curso == null) return false;

        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();
        return true;
    }
}
}
