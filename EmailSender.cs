using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using MailKit.Net.Pop3;
using MailKit;
using MimeKit;

namespace BUS.Helpers
{
	public static class EmailSender
	{
		public static void SendMessage(string email,string messages)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("youmu122@gmail.com"));
            message.To.Add(new MailboxAddress("carameruu@gmail.com"));
            message.Subject = "NO REPLY";

            message.Body = new TextPart("plain")
            {
                Text = messages
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 465, true);
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("youmu122@gmail.com", "Ninja950*");
                
                client.Send(message);
                client.Disconnect(true);
            }

        }        
	}
}
