using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TwoFactor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool BrowserRemembered { get; set; }

        /// <summary>
        /// Customizei para pegar os dados na Controller
        /// </summary>
        public ApplicationUser UsuariosDados { get; set; }


    }
}