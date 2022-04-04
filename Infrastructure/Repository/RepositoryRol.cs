using Infrastructure.DtoModels;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class RepositoryRol : IRepositoryRol
    {
        public List<Rol_Dto> ListaRoles()
        {
            try
            {
                List<Rol_Dto> lista_permisos=new List<Rol_Dto>();
                using (Examen_Practico_Danilo_Espinoza_VillaltaContext ctx = new Examen_Practico_Danilo_Espinoza_VillaltaContext())
                {
                    List<Rol> lista_roles = ctx.Rol.ToList<Rol>();
                    if (lista_roles.Count!=0)
                    {
                        foreach (var item in lista_roles)
                        {
                            lista_permisos.Add(new Rol_Dto()
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion
                            });
                        };
                    }
                }
                return lista_permisos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
