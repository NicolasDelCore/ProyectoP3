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
        [Required(ErrorMessage = "La contrase�a debe tener entre 8 y 50 caracteres, may�scula, min�sculas, y uno de los siguientes s�mbolos: . , # ; : ! ")]
        public string? Password { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Debe repetir la contrase�a.")]
        [Display(Name = "Confirmar contrase�a")]
        [Compare("Password", ErrorMessage = "Las contrase�as no coinciden. Intente nuevamente.")]
        public string? PasswordConfirmar { get; set; }

        //Constructor para que el viewmodel siempre tenga la lista de roles cargada
        public UsuarioRegistroViewModel() {
            ListadoRoles = (IEnumerable<Roles>)Enum.GetValues(typeof(Roles));
        }
    }
}