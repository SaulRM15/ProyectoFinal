using ProyectoFinal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
