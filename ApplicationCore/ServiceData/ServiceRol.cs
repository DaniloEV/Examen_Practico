using ApplicationCore.ModelResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceData
{
    public class ServiceRol : IServiceRol
    {
        public List<Rol> ListaRoles()
        {
            try
            {
                List<Rol> lista_roles = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31848/api/rol/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    System.Threading.Tasks.Task<HttpResponseMessage> responseTask = client.GetAsync("lista");
                    responseTask.Wait();
                    HttpResponseMessage result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        System.Threading.Tasks.Task<List<Rol>> readTask = result.Content.ReadAsAsync<List<Rol>>(); ;
                        responseTask.Wait();
                        lista_roles = readTask.Result;
                    }
                    return lista_roles;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
