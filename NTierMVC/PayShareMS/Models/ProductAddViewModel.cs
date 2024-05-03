using PayShareMS.Entities;

namespace PayShareMS.Models
{
	public class ProductAddViewModel : ProductEditListViewModel
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		
	}
}
