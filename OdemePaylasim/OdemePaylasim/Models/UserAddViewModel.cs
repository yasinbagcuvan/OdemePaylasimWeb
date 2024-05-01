namespace OdemePaylasim.Models
{
    public class UserAddViewModel
    {
        public string UserName { get; set; }
        public decimal PaidMoney { get; set; } = 0;
        public bool IsActive { get; set; }
    }
}
