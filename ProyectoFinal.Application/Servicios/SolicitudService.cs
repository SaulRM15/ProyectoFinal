using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces;

namespace ProyectoFinal.Application.Servicios
{
    public class SolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepository;

        public SolicitudService(ISolicitudRepository solicitudRepository)
        {
            _solicitudRepository = solicitudRepository;
        }

        public async Task<IEnumerable<Solicitud>> GetSolicitudesAsync()
        {
            return await _solicitudRepository.GetAllSolicitudesAsync();
        }

        public async Task<Solicitud> GetSolicitudAsync(int id)
        {
            return await _solicitudRepository.GetSolicitudByIdAsync(id);
        }

        public async Task AddSolicitudAsync(Solicitud solicitud)
        {
            await _solicitudRepository.AddSolicitudAsync(solicitud);
        }

        public async Task UpdateSolicitudAsync(Solicitud solicitud)
        {
            await _solicitudRepository.UpdateSolicitudAsync(solicitud);
        }

        public async Task DeleteSolicitudAsync(int id)
        {
            await _solicitudRepository.DeleteSolicitudAsync(id);
        }
    }

}
