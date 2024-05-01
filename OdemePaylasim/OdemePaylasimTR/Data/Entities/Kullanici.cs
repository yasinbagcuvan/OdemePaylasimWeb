namespace OdemePaylasimTR.Data.Entities
{
	public class Kullanici : Entity
	{
		public string Ad { get; set; }
		public decimal Bakiye { get; set; }
		public int AlisverisId { get; set; }
		public Alisveris Alisveris { get; set; }
	}
}
