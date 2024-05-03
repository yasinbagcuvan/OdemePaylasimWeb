using PayShareMS.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayShareMS.Models
{
	public class GeneralLedgerAddViewModel : GeneralLedgerEditListViewModel
	{

		public PersonEditListViewModel PayeePerson { get; set; }

		public PersonEditListViewModel DebtorPerson { get; set; }

		public EventEditListViewModel Event { get; set; }
		public ProductEditListViewModel Product { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
