using InventoryControlService.Inventory.Domain.Model.Aggregates;

namespace InventoryControlService.Commerce.Domain.Model.Aggregates
{
    public class Order
    {
        public int Id { get; }

        public int ProductsId { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }


        public virtual Product? Product { get; }
    }
}