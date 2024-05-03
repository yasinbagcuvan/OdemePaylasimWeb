using Microsoft.EntityFrameworkCore;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Context
{
	public class PayShareDbContext : DbContext
	{

        public PayShareDbContext(DbContextOptions<PayShareDbContext> dbContextOptions) : base(dbContextOptions)
		{ }
		public DbSet<Event> Events { get; set; }
		public DbSet<GeneralLedger> GeneralLedgers { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
