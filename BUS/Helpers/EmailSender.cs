using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BUS.Helpers
{
	public static class EmailSender
	{
		public static void SendMessage(string email, string message)
		{
			SmtpClient smtpClient = new SmtpClient("mail.hostdomain.com", 25); //reconfig mail host vd: mail.google.com

			smtpClient.Credentials = new System.Net.NetworkCredential("admin@mail.com", "IDpassword"); //reconfig ID and password 
			smtpClient.UseDefaultCredentials = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.EnableSsl = true;

			MailMessage mail = new MailMessage();
			mail.Body = message;

			//Setting From , To and CC if needed
			mail.From = new MailAddress("admin@mail.com", "MyWeb Site"); //reconfig ID, displayed name can be reconfigure but not needed
			mail.To.Add(new MailAddress(email));
			//mail.CC.Add(new MailAddress("thu3@mail.com"));
			smtpClient.Send(mail);
		}
	}
}
