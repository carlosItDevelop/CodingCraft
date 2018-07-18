using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Cooperchip.MedicalManagement.Api.BindingModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
