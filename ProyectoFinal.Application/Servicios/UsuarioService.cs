using ProyectoFinal.Dominio.Entidades;
using ProyectoFinal.Dominio.Interfaces;

namespace ProyectoFinal.Application.Servicios
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }
    }

}
