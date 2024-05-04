using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.DTO
{
	public class EventDto : BaseDto
	{
		public string Name { get; set; }
		public DateTime EventDate { get; set; }
		public ICollection<GeneralLedgerDto> GeneralLedgers { get; set; }
	}
}
