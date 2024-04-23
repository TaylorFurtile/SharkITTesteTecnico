using Microsoft.EntityFrameworkCore;
using SharkITTesteTecnico.Domain.Entities;
using SharkITTesteTecnico.Infrastructure.Data.Context;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure.Data.Repositories
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Set<TEntity>()
                .Where(entity => entity.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>()
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
