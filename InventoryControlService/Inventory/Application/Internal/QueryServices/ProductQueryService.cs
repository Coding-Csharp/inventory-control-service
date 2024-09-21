using InventoryControlService.Inventory.Domain.Model.Aggregates;
using InventoryControlService.Inventory.Domain.Model.Queries.Product;
using InventoryControlService.Inventory.Domain.Repositories;
using InventoryControlService.Inventory.Domain.Services.Product;

namespace InventoryControlService.Inventory.Application.Internal.QueryServices
{
    public class ProductQueryService
        (IProductRepository productRepository) :
        IProductQueryService
    {
        public async Task<IEnumerable<Product>> Handle
            (GetProductsByNameQuery query) =>
            await productRepository.FindByNameAsync(query.Name);
    }
}