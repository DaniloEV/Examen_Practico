using Infrastructure.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IServicePermiso
    {
        List<Permiso_Dto> ListaPermisosPorId(int id);
    }
}
