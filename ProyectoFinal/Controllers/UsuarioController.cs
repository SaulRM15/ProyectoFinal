using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Application.Servicios;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.AddUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetUsuarioAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.UpdateUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetUsuarioAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
