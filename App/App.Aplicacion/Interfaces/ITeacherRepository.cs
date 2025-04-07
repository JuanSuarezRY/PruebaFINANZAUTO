using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Dominio.Entities;

namespace App.Aplicacion.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Profesores>> ObtenerProfesoresAsync();
        Task<Profesores> ObtenerProfesorPorIdAsync(int id);
        Task<Profesores> CrearProfesorAsync(Profesores profesor);
        Task<Profesores> ActualizarProfesorAsync(int id, Profesores profesor);
        Task<bool> EliminarProfesorAsync(int id);

    }
}
