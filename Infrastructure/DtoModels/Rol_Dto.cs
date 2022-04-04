using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DtoModels
{
   public class Rol_Dto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Permiso_Dto> Lista_Permisos { get; set; }
    }
}
