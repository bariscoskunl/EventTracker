using EventTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTracker.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<EventModel> Events { get; set; }

       

    }
}
