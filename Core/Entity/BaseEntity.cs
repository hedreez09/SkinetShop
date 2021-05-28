using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
	/// <summary>
	/// this is the base class for all product entity which help in reducing entity duplication
	/// </summary>
	public class BaseEntity
	{
		public int Id { get; set; }
	}
}
