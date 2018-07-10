using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Cooperchip.Common.Identity.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
