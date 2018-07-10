using System.Collections.Generic;
using System.Web.Mvc;

namespace Cooperchip.Common.Identity.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigureTwoFactorViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string SelectedProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SelectListItem> Providers { get; set; }
    }
}