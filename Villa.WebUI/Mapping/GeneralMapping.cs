using AutoMapper;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<ResultBannerDto, Banner>().ReverseMap();
			CreateMap<UpdateBannerDto, Banner>().ReverseMap();
			CreateMap<CreateBannerDto, Banner>().ReverseMap();

			CreateMap<ResultContactDto, Contact>().ReverseMap();
			CreateMap<UpdateContactDto, Contact>().ReverseMap();
			CreateMap<CreateContactDto, Contact>().ReverseMap();

			CreateMap<ResultCounterDto, Counter>().ReverseMap();
			CreateMap<UpdateCounterDto, Counter>().ReverseMap();
			CreateMap<CreateCounterDto, Counter>().ReverseMap();
		}
	}
}
