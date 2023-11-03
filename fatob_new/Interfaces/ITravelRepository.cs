using fatob_new.Models;

namespace fatob_new.Interfaces
{
    public interface ITravelRepository
    {
        Task<IEnumerable<Travel>> GetAll();
        Task<Travel> GetByIdAsync(int id);
        Task<IEnumerable<Travel>> GetByCities(string cityFrom, string cityTo, DateTime date);
        bool AddTravel(Travel travel);
        bool UpdateTravel(Travel travel);
        bool DeleteTravel(Travel travel);
        bool Save();
    }
}
