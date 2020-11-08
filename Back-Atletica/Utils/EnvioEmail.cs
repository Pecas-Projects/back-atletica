using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Back_Atletica.Utils
{
    public class EnvioEmail
    {
        /*
        * Exemplo de uso da funcionalidade ->
        * MailSender mail = new MailSender("TesteNameSender", "emailenvioteste@gmail.com", "Alfonso", "emailrecebeteste@gmail.com", "Teste De envio");
        * mail.CreateEmail();
        * mail.ConnectSMTPServer("smtp.gmail.com", 587, "emailenvioteste@gmail.com", "senhaemail");
        * mail.SendEmail();
       */
        MimeMessage Mensagem = new MimeMessage();
        MailboxAddress De = null;
        MailboxAddress Para = null;
        BodyBuilder bodyBuilder = new BodyBuilder();
        SmtpClient Client = new SmtpClient();

        public EnvioEmail(String NameSender, String EmailSender, String NameReceiver, String EmailReceiver, String Subject)
        {
            this.De = new MailboxAddress(NameSender, EmailSender);
            this.Para = new MailboxAddress(NameReceiver, EmailReceiver);

            this.Mensagem.From.Add(De);
            this.Mensagem.To.Add(Para);
            this.Mensagem.Subject = Subject;
        }

        public void CreateEmail(string title, string body)
        {
            this.bodyBuilder.HtmlBody = body;
            this.bodyBuilder.TextBody = title;
            Mensagem.Body = bodyBuilder.ToMessageBody();
        }

        public void ConnectSMTPServer(String SmtpAddress, int Port, String Username, String Password)
        {
            Client.Connect(SmtpAddress, Port, SecureSocketOptions.StartTls);

            NetworkCredential cred = new NetworkCredential(Username, Password);
            Client.Authenticate(cred);
        }

        public void SendEmail()
        {
            Client.Send(Mensagem);
            Client.Disconnect(true);
            Client.Dispose();
        }

    }
}
