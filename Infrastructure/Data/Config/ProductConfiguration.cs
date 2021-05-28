using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		/// <summary>
		/// This is use to configure the entity to specific way as desire by the developer
		/// </summary>
		/// <param name="builder"></param>
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
			//builder.Property(p => p.Descritpion).IsRequired();
			builder.Property(p => p.Price).HasColumnType("decimal(18, 2)");
			builder.Property(p => p.PictureUrl).IsRequired();
			builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
			builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
		}
	}
}
