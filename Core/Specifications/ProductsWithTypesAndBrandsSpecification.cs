using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
	public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
	{
		public ProductsWithTypesAndBrandsSpecification()
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
		}


		/// <summary>
		/// This give the product type and brand of the specified Id base on the criteria given
		/// </summary>
		/// <param name="id"></param>
		public ProductsWithTypesAndBrandsSpecification(int id) : base(p => p.Id== id)
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
		}
	}
}
