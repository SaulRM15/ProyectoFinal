using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Dominio.Entidades
{
    public class Solicitud
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? AprobadoPor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public Usuario? UsuarioAsignado { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public EstadoSolicitud Estado { get; set; }
    }

    public enum EstadoSolicitud
    {
        Creado,
        EnRevision,
        Aprobado,
        ControlDeCambios,
        Rechazado,
        Archivado
    }
}
