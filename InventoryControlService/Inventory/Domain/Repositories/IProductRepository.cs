using InventoryControlService.Inventory.Domain.Model.Aggregates;
using InventoryControlService.Shared.Domain.Repositories;

namespace InventoryControlService.Inventory.Domain.Repositories
{
    public interface IProductRepository :
        IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> FindByNameAsync
            (string name);
    }
}