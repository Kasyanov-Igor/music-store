using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class UserService : IUserService
	{
		private ADatabaseConnection _databaseConnection;

		IFactoryMapper<DUser, User> factoryMapper;
		public UserService(ADatabaseConnection aDatabaseConnection)
		{
			this._databaseConnection = aDatabaseConnection;
			factoryMapper = new FactoryMapper<DUser,User>();
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

		public bool BuyVinylRecord(User user, VinylRecord vinylRecord)
		{
			DUser dUser = factoryMapper.AddDomain(user);

			try
			{
				if (dUser.Balance >= vinylRecord.CostPrice)
				{
					dUser.Balance -= vinylRecord.CostPrice;


					this._databaseConnection.PurchaseHistories.Add(new PurchaseHistory() { User = user, VinylRecord = vinylRecord,  DateTime = DateTime.Now });
					this._databaseConnection.SaveChanges();

					//PurchasedRecords purchased = factoryMapper.AddDomain(this._databaseConnection.PurchaseHistories.FirstOrDefault());

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
