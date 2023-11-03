using fatob_new.Models;

namespace fatob_new.HelperModel
{
    public class TravelFindModel
    {
        public IEnumerable<Travel> Travels { get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
