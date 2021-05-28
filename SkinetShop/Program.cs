using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinetShop
{
	public class Program
	{
		/// <summary>
		/// this help in frequent updating of database each time a new migration is done 
		/// It help to apply a new database if it does't exist 
		/// </summary>
		/// <param name="args"></param>
		public static async Task Main(string[] args)
		{
			
			var host = CreateHostBuilder(args).Build();
			// this mean once the method in it is done with its task it get disposed
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();
				try
				{
					var context = services.GetRequiredService<StoreContext>();
					await context.Database.MigrateAsync();
					await StoreContextSeed.SeedAsync(context, loggerFactory);
				}
				catch (Exception ex)
				{
					var logger = loggerFactory.CreateLogger<Program>();
					logger.LogError(ex, "An error occur during migration");
				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
