using Infrastructure.DtoModels;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRepositoryRol
    {
        List<Rol_Dto> ListaRoles();
    }
}
