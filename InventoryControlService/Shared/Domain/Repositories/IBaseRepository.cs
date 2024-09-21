namespace InventoryControlService.Shared.Domain.Repositories
{
    public interface IBaseRepository
        <TEntity> where TEntity : class
    {
        Task AddAsync
            (TEntity entity);

        void Update
            (TEntity entity);

        void Remove
            (TEntity entity);

        Task<IEnumerable<TEntity>> ListAsync();

        Task<TEntity?> FindByIdAsync(int id);
    }
}