using AutoMapper;
using music_store.Models.Domains;
using music_store.Models.Entities;
using music_store.Services.Interfaces;
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
			CreateMap<User, DTOUser>().ForMember(dest => dest.Login, act => act.MapFrom(src => src.Login));
			CreateMap<PurchaseHistory, PurchasedRecords>().ForMember(dest => dest.User, act => act.MapFrom(src => src.User))
					.ForMember(dest => dest.VinylRecord, act => act.MapFrom(src => src.VinylRecord));
		}

		/*! 
		* @brief Create Configuration Mapper.
		* @return IMapper - Mapper Configuration.
		*/
		public IMapper CreateMapper()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>());
			return config.CreateMapper();
		}
	}
}