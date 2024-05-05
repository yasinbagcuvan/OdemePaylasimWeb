namespace PayShareMS.Models
{
	public class GeneralLedgerEditListViewModel : GeneralLedgerAddViewModel
	{
		public int Id { get; set; }
		public int RowNum { get; set; }
        public PersonEditListViewModel? PayeePerson { get; set; }

        public PersonEditListViewModel? DebtorPerson { get; set; }

        public EventEditListViewModel? Event { get; set; }
        public ProductEditListViewModel? Product { get; set; }
    }
}
