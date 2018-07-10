using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Services
{
    public static class Messages
    {
        public static void EnviarEmail(string toAddress, string subjectText, string bodyText)
        {
            //var mailSettings = ConfigurationManager.AppSettings["system.net"];
            MailMessage newMessage = new MailMessage();
            MailAddress senderAddress = new MailAddress("evolumedsys@gmail.com");
            MailAddress recipentAddress = new MailAddress(toAddress);

            newMessage.To.Add(recipentAddress);
            newMessage.From = senderAddress;
            newMessage.Subject = subjectText;
            newMessage.Body = bodyText;
            newMessage.BodyEncoding = System.Text.Encoding.UTF8;
            newMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["credencialemail"].ToString(), ConfigurationManager.AppSettings["credencialemailpassword"].ToString())
            };
            client.Send(newMessage);
        }
    }
}
