using InventoryControlService.Inventory.Domain.Model.ValueObjects.Product;

namespace InventoryControlService.Inventory.Domain.Model.Commands.Product
{
    public record CreateProductCommand
        (string Name, decimal Price, EProductState ProductState);
}