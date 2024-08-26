using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Dominio.Interfaces
{
    public interface ISolicitudRepository
    {
        Task<Solicitud> GetSolicitudByIdAsync(int id);
        Task<IEnumerable<Solicitud>> GetAllSolicitudesAsync();
        Task AddSolicitudAsync(Solicitud solicitud);
        Task UpdateSolicitudAsync(Solicitud solicitud);
        Task DeleteSolicitudAsync(int id);
    }
}
