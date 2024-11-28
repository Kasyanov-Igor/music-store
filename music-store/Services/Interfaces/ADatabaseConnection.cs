using Microsoft.EntityFrameworkCore;
using music_store.Models.Entities;

namespace music_store.Services.Interfaces
{
	public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<VinylRecord> VinylRecords => Set<VinylRecord>();

		public DbSet<MusicBand> MusicBands => Set<MusicBand>();

		public DbSet<MusicPublisher> MusicPublishers => Set<MusicPublisher>();

		public DbSet<MusicGenre> MusicGenres => Set<MusicGenre>();

		public DbSet<User> Users => Set<User>();

		public DbSet<Wallet> Balances => Set<Wallet>();

		public DbSet<PurchaseHistory> PurchaseHistories => Set<PurchaseHistory>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();
			this.Database.EnsureCreated();
		}
	}
}