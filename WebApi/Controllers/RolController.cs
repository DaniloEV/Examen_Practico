using Infrastructure.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        // GET api/<UserController>/Autenticar
        [HttpGet("lista", Name = "ListaRol")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rol_Dto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListaRoles()
        {
            try
            {
                IServiceRol serviceRol = new ServiceRol();
                List<Rol_Dto> lista_roles = serviceRol.ListaRoles();
                if (lista_roles!=null)
                {
                    return Ok(serviceRol.ListaRoles());
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
