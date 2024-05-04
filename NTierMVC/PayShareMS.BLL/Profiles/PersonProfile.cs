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
	public class PersonProfile : Profile
	{
        public PersonProfile()
        {
			CreateMap<PersonDto, Person>().ReverseMap();


			//CreateMap<PersonDto, Person>()
			//		.ForMember(dest => dest.GeneralLedgers, opt => opt.MapFrom(src => src.GeneralLedgers))
			//		.ReverseMap();
		}
    }
}
