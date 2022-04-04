using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        public Permiso Permiso { get; set; }
        public Rol Rol { get; set; }
    }
}
