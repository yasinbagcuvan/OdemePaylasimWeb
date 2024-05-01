using Microsoft.EntityFrameworkCore;
using OdemePaylasim.Data.Entities;

namespace OdemePaylasim.Data
{
    public class OdemeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public OdemeDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
