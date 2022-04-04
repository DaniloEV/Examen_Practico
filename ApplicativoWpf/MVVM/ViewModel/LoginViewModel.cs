using ApplicationCore.ModelResponse;
using ApplicationCore.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicativoWpf.MVVM.ViewModel
{
    public class LoginViewModel
    {
        private static Usuario _UsuarioLogin { get; set; }
        public Usuario UsuarioVista { get; set; }
        public Usuario UsuarioLogin { get; set; }
        public LoginViewModel()
        {
            UsuarioVista = new Usuario();
        }
        internal void AutenticarUsuario()
        {
            try
            {
                ServiceUsuario serviceUsuario = new ServiceUsuario();
                UsuarioLogin = serviceUsuario.AutentificacionUsuario(UsuarioVista);
                _UsuarioLogin = UsuarioLogin;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal static Usuario GetUsuario()
        {
            try
            {
                return _UsuarioLogin;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
