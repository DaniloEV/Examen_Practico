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
    public class PermisoController : ControllerBase
    {
        // GET api/<PermisoController>/Lista
        [HttpGet("lista/{id}", Name = "ListaPermiso")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Permiso_Dto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListaPermisosPorId(int id)
        {
            try
            {
                if (id!=0)
                {
                    IServicePermiso servicePermiso = new ServicePermiso();
                    List<Permiso_Dto> listaPermiso_Dto = servicePermiso.ListaPermisosPorId(id);
                    if (listaPermiso_Dto!=null)
                    {
                        return Ok(servicePermiso.ListaPermisosPorId(id));
                    }
                    else
                    {
                        return NotFound();
                    }
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
