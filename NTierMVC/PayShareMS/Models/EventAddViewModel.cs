using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class EventAddViewModel : EventEditListViewModel
	{
		public string Name { get; set; }
		public DateTime EventDate { get; set; }
		
	}
}
