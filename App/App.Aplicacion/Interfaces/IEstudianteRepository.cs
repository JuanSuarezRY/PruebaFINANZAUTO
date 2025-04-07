using App.Dominio.Entities;
namespace App.Api.Services
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> ObtenerTodosEstudiantesAsync();
        Task<Estudiante> ObtenerEstudiantePorIdAsync(int id);
        Task<Estudiante> CrearEstudianteAsync(Estudiante estudiante);
        Task<Estudiante> ActualizarEstudianteAsync(int id, Estudiante estudiante);
        Task<bool> EliminarEstudianteAsync(int id);
    }
}
