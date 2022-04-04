using Infrastructure.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Services
{
    interface IServiceUsuario
    {
        Usuario_Dto AutentificacionUsuario(string nombre_Usuario, string contrasenna_Usuario);
        Usuario_Dto RegistroUsuario(Usuario_Dto usuario_Dto);
    }
}
