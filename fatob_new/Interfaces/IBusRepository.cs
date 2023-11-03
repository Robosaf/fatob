using fatob_new.Models;

namespace fatob_new.Interfaces
{
    public interface IBusRepository
    {
        Task<IEnumerable<Bus>> GetAll();
        Task<Bus> GetByIdAsync(int id);
        bool AddBus(Bus bus);
        bool DeleteBus(Bus bus);
        bool UpdateBus(Bus bus);
        bool Save();
    }
}
