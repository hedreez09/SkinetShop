using Microsoft.AspNetCore.Mvc;
using SkinetShop.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Controllers
{
	[Route("errors/{code}")]
	public class ErrorController : BaseApiController
	{
		public IActionResult Error(int code)
		{
			return new ObjectResult(new ApiResponse(code));
		}
	}
}
