using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ModelResponse
{
    public class Usuario
    {

        [Required(ErrorMessage = "El nombre de usuario es un dato requerido")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "La contraseña es un dato requerido")]
        [Display(Name = "Contraseña de usuario")]
        public string ContrasennaUsuario { get; set; }
        public int? RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
