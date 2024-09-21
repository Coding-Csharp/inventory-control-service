using InventoryControlService.Inventory.Domain.Model.Commands.Product;
using InventoryControlService.Inventory.Domain.Repositories;
using InventoryControlService.Inventory.Domain.Services.Product;
using InventoryControlService.Shared.Domain.Repositories;

namespace InventoryControlService.Inventory.Application.Internal.CommandServices
{
    public class ProductCommandService
        (IProductRepository productRepository,
        IUnitOfWork unitOfWork) :
        IProductCommandService
    {
        public async Task<bool> Handle
            (CreateProductCommand command)
        {
            try
            {
                await productRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}