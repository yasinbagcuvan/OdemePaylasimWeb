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
	public class ProductProfile : Profile
	{
        public ProductProfile()
        {
			CreateMap<ProductDto, Product>().ReverseMap();

		}
    }
}
