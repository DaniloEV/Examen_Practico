using Infrastructure.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IServiceRol
    {
        List<Rol_Dto> ListaRoles();
    }
}
