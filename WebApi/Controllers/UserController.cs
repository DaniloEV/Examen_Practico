using Infrastructure.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //POST api/<UserController>/Autenticar
        [HttpPost("autenticar", Name = "Autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario_Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Autenticar([FromBody] Usuario_Dto usuario_Dto)
        {
            try
            {
                if (usuario_Dto != null)
                {
                    IServiceUsuario serviceUsuario = new ServiceUsuario();
                    Usuario_Dto usuario = serviceUsuario.AutentificacionUsuario(usuario_Dto.NombreUsuario, usuario_Dto.ContrasennaUsuario);
                    if (usuario != null)
                    {
                        return Ok(usuario);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<UserController>/Registrar
        [HttpPost("registrar", Name = "Registrar")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Usuario_Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Registrar([FromBody] Usuario_Dto usuario_Dto)
        {
            try
            {
                if (usuario_Dto != null)
                {
                    IServiceUsuario serviceUsuario = new ServiceUsuario();
                    Usuario_Dto usuario_ = serviceUsuario.RegistroUsuario(usuario_Dto);
                    if (usuario_!=null)
                    {
                        return Ok(usuario_);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
