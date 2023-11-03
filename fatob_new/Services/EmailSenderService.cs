using fatob_new.HelperModel;
using fatob_new.Interfaces;
using System.Net;
using System.Net.Mail;

namespace fatob_new.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly ITicketCreatorService _ticketCreatorService;

        public EmailSenderService(ITicketCreatorService ticketCreatorService)
        {
            _ticketCreatorService = ticketCreatorService;
        }

        public Task SendEmailAsync(TicketBuyerModel ticketBuyer)
        {
            string mail = "robert.safonov.job@gmail.com";
            string password = "cnhn mzlw dcye rzrs";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };

            MailMessage mailMessage = new MailMessage(from: mail,
                to: ticketBuyer.Email,
                subject: "Ticket",
                body: "Test Ticket");

            var document = _ticketCreatorService.CreateTicket(ticketBuyer);

            MemoryStream memoryStream = new MemoryStream();

            document.Draw(memoryStream);

            memoryStream.Position = 0;
            Attachment attachment = new Attachment(memoryStream, "PdfAttachment.pdf", "application/pdf");

            mailMessage.Attachments.Add(attachment);

            return client.SendMailAsync(mailMessage);
        }
    }
}
