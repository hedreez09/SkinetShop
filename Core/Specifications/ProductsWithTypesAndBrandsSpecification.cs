using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
	public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
	{
		public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
			: base(x =>
			(!string.IsNullOrEmpty(productParams.Search) ||x.Name.ToLower().Contains(productParams.Search)) && 
			(!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
			(!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
			)
		{
			AddInclude(x => x.ProductType);
			AddInclude(x => x.ProductBrand);
			AddOrderBy(x => x.Name);
			ApplyPaging(productParams.Pagesize * (productParams.PageIndex - 1), productParams.Pagesize);

			if (!string.IsNullOrEmpty(productParams.sort))// this help in sorting by price Ascending, descending or name  
			{
				switch (productParams.sort)
				{
					case "priceAsc":
						AddOrderBy(p => p.Price);
						break;
					case "priceDesc":
						AddOrderByDescending(p => p.Price);
						break;
					default:
						AddOrderBy(n => n.Name);
						break;
				}
			}
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
