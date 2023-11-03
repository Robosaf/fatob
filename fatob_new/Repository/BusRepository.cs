using fatob_new.Data;
using fatob_new.Interfaces;
using fatob_new.Models;
using Microsoft.EntityFrameworkCore;

namespace fatob_new.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly ApplicationDataContext _context;

        public BusRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public bool AddBus(Bus bus)
        {
            _context.Add(bus);
            return Save();
        }

        public bool DeleteBus(Bus bus)
        {
            _context.Remove(bus);
            return Save();
        }

        public async Task<IEnumerable<Bus>> GetAll()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _context.Buses.FirstOrDefaultAsync(b => b.BusId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBus(Bus bus)
        {
            _context.Update(bus);
            return Save();
        }
    }
}
