using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PayShare.DAL.Context;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Person>().HasMany(p => p.DebtorGeneralLedgers).WithOne(gl => gl.DebtorPerson).HasForeignKey(g => g.DebtorPersonId);
			modelBuilder.Entity<Person>().HasMany(p => p.PayeeGeneralLedgers).WithOne(gl => gl.PayeePerson).HasForeignKey(g => g.PayeePersonId);
		}
	}
}
