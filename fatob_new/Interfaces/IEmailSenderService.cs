using fatob_new.HelperModel;

namespace fatob_new.Interfaces
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(TicketBuyerModel ticketBuyer);
    }
}
