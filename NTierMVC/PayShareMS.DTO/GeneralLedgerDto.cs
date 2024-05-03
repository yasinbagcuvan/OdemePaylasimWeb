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
		public int PayeePersonId { get; set; }
		public int DebtorPersonId { get; set; }
		public int EventId { get; set; }
		public int ProductId { get; set; }
		public decimal Amount { get; set; }
		public bool IsPaid { get; set; }
	}
}
