using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            RolPermiso = new HashSet<RolPermiso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<RolPermiso> RolPermiso { get; set; }
    }
}
