using Infrastructure.DtoModels;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRepositoryPermiso
    {
        List<Permiso_Dto> ListaPermisosPorId(int id);
    }
}
