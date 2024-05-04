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
		//private bool _WithoutOptions=false;
  //      public PayShareDbContext()
  //      {
		//	_WithoutOptions = true;

		//}
        public PayShareDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{ }
		public DbSet<Event> Events { get; set; }
		public DbSet<GeneralLedger> GeneralLedgers { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Person>().HasMany(p => p.DebtorGeneralLedgers).WithOne(gl => gl.DebtorPerson).HasForeignKey(g => g.DebtorPersonId);
			modelBuilder.Entity<Person>().HasMany(p => p.PayeeGeneralLedgers).WithOne(gl => gl.PayeePerson).HasForeignKey(g => g.PayeePersonId);
		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	if (_WithoutOptions)
		//	{
		//		base.OnConfiguring(optionsBuilder);
		//		optionsBuilder.UseSqlServer("Data Source=DESKTOP-SNI2HD0\\MSSQLSERVERYASN;Initial Catalog=PayShareDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");
		//	}

		//}
	}
	
}
