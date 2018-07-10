using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class VerifyCodeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Provider { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "permitir que este browse guarde sua senha?")]
        public bool RememberBrowser { get; set; }
    }

}
