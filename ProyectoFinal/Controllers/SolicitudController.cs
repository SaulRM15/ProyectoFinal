using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Application.Servicios;
using ProyectoFinal.Dominio.Entidades;
using System.Threading.Tasks;

public class SolicitudController : Controller
{
    private readonly SolicitudService _solicitudService;
    private readonly UsuarioService _usuarioService;

    public SolicitudController(SolicitudService solicitudService, UsuarioService usuarioService)
    {
        _solicitudService = solicitudService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var solicitudes = await _solicitudService.GetSolicitudesAsync();
        return View(solicitudes);
    }

    public async Task<IActionResult> Create()
    {
        // Inicializar ViewBag.Usuarios con la lista de usuarios
        var usuarios = await _usuarioService.GetUsuariosAsync();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            solicitud.FechaCreacion = DateTime.Now;
            solicitud.Estado = EstadoSolicitud.Creado;
            await _solicitudService.AddSolicitudAsync(solicitud);
            return RedirectToAction(nameof(Index));
        }

        // Si el modelo no es válido, volver a cargar ViewBag.Usuarios
        var usuarios = await _usuarioService.GetUsuariosAsync();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre");

        return View(solicitud);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudAsync(id);
        if (solicitud == null)
        {
            return NotFound();
        }

        // Inicializar ViewBag.Usuarios con la lista de usuarios
        var usuarios = await _usuarioService.GetUsuariosAsync();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre");

        return View(solicitud);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            await _solicitudService.UpdateSolicitudAsync(solicitud);
            return RedirectToAction(nameof(Index));
        }

        // Si el modelo no es válido, volver a cargar ViewBag.Usuarios
        var usuarios = await _usuarioService.GetUsuariosAsync();
        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre");

        return View(solicitud);
    }

    public async Task<IActionResult> Details(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudAsync(id);
        if (solicitud == null)
        {
            return NotFound();
        }
        return View(solicitud);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudAsync(id);
        if (solicitud == null)
        {
            return NotFound();
        }
        return View(solicitud);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudAsync(id);
        if (solicitud != null)
        {
            await _solicitudService.DeleteSolicitudAsync(id);
        }
        return RedirectToAction(nameof(Index));
    }
}
