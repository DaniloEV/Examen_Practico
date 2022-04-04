using ApplicationCore.ModelResponse;
using ApplicationCore.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicativoWpf.MVVM.ViewModel
{
    public class BienvenidoViewModel
    {
        public Usuario Usuario { get; set; }
        public List<Permiso> ListPermiso { get; set; }
        internal void InitList()
        {
            try
            {
                ServicePermiso servicePermiso = new ServicePermiso();
                ListPermiso = servicePermiso.ListaPermisosPorId((int)Usuario.RolId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
