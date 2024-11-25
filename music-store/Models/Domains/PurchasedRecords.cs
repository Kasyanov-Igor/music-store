using music_store.Models.Entities;

namespace music_store.Models.Domains
{
	public class PurchasedRecords
	{
		public User User { get; set; } = null!;

		public VinylRecord VinylRecord { get; set; } = null!;
	}
}
