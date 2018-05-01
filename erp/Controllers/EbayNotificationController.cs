using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using erpcore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp.Controllers
{
    [Produces("application/json")]
    [Route("api/EbayNotification")]
    public class EbayNotificationController : Controller
    {
        private EbayNotificationService m_service;

        public EbayNotificationController(EbayNotificationService service)
        {
            m_service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Process()
        {
            string body = null;
            using (var reader = new StreamReader(Request.Body))
            {
                Task<string> bodyTask = reader.ReadToEndAsync();
                body = await bodyTask;
            }

            /*
            int length = (int)Request.ContentLength;
            byte[] buffer = new byte[length];
            await Request.Body.ReadAsync(buffer, 0, length);
            string body = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            */
            var fromAddress = new MailAddress("sxinxu@gmail.com", "Steve Xu");
            var toAddress = new MailAddress("sxinxu@gmail.com", "Steve Xu");
            const string fromPassword = "Zhuzhu2007";
            const string subject = "Subject";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return Ok();
        }
    }
}