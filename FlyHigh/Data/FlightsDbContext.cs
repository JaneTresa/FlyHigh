using FlyHigh.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FlyHigh.Data
{
    public class FlightsDbContext: DbContext
    {
        public FlightsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Flight> Flight { get; set; }
    }
}
