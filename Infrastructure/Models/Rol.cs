using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class Rol
    {
        public Rol()
        {
            RolPermiso = new HashSet<RolPermiso>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<RolPermiso> RolPermiso { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
