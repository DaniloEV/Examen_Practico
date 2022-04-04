using ApplicationCore.ModelResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceData
{
    public class ServiceUsuario : IServiceUsuario
    {
        public Usuario AutentificacionUsuario(Usuario usuariop)
        {
            try
            {
                Usuario usuario = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31848/api/user/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonString = new StringContent(JsonConvert.SerializeObject(usuariop), System.Text.Encoding.UTF8, "application/json");
                    System.Threading.Tasks.Task<HttpResponseMessage> responseTask = client.PostAsync("autenticar",jsonString);
                    responseTask.Wait();
                    HttpResponseMessage result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        System.Threading.Tasks.Task<Usuario> readTask = result.Content.ReadAsAsync<Usuario>(); ;
                        responseTask.Wait();
                        usuario = readTask.Result;
                    }
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario RegistroUsuario(Usuario usuariop)
        {
            try
            {
                Usuario usuario = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:31848/api/user/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var jsonString = new StringContent(JsonConvert.SerializeObject(usuariop), System.Text.Encoding.UTF8, "application/json");
                    System.Threading.Tasks.Task<HttpResponseMessage> responseTask = client.PostAsync("registrar", jsonString);
                    responseTask.Wait();
                    HttpResponseMessage result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        System.Threading.Tasks.Task<Usuario> readTask = result.Content.ReadAsAsync<Usuario>(); ;
                        responseTask.Wait();
                        usuario = readTask.Result;
                    }
                    return usuario;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
