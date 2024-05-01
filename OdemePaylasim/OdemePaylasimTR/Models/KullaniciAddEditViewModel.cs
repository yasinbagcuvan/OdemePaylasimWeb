using OdemePaylasimTR.Data.Entities;

namespace OdemePaylasimTR.Models
{
	public class KullaniciAddEditViewModel
	{
		public int Id { get; set; }
		public string Ad { get; set; }
		public decimal Bakiye { get; set; }
		public bool IsActive { get; set; }

	}
}
