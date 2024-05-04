using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.Entities
{
	public class Person : BaseEntity
	{
		public string Name {  get; set; }
		public string Surname { get; set; }
		public ICollection<GeneralLedger>? DebtorGeneralLedgers { get; set; }
		public ICollection<GeneralLedger>? PayeeGeneralLedgers { get; set; }
	}
}
