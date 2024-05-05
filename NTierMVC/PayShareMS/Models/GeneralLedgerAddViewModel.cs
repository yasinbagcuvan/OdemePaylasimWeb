using PayShareMS.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayShareMS.Models
{
	public class GeneralLedgerAddViewModel 
	{
		[Display(Name ="PayeeName")]
		public int PayeePersonId { get; set; }
        [Display(Name = "DebtorName")]
        public int DebtorPersonId { get; set; }
        [Display(Name = "EventName")]
        public int EventId { get; set; }
        [Display(Name = "ProductName")]
        public int ProductId { get; set; }

		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
