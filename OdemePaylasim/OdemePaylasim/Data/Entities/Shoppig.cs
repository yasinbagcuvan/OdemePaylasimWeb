namespace OdemePaylasim.Data.Entities
{
    public class Shoppig : Entity
    {
        public string ShopName { get; set; }
        public decimal TotalBalance { get; set; }
        public List<User> Users { get; set; }
    }
}
