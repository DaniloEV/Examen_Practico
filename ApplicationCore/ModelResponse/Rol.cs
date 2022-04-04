using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ModelResponse
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Permiso> Lista_Permisos { get; set; }
    }
}
