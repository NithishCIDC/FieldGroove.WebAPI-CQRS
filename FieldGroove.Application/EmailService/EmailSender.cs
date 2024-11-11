using FieldGroove.Domain.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;


namespace FieldGroove.Application.EmailService
{
    public class EmailSender : IEmailSender
    {
        public void EmailSendAsync(string email, string subject, string messageBody, byte[] pdf)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Field Groove", "2k20cse055@kiot.ac.in"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = messageBody };
            bodyBuilder.Attachments.Add(pdf.ToString());

            message.Body=bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("2k20cse055@kiot.ac.in", "2k20cse055");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
