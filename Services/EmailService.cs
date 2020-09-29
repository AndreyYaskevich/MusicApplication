using MailKit.Net.Smtp;
using MimeKit;

namespace MusicApplication.Services
{
    public class EmailService
    {
        public static void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MusicSite", "andrez-yaskevich@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("Hi", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {

                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("andrez-yaskevich@mail.ru", "velikiyproebwik6");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
