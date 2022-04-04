using ApplicationCore.ModelResponse;
using ApplicationCore.ServiceData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicativoWpf.MVVM.ViewModel
{
    public class RegistroViewModel : BaseViewModel
    {
        public Usuario Usuario { get; set; }
        public ObservableCollection<Rol> ListRol { get; set; }
        public RegistroViewModel()
        {
            Usuario = new Usuario();
        }
        internal void InitList()
        {
            try
            {
                ServiceRol serviceRol = new ServiceRol();
                ListRol = new ObservableCollection<Rol>(serviceRol.ListaRoles());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal Usuario RegistrarUsuario()
        {
            try
            {
                ServiceUsuario serviceUsuario = new ServiceUsuario();
                Usuario.RolId = Usuario.Rol.Id;
                return serviceUsuario.RegistroUsuario(Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
