using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class ProductEditListViewModel : ProductAddViewModel
	{
		public int Id { get; set; }
		public int RowNum { get; set; }
		public ICollection<GeneralLedgerEditListViewModel>? GeneralLedgers { get; set; }
	}
}
