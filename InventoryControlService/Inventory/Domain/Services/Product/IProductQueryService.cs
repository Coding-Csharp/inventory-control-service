using InventoryControlService.Inventory.Domain.Model.Queries.Product;

namespace InventoryControlService.Inventory.Domain.Services.Product
{
    public interface IProductQueryService
    {
        Task<IEnumerable<Model.Aggregates.Product>> Handle
            (GetProductsByNameQuery query);
    }
}