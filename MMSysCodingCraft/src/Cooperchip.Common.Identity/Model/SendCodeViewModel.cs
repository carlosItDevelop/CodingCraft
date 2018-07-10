using System.Collections.Generic;
using System.Web.Mvc;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SendCodeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string SelectedProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SelectListItem> Providers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReturnUrl { get; set; }
    }

}
