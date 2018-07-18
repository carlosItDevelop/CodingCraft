using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Cooperchip.MedicalManagement.Api.BindingModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Nome do Usuário")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
