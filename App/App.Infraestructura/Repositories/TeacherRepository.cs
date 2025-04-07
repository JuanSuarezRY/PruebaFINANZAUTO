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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DbAppContext _context;

        public TeacherRepository(DbAppContext context)
        {
            _context = context;
        }

       
        public async Task<List<Profesores>> ObtenerProfesoresAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesores> ObtenerProfesorPorIdAsync(int id)
        {
            return await _context.Profesores
                .Include(p => p.IdProfesor)
            .FirstOrDefaultAsync(p => p.IdProfesor == id);
        }

        public async Task<Profesores> CrearProfesorAsync(Profesores profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();
            return profesor;
        }

        public async Task<Profesores> ActualizarProfesorAsync(int id, Profesores profesor)
        {
            var profesorExistente = await _context.Profesores.FindAsync(id);
            if (profesorExistente == null) return null;

            profesorExistente.Nombre = profesor.Nombre;

            await _context.SaveChangesAsync();
            return profesorExistente;
        }

        public async Task<bool> EliminarProfesorAsync(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return false;

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}