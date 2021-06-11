using AutoMapper;
using Core;
using SkinetShop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Helpers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductToReturnDTO>()
				.ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)) // this give the productbrand 
				.ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name)) // this give the productType
				.ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>()); //this give access to the Picture Url
		}
	}
}
