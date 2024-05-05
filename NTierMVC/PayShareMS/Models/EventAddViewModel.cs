using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class EventAddViewModel 
	{
		public string Name { get; set; }
		public DateTime EventDate { get; set; } = DateTime.Now;
		
	}
}
