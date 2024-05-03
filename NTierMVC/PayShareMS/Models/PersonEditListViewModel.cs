using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class PersonEditListViewModel
	{
		public int Id { get; set; }
		public int RowNum { get; set; }
		public ICollection<GeneralLedgerEditListViewModel>? GeneralLedgers { get; set; }
	}
}
