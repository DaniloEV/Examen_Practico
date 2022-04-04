using ApplicationCore.ModelResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioWeb.ViewModels
{
    public class WelcomeViewModel
    {
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Rol de usuario")]
        public Rol Rol { get; set; }
        public List<Permiso> ListaPermisos { get; set; }
    }
}