
using Infrastructure.DtoModels;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario_Dto AutentificacionUsuario(string nombre_Usuario, string contrasenna_Usuario);
        Usuario_Dto BuscarUsuarioPorNombre(string nombre_Usuario);
        Usuario_Dto RegistroUsuario(Usuario_Dto usuario_Dto);
    }
}
