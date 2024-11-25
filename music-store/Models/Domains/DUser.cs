using System;
using System.Collections.Generic;
using System.Text;

namespace music_store.Models.Domains
{
	public class DUser
	{
		public string Login { get; set; } = null!;

		public uint Balance { get; set; }

		public PurchasedRecords PurchasedRecords { get; set;} = null!;
	}
}
