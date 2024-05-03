using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.Entities
{
	public class GeneralLedger : BaseEntity
	{
		public int PayeePersonId { get; set; }

		[ForeignKey("PayeePersonId")]
		public Person PayeePerson { get; set; }
		public int DebtorPersonId { get; set; }
		[ForeignKey("DebtorPersonId")]
		public Person DebtorPerson { get; set; }
		public int EventId { get; set; }
		public Event Event { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
