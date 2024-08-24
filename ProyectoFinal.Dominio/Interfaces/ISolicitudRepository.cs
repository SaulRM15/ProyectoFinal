using ProyectoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
