using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DtoModels
{
    public class Usuario_Dto
    {
        public string NombreUsuario { get; set; }
        public string ContrasennaUsuario { get; set; }
        public int? RolId { get; set; }
        public Rol_Dto Rol { get; set; }
    }
}
