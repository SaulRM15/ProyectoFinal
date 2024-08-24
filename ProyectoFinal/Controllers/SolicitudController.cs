using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Application.Servicios;
using ProyectoFinal.Dominio.Entidades;

namespace ProyectoFinal.Api.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly SolicitudService _solicitudService;

        public SolicitudController(SolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        public async Task<IActionResult> Index()
        {
            var solicitudes = await _solicitudService.GetSolicitudesAsync();
            return View(solicitudes);
        }

        public IActionResult Create()
        {
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
            return View(solicitud);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var solicitud = await _solicitudService.GetSolicitudAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
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
            await _solicitudService.DeleteSolicitudAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, EstadoSolicitud nuevoEstado)
        {
            var solicitud = await _solicitudService.GetSolicitudAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            solicitud.Estado = nuevoEstado;
            if (nuevoEstado == EstadoSolicitud.Aprobado)
            {
                solicitud.FechaAprobacion = DateTime.Now;
            }

            await _solicitudService.UpdateSolicitudAsync(solicitud);
            return RedirectToAction(nameof(Details), new { id = solicitud.Id });
        }
    }

}
