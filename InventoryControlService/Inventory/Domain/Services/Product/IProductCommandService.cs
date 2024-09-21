using InventoryControlService.Inventory.Domain.Model.Commands.Product;

namespace InventoryControlService.Inventory.Domain.Services.Product
{
    public interface IProductCommandService
    {
        Task<bool> Handle
            (CreateProductCommand command);
    }
}