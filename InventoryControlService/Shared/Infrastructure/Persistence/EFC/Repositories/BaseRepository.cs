using Microsoft.EntityFrameworkCore;
using InventoryControlService.Shared.Domain.Repositories;
using InventoryControlService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace InventoryControlService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository
        <TEntity>(InventoryControlContext context) :
        IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly InventoryControlContext Context = context;

        public async Task AddAsync(TEntity entity) =>
            await Context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) =>
            Context.Set<TEntity>().Update(entity);

        public void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> ListAsync() =>
            await Context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> FindByIdAsync
            (int id) => await Context.Set<TEntity>()
            .FindAsync(id);
    }
}