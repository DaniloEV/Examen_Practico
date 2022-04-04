using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Usuario
    {
        public string NombreUsuario { get; set; }
        public string ContrasennaUsuario { get; set; }
        public int? RolId { get; set; }

        public Rol Rol { get; set; }
    }
}
