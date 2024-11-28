using System;

namespace music_store.Models.Entities
{
	public class PurchaseHistory
	{
		public int Id { get; set; }

		public User User { get; set; } = null!;

		public VinylRecord VinylRecord { get; set; } = null!;

		public DateTime DatePurchase { get; set; }
	}
}