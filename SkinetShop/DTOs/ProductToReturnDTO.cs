﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.DTOs
{
	public class ProductToReturnDTO
	{
		public int id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string PictureUrl { get; set; }
		public string ProductType { get; set; }
		public string ProductBrand { get; set; }	
	}
}