using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Dominio.Entities;

namespace App.Aplicacion.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Curso>> ObtenerCursosAsync();
        Task<Curso> ObtenerCursoPorIdAsync(int id);
        Task<Curso> CrearCursoAsync(Curso curso);
        Task<Curso> ActualizarCursoAsync(int id, Curso curso);
        Task<bool> EliminarCursoAsync(int id);
    }
}
