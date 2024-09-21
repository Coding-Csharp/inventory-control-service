using InventoryControlService.Shared.Domain.Repositories;
using InventoryControlService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace InventoryControlService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork
        (InventoryControlContext context) :
        IUnitOfWork
    {
        public async Task CompleteAsync() =>
            await context.SaveChangesAsync();
    }
}