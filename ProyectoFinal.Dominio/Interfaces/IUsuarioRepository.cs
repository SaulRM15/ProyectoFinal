using ProyectoFinal.Dominio.Entidades;

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
