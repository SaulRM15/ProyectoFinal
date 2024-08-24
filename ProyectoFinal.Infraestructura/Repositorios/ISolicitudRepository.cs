using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces;
using ProyectoFinal.Infraestructura.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Infraestructura.Repositorios
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly ApplicationDbContext _context;

        public SolicitudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitud> GetSolicitudByIdAsync(int id)
        {
            return await _context.Solicitudes
                .Include(s => s.UsuarioAsignado)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Solicitud>> GetAllSolicitudesAsync()
        {
            return await _context.Solicitudes.Include(s => s.UsuarioAsignado).ToListAsync();
        }

        public async Task AddSolicitudAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSolicitudAsync(Solicitud solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSolicitudAsync(int id)
        {
            var solicitud = await GetSolicitudByIdAsync(id);
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
        }
    }

}
