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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await GetUsuarioByIdAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

}
