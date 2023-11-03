using ceTe.DynamicPDF;
using fatob_new.HelperModel;

namespace fatob_new.Interfaces
{
    public interface ITicketCreatorService
    {
        public Document CreateTicket(TicketBuyerModel ticketBuyer);
    }
}
