using AutoMapper;
using music_store.Models.Domains;
using music_store.Models.Entities;
using System;

namespace music_store.Services
{
	public class MapperConfig : Profile
	{
		public static object InitializeAutomapper()
		{
			throw new NotImplementedException();
		}

		public MapperConfig()
		{
			CreateMap<User, DUser>().ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login));
		}

		public IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>());
			return config.CreateMapper();
		}



	}
}
