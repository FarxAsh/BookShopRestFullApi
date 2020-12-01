using WebTechnologyProjectCore.Interfaces;
using WebTechnologyProjectCore.Entities;
using System.Threading.Tasks;
using Ardalis.Specification;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using System.Linq;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebTechnologyProjectInfrastructure.Data
{
    public class EFRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ShopDbContext dbContext;

        public EFRepository(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Guard.Against.Null(entity, nameof(TEntity));
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Guard.Against.Null(entity, nameof(TEntity));
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification)
        {
            var query = ApplySpecification(specification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            var query = ApplySpecification(specification);
            return await query.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;

        }

        protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator<TEntity>();
            return evaluator.GetQuery(dbContext.Set<TEntity>().AsQueryable(), specification);
        }
    }
}
