using Core.Entity;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
	public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
		{
			var query = inputQuery;

			if(spec.Criteria != null)
			{
				query = query.Where(spec.Criteria);
			}

			// this help in cluding the brand and type when a product is search for in the db
			query = spec.Includes.Aggregate(query, (current, Include) => current.Include(Include));

			return query;
		}
	}
}
