using fatob_new.Interfaces;
using fatob_new.Models;
using System.ComponentModel.DataAnnotations;

namespace fatob_new.HelperModel
{
    public class TicketBuyerModel
    {
        public Travel Travel { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

    }
}
