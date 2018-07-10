using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterViewModel
    {



        [Display(Name = "Nome Completo")]
        //[Required(ErrorMessage = "Campo Nome é Obrigatório!")]
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

        /// <summary>
        /// 
        /// </summary>        
        [Required]
        [Display(Name = "Usuário")]
        [MaxLength(16, ErrorMessage = "Máximo de Caracter Permitido: 16")]
        public string Usuario { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter um mínimo de {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não considem.")]
        public string ConfirmPassword { get; set; }


    }
}