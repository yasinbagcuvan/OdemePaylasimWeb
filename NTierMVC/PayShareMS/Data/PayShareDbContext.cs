using Microsoft.EntityFrameworkCore;
using PayShareMS.Entities;

namespace PayShareMS.Data
{

	public class PayShareDbContext : DbContext
	{
		public PayShareDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{ }
		public DbSet<Event> Events { get; set; }
		public DbSet<GeneralLedger> GeneralLedgers { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
