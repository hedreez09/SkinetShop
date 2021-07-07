using AutoMapper;
using Core;
using Core.Interface;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinetShop.DTOs;
using SkinetShop.Errors;
using SkinetShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Controllers
{
   
    public class ProductsController : BaseApiController
    {
		private readonly IGenericRepository<Product> _productsRepo;
		private readonly IGenericRepository<ProductBrand> _productBrandRepo;
		private readonly IGenericRepository<ProductType> _productTypeRepo;
		private readonly IMapper _mapper;

		public ProductsController(IGenericRepository<Product> productRepo, 
            IGenericRepository<ProductBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
			_productsRepo = productRepo;
			_productBrandRepo = productBrandRepo;
			_productTypeRepo = productTypeRepo;
			_mapper = mapper;
		}

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts([FromQuery]ProductSpecParams productParams)
        { 
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);// the give counts of items

            var totalItems = await _productsRepo.CountAsync(countSpec);
           
            var product = await _productsRepo.ListAsync(spec);
            var data = _mapper.Map<List<Product>, List<ProductToReturnDTO>>(product);

            return Ok(new Pagination<ProductToReturnDTO>(productParams.PageIndex,
                productParams.Pagesize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product= await _productsRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDTO>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {

            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
