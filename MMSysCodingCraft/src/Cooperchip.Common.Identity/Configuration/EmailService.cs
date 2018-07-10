using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Cooperchip.Common.Identity.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}
