using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 
        /// </summary>        
        [Required]
        [Display(Name = "Usuário")]
        [MaxLength(16, ErrorMessage = "Máximo de Caracter Permitido: 16")]
        public string Usuario { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Required]
        //[Display(Name = "Email")]
        //[EmailAddress]
        //public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Lembar?")]
        public bool RememberMe { get; set; }
    }

}