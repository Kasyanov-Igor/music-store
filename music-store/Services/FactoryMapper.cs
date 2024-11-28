using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class FactoryMapper : IFactoryMapper
	{
		private MapperConfig mapperConfig;

		public FactoryMapper() => mapperConfig = new MapperConfig();

		public void AddDomain()
		{
			mapperConfig.CreateMapper();
		}
	}
}
