using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}
