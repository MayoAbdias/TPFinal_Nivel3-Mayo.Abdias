using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Services
{
    public class EmailServices
    {
        private SmtpClient server;
        private MailMessage email;

        public EmailServices()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("mayoezequiel99@gmail.com", "gkwd rnkj mmep dnmd");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino,string asunto,string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@Tutiendavirtual.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.Body = cuerpo;
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
