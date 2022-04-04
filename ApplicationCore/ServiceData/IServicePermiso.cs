using ApplicationCore.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceData
{
    public interface IServicePermiso
    {
        List<Permiso> ListaPermisosPorId(int id);
    }
}
