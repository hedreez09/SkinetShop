using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SkinetShop.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Extensions
{
	public static  class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

			services.Configure<ApiBehaviorOptions>(options =>
			options.InvalidModelStateResponseFactory = actionContext =>
			{
				var errors = actionContext.ModelState
				.Where(e => e.Value.Errors.Count > 0)
				.SelectMany(x => x.Value.Errors)
				.Select(s => s.ErrorMessage).ToArray();


				var errorResponse = new ApiValidationErrorResponse
				{
					Errors = errors
				};

				return new BadRequestObjectResult(errorResponse);

			});

			return services;

		}
	}
}
