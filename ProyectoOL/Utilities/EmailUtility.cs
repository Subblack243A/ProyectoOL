using System;
using System.Net;
using System.Net.Mail;

namespace ProyectoOL.Utilities
{
    public class EmailUtility
    {
        private SmtpClient cliente;
        private MailMessage email;
        private string Host = "smtp.gmail.com";
        private int Port = 587;
        private string User = "openlibrarynotify@gmail.com";
        private string Password = "ciaxznzmzyiulxgt";
        private bool EnabledSSL = true;

        public EmailUtility()
        {
            cliente = new SmtpClient(Host, Port)
            {
                EnableSsl = EnabledSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(User, Password)
            };
        }

        public void SendEmail(string destino, string asunto, string mensaje, bool esHtml)
        {
            try
            {
                email = new MailMessage(User, destino, asunto, mensaje);
                email.IsBodyHtml = esHtml;
                cliente.Send(email);
            }catch(Exception ex)
            {
                string m = ex.Message;
            }
            
        }
    }
}