using AutoMapper;
using Core;
using Microsoft.Extensions.Configuration;
using SkinetShop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Helpers
{ 
	/// <summary>
	/// This help to handle the picture Url by changing it to string from the source then to the destination
	/// </summary>
	public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
	{
		private readonly IConfiguration _config;

		public ProductUrlResolver(IConfiguration config)// this gives us access to config and the ApiUrl 
		{
			_config = config;
		}

		public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
			{
				return _config["ApiUrl"] + source.PictureUrl;
			}

			return null;
		}
	}
}
