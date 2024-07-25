using EcosistemasMarinos.LogicaNegocio.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcosistemasMarinos.MVC.Models {
    public class UsuarioRegistroViewModel
    {
        [Required(ErrorMessage = "Alias es obligatorio.")]
        [MaxLength(50)]
        public string? Alias { get; set; }


        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol es obligatorio.")]
        public Roles? Rol { get; set; }

        public IEnumerable<Roles> ListadoRoles { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "La contraseña debe tener entre 8 y 50 caracteres, mayúscula, minúsculas, y uno de los siguientes símbolos: . , # ; : ! ")]
        public string? Password { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Debe repetir la contraseña.")]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden. Intente nuevamente.")]
        public string? PasswordConfirmar { get; set; }

        //Constructor para que el viewmodel siempre tenga la lista de roles cargada
        public UsuarioRegistroViewModel() {
            ListadoRoles = (IEnumerable<Roles>)Enum.GetValues(typeof(Roles));
        }
    }
}