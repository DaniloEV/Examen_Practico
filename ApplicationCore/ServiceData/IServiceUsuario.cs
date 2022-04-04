using ApplicationCore.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceData
{
    public interface IServiceUsuario
    {
        Usuario AutentificacionUsuario(Usuario usuariop);
        Usuario RegistroUsuario(Usuario usuariop);
    }
}
