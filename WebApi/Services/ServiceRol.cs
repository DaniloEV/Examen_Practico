using Infrastructure.DtoModels;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class ServiceRol : IServiceRol
    {
        public List<Rol_Dto> ListaRoles()
        {
            try
            {
                IRepositoryRol repositoryrol = new RepositoryRol();
                return repositoryrol.ListaRoles();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
