using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop.Errors
{
	public class ApiResponse
	{
		public ApiResponse(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}

		public int StatusCode { get; set; }
		public string Message { get; set; }

		private string GetDefaultMessageForStatusCode(int statuscode)
		{
			return statuscode switch
			{
				400 => "A bad request, you have made ",
				401 => "Authorized, you are not",
				404 => "Resource found, it was not ",
				500 => "Error are path to the dark side. Error leads to anger. Anger leads hate and hate leads to career change",
				_ => null
			};
		}
	}
}
