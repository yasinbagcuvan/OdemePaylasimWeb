namespace OdemePaylasimTR.Data.Entities
{
	public class Alisveris : Entity
	{
		public string Ad {  get; set; }
		public decimal Tutar { get; set; }
		public ICollection<Kullanici> Kullanicilar { get; set; }
	}
}
