using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Perfil")]
        public string Name { get; set; }
    }

}