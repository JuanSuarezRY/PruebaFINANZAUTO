using App.Aplicacion.DTOS.Autorizacion;

namespace App.Api.Services
{
    public interface IAutorizacionRepository
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}
