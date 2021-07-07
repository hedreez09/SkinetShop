using Core.Entity;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task<T> GetEntityWithSpec(ISpecification<T> spec);
		Task<List<T>> ListAsync(ISpecification<T> spec);
		Task<int> CountAsync(ISpecification<T> spec);

	}
}
