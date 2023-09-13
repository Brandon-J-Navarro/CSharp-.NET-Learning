using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Workers
{
    internal class EnrollmentDetailReportEmailSender
    {
        private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
        private static string _password = _configuration["EmailCredentials:password"];
        private static string _from = _configuration["EmailAddresses:from"];
        private static string _to = _configuration["EmailAddresses:to"];
        public void Send(string fileName)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            NetworkCredential networkCredential = new NetworkCredential(_from, _password);
            client.EnableSsl = true;
            client.Credentials = networkCredential;

            MailMessage message = new MailMessage(_from, _to);
            message.Subject = "Erollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hello,<br><br>Attached is the erollment detail report.<br><br>Please let me know if you have any questions.<br><br>R/S,<br>Brandon";

            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);
            client.Send(message);
        }
    }
}
