namespace PayShareMS.Models
{
	public class EventEditListViewModel
	{
		public int Id { get; set; }
		public int RowNum { get; set; }
		public ICollection<GeneralLedgerEditListViewModel>? GeneralLedgers { get; set; }
	}
}
