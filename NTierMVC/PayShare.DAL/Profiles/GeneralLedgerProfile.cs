using AutoMapper;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.BLL.Profiles
{
	public class GeneralLedgerProfile : Profile
	{
        public GeneralLedgerProfile()
        {
			CreateMap<PersonDto, Person>().ReverseMap();
			CreateMap<EventDto, Event>().ReverseMap();
			CreateMap<ProductDto, Product>().ReverseMap();
			CreateMap<GeneralLedgerDto, GeneralLedger>().ReverseMap();


			//CreateMap<GeneralLedgerDto, GeneralLedger>()
			//	.ForMember(dest => dest.DebtorPerson, opt => opt.MapFrom(src => src.DebtorPerson))
			//	.ReverseMap();
			//	CreateMap<GeneralLedgerDto, GeneralLedger>()
			//	.ForMember(dest => dest.DebtorPersonId, opt => opt.MapFrom(src => src.DebtorPersonId))
			//	.ReverseMap();
			//CreateMap<GeneralLedgerDto, GeneralLedger>()
			//	.ForMember(dest => dest.PayeePersonId, opt => opt.MapFrom(src => src.PayeePersonId))
			//	.ReverseMap();
			//CreateMap<GeneralLedgerDto, GeneralLedger>()
			//		.ForMember(dest => dest.PayeePerson, opt => opt.MapFrom(src => src.PayeePerson))
			//		.ReverseMap();
			//CreateMap<GeneralLedgerDto, GeneralLedger>()
			//	.ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event))
			//	.ReverseMap();
			//CreateMap<GeneralLedgerDto, GeneralLedger>()
			//		.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
			//		.ReverseMap();
		}
    }
}
