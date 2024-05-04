using PayShareMS.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayShareMS.Models
{
	public class GeneralLedgerAddViewModel 
	{
		public int PayeePersonId { get; set; }
		public int DebtorPersonId { get; set; }
		public int EventId { get; set; }
		public int ProductId { get; set; }
		public PersonEditListViewModel PayeePerson { get; set; }

		public PersonEditListViewModel DebtorPerson { get; set; }

		public EventEditListViewModel Event { get; set; }
		public ProductEditListViewModel Product { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
