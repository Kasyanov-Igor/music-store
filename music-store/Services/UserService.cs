using System;
using System.Linq;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class UserService : IUserService
	{
		private ADatabaseConnection _databaseConnection;

		private IFactoryMapper _factoryMapper;
		public UserService(ADatabaseConnection aDatabaseConnection, IFactoryMapper factoryMapper)
		{
			this._databaseConnection = aDatabaseConnection;
			this._factoryMapper = factoryMapper;
		}

		public bool AddUser(User user)
		{
			try
			{
				User? findedUser = this.FindUser(user);

				if (findedUser == null)
				{
					this._databaseConnection.Users.Add(user);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public User? FindUser(User user)
		{
			try
			{
				return this._databaseConnection.Users.Where(usr =>
				usr.Login == user.Login &&
				usr.Password == user.Password).FirstOrDefault();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return null;
		}

		public bool DeleteUser(User user)
		{
			try
			{
				User? findedUser = this.FindUser(user);

				if (findedUser != null)
				{
					this._databaseConnection.Users.Remove(findedUser);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		/*! 
		* @brief Buying a record, charging money from the user's balance.
		* @param[in] vinylRecord - purchasable record.
		* @param[in] user - record buyer.
		* @return True - record purchased; False - record not purchased.
		*/
		public bool BuyVinylRecord(User user, VinylRecord vinylRecord)
		{
			DTOUser DomainsUser = this._factoryMapper.GetMapperConfig().CreateMapper().Map<DTOUser>(user);  //!< Data entry into the domain model.

			try
			{
				if (DomainsUser.Wallet.BalanceUser >= vinylRecord.CostPrice)
				{
					DomainsUser.Wallet.BalanceUser -= vinylRecord.CostPrice; //!< Write - off of funds from the balance.

					PurchaseHistory history = new PurchaseHistory() { User = user, VinylRecord = vinylRecord, DatePurchase = DateTime.Now };

					PurchasedRecords records = this._factoryMapper.GetMapperConfig().CreateMapper().Map<PurchasedRecords>(history);  //!< Data entry into the domain model.

					this._databaseConnection.PurchaseHistories.Add(history);
					this._databaseConnection.SaveChanges();

					return true;
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}
	}
}