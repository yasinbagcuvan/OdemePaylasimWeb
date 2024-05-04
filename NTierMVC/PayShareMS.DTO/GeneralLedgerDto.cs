using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.DTO
{
	public class GeneralLedgerDto : BaseDto
	{
		[ForeignKey("PayeePersonId")]
		public  PersonDto PayeePerson { get; set; }
		public int PayeePersonId { get; set; }
		[ForeignKey("DebtorPersonId")]
		public  PersonDto DebtorPerson { get; set; }
		public int DebtorPersonId { get; set; }
		public EventDto Event { get; set; }
		public int EventId { get; set; }
		public ProductDto Product { get; set; }
		public int ProductId { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
