using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.Entities
{
	public class Event : BaseEntity
	{
		public string Name { get; set; }
		public DateTime EventDate { get; set; }
		public ICollection<GeneralLedger>? GeneralLedgers { get; set; }

	}
}
