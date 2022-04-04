using Infrastructure.DtoModels;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public Usuario_Dto AutentificacionUsuario(string nombre_Usuario, string contrasenna_Usuario)
        {
            Usuario_Dto usuario_ = null;
            try
            {
                IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
                usuario_ = repositoryUsuario.AutentificacionUsuario(nombre_Usuario, contrasenna_Usuario);
                return usuario_;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario_Dto RegistroUsuario(Usuario_Dto usuario_Dto)
        {
            Usuario_Dto usuario_ = null;
            try
            {
                IRepositoryUsuario repositoryUsuario = new RepositoryUsuario();
                usuario_ = repositoryUsuario.RegistroUsuario(usuario_Dto);
                return usuario_;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
