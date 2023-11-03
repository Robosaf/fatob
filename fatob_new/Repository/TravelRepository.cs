using fatob_new.Data;
using fatob_new.Interfaces;
using fatob_new.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace fatob_new.Repository
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ApplicationDataContext _context;
        private readonly IBusRepository _busRepository;

        public TravelRepository(ApplicationDataContext context, IBusRepository busRepository)
        {
            _context = context;
            _busRepository = busRepository;
        }
        public bool AddTravel(Travel travel)
        {
            _context.Add(travel);
            return Save();
        }

        public bool DeleteTravel(Travel travel)
        {
            _context.Remove(travel);
            return Save();
        }

        public async Task<IEnumerable<Travel>> GetAll()
        {
            return await _context.Travels.ToListAsync();
        }

        public async Task<IEnumerable<Travel>> GetByCities(string cityFrom, string cityTo, DateTime date)
        {
            return await _context.Travels.Where(t =>
            t.StartCity.ToLower().Trim() == cityFrom.ToLower().Trim()
            && t.EndCity.ToLower().Trim() == cityTo.ToLower().Trim()
            && t.StartOfTravel.Year == date.Year
            && t.StartOfTravel.Month == date.Month
            && t.StartOfTravel.Day == date.Day).ToListAsync();
        }

        public async Task<Travel> GetByIdAsync(int id)
        {
            return await _context.Travels.FirstOrDefaultAsync(t => t.TravelId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTravel(Travel travel)
        {
            _context.Update(travel);
            return Save();
        }
    }
}
