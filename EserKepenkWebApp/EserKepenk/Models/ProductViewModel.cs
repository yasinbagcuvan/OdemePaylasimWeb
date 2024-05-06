namespace EserKepenk.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public CategoryViewModel Category { get; set; }
        public int CategoryId { get; set; }
    }
}
