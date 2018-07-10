using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SetPasswordViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter no mínimo 6 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha")]
        [Compare("NewPassword", ErrorMessage = "Nova senha e confirmação de senha não considem.")]
        public string ConfirmPassword { get; set; }
    }
}