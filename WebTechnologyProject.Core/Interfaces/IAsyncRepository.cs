using System;
using System.Collections.Generic;
using System.Text;
using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace WebTechnologyProjectCore.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity: BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification);
    }
}
