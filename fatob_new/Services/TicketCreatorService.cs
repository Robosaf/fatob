using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.PageElements;
using fatob_new.HelperModel;
using fatob_new.Interfaces;

namespace fatob_new.Services
{
    public class TicketCreatorService : ITicketCreatorService
    {
        public Document CreateTicket(TicketBuyerModel ticketBuyer)
        {
            Document document = new Document();
            document.Title = "Your Ticket";

            Page page = new Page(PageSize.A4, PageOrientation.Portrait, 53.0f);
            document.Pages.Add(page);

            string ttl = $"Ticket";
            ceTe.DynamicPDF.PageElements.Label label1
                = new ceTe.DynamicPDF.PageElements.Label(ttl, 0, 0, 504, 100, Font.Helvetica, 25, TextAlign.Center);
            page.Elements.Add(label1);


            string htfb = $"Hello, {ticketBuyer.Name} {ticketBuyer.Surname}, thank you for buying ticket with us!";
            ceTe.DynamicPDF.PageElements.Label label2 
                = new ceTe.DynamicPDF.PageElements.Label(htfb, 0, 40, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            page.Elements.Add(label2);

            ceTe.DynamicPDF.PageElements.BarCoding.QrCode qr =
                new ceTe.DynamicPDF.PageElements.BarCoding.QrCode("https://learn.microsoft.com/en-us/", 225, 255);

            page.Elements.Add(qr);

            return document;
        }
    }
}
