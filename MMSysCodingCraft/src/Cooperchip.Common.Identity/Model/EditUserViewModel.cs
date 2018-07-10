using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class EditUserViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Nome é Obrigatório!")]
        [MaxLength(35, ErrorMessage = "Máximo de caracteres permitidos: 35")]
        public string NomeCompleto { get; set; }


        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Facebook { get; set; }

        [Display(Name = "Google+")]
        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Google { get; set; }

        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Twitter { get; set; }

        [MaxLength(120, ErrorMessage = "Máximo de caracteres permitidos: 120")]
        public string Skype { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo de caracteres permitidos, com máscara: 15")]
        public string Telefone { get; set; }

        [Display(Name = "Sobre o Usuário")]
        public string AboutMe { get; set; }
    
        [Required]
        [Display(Name = "Usuário")]
        [MaxLength(16, ErrorMessage = "Máximo de Caracter Permitido: 16")]
        public string Usuario { get; set; }


        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectListItem> RolesList { get; set; }

    }

}