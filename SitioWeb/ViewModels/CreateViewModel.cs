using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.ModelResponse;

namespace SitioWeb.ViewModels
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es un dato requerido")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "La contraseña es un dato requerido")]
        [Display(Name = "Contraseña de usuario")]
        public string ContrasennaUsuario { get; set; }
        [Display(Name = "Rol de usuario")]
        public int RolSeleccionado { get; set; }
        public List<Rol> ListaRoles { get; set; }
    }
}