using Infrastructure.DtoModels;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public Usuario_Dto AutentificacionUsuario(string nombre_Usuario, string contrasenna_Usuario)
        {
            Usuario_Dto usuario_Dto = null;
            try
            {
                using (Examen_Practico_Danilo_Espinoza_VillaltaContext ctx = new Examen_Practico_Danilo_Espinoza_VillaltaContext())
                {
                    Usuario usuario = ctx.Usuario
                        .Where(p => p.NombreUsuario.Equals(nombre_Usuario) && p.ContrasennaUsuario == contrasenna_Usuario)
                        .Include("Rol")
                        .FirstOrDefault();
                    if (usuario != null)
                    {
                        usuario_Dto = new Usuario_Dto()
                        {
                            NombreUsuario = usuario.NombreUsuario,
                            RolId = usuario.RolId,
                            Rol = new Rol_Dto()
                            {
                                Id = usuario.Rol.Id,
                                Descripcion = usuario.Rol.Descripcion,
                            },
                        };
                    }
                }
                return usuario_Dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario_Dto BuscarUsuarioPorNombre(string nombre_Usuario)
        {
            Usuario_Dto usuario_Dto = null;
            try
            {
                using (Examen_Practico_Danilo_Espinoza_VillaltaContext ctx = new Examen_Practico_Danilo_Espinoza_VillaltaContext())
                {
                    Usuario usuario = ctx.Usuario
                        .Where(p => p.NombreUsuario.Equals(nombre_Usuario))
                        .FirstOrDefault();
                    if (usuario != null)
                    {
                        usuario_Dto = new Usuario_Dto()
                        {
                            NombreUsuario = usuario.NombreUsuario,
                            RolId = usuario.RolId
                        };
                    }
                }
                return usuario_Dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario_Dto RegistroUsuario(Usuario_Dto usuario_Dto)
        {
            Usuario_Dto _usuario = null;
            try
            {
                using (Examen_Practico_Danilo_Espinoza_VillaltaContext ctx = new Examen_Practico_Danilo_Espinoza_VillaltaContext())
                {
                    Usuario usuario = new Usuario()
                    {
                        NombreUsuario = usuario_Dto.NombreUsuario,
                        ContrasennaUsuario = usuario_Dto.ContrasennaUsuario,
                        RolId = usuario_Dto.RolId
                    };
                    ctx.Usuario.Add(usuario);
                    ctx.SaveChanges();
                    _usuario = BuscarUsuarioPorNombre(usuario_Dto.NombreUsuario);
                    return _usuario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
