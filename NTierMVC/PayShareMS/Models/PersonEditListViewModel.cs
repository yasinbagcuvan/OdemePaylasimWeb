using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class PersonEditListViewModel : PersonAddViewModel
	{
		public int Id { get; set; }
		public int RowNum { get; set; }
		public ICollection<GeneralLedgerEditListViewModel>? GeneralLedgers { get; set; }
	}
}
