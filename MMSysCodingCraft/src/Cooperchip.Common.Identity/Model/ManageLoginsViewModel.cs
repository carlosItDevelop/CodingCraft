using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ManageLoginsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}