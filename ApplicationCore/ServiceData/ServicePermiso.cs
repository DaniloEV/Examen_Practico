using ApplicationCore.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceData
{
    public class ServicePermiso : IServicePermiso
    {
        public List<Permiso> ListaPermisosPorId(int id)
        {
            try
            {
                List<Permiso> lista_permisos = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31848/api/permiso/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    System.Threading.Tasks.Task<HttpResponseMessage> responseTask = client.GetAsync("lista/"+id);
                    responseTask.Wait();
                    HttpResponseMessage result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        System.Threading.Tasks.Task<List<Permiso>> readTask = result.Content.ReadAsAsync<List<Permiso>>(); ;
                        responseTask.Wait();
                        lista_permisos = readTask.Result;
                    }
                    return lista_permisos;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
