using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fatob_new.Models
{
    public class Travel
    {
        [Key]
        public int TravelId { get; set; }
        public string StartCity { get; set; }
        public string EndCity { get; set; }
        [ForeignKey("Bus")]
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public DateTime StartOfTravel { get; set; }
        public DateTime EndOfTravel { get; set; }
        public int Cost { get; set; }
    }
}
