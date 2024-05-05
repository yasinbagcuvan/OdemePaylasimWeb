using AutoMapper;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Services.Profiles
{
    public class GeneralLedgerProfile : Profile
    {
        public GeneralLedgerProfile() 
        {
            //CreateMap<GeneralLedgerDto, GeneralLedger>().ForMember(dest => dest.DebtorPerson, opt => opt.MapFrom(src => src.DebtorPerson)).MaxDepth(1);
            //CreateMap< GeneralLedger, GeneralLedgerDto>().ForMember(dest => dest.DebtorPerson, opt => opt.MapFrom(src => src.DebtorPerson)).MaxDepth(1);
            
            //CreateMap< GeneralLedgerDto, GeneralLedger>().ForMember(dest => dest.PayeePerson, opt => opt.MapFrom(src => src.PayeePerson)).MaxDepth(1);
            //CreateMap<GeneralLedger, GeneralLedgerDto>().ForMember(dest => dest.PayeePerson, opt => opt.MapFrom(src => src.PayeePerson)).MaxDepth(1);

            //CreateMap< GeneralLedgerDto, GeneralLedger>().ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event)).MaxDepth(1);
            //CreateMap<GeneralLedger, GeneralLedgerDto>().ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event)).MaxDepth(1);

            //CreateMap< GeneralLedgerDto, GeneralLedger>().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).MaxDepth(1);
            //CreateMap<GeneralLedger, GeneralLedgerDto>().ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product)).MaxDepth(1);

            //CreateMap<PersonDto, Person>().ForMember(dest => dest.DebtorGeneralLedgers, opt => opt.Ignore()).MaxDepth(1);
            //CreateMap<Person, PersonDto>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);

            //CreateMap<PersonDto, Person>().ForMember(dest => dest.PayeeGeneralLedgers, opt => opt.Ignore()).MaxDepth(1);
            //CreateMap<Person, PersonDto>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);

            //CreateMap<EventDto, Event>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);
            //CreateMap<Event, EventDto>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);

            //CreateMap<ProductDto, Product>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);
            //CreateMap<Product, ProductDto>().ForMember(dest => dest.GeneralLedgers, opt => opt.Ignore()).MaxDepth(1);


        }
    }
}
