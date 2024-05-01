using Microsoft.EntityFrameworkCore;
using OdemePaylasimTR.Data.Entities;
using OdemePaylasimTR.Models;

namespace OdemePaylasimTR.Data
{
	public class OdemePaylasimDbContext : DbContext
	{
		
		public OdemePaylasimDbContext(DbContextOptions options) : base(options)
		{

		}
	public DbSet<Kullanici> Kullanicilar { get; set; }
	public DbSet<Alisveris> Alisverisler { get; set; }
	    public DbSet<OdemePaylasimTR.Models.AlisverisAddEditViewModel> AlisverisAddEditViewModel { get; set; } = default!;
	    public DbSet<OdemePaylasimTR.Models.KullaniciAddEditViewModel> KullaniciAddEditViewModel { get; set; } = default!;

	}
}
