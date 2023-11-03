using fatob_new.Models;
using Microsoft.EntityFrameworkCore;

namespace fatob_new.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
            
        }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Travel> Travels { get; set; }

    }
}
