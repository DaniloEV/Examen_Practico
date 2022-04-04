using Infrastructure.DtoModels;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class ServicePermiso : IServicePermiso
    {
        public List<Permiso_Dto> ListaPermisosPorId(int id)
        {
            try
            {
                IRepositoryPermiso repositoryPermiso = new RepositoryPermiso();
                return repositoryPermiso.ListaPermisosPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
