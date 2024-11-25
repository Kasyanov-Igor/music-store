namespace music_store.Services.Interfaces
{
	public interface IFactoryMapper<T, N>
	{
		public T AddDomain(N entity);
	}
}
