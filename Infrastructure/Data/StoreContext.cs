using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
	public class StoreContext:DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
	}
}
