using Infrastructure.DtoModels;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class RepositoryPermiso : IRepositoryPermiso
    {
        public List<Permiso_Dto> ListaPermisosPorId(int id)
        {
            try
            {
                List<Permiso_Dto> lista_permisos = new List<Permiso_Dto>();
                using (Examen_Practico_Danilo_Espinoza_VillaltaContext ctx = new Examen_Practico_Danilo_Espinoza_VillaltaContext())
                {
                    List<RolPermiso> lista_rolpermiso = ctx.RolPermiso.Where(p => p.RolId ==id).Include("Permiso").ToList();
                    if (lista_rolpermiso.Count!=0)
                    {
                        foreach (var item in lista_rolpermiso)
                        {
                            lista_permisos.Add(new Permiso_Dto()
                            {
                                Id = item.Permiso.Id,
                                Descripcion = item.Permiso.Descripcion
                            });
                        }
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
