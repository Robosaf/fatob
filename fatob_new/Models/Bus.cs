using fatob_new.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace fatob_new.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string? RegisterNumber { get; set; }
        public ColorEnum Color { get; set; }
        //public ICollection<Travel> Travels { get; set; }
    }
}
