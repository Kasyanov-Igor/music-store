using music_store.Services.Interfaces;

namespace music_store.Services
{
	public class FactoryMapper<T, N> : IFactoryMapper<T, N>
	{
		private MapperConfig mapperConfig;

		public FactoryMapper() => mapperConfig = new MapperConfig();

		public T AddDomain(N entity)
		{
			return mapperConfig.CreateMapper().Map<T>(entity);
		}

	}
}
