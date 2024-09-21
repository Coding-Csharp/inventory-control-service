using InventoryControlService.Commerce.Domain.Model.Aggregates;
using InventoryControlService.Inventory.Domain.Model.Commands.Product;

namespace InventoryControlService.Inventory.Domain.Model.Aggregates
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string State { get; set; }

        public virtual ICollection<Order> Orders { get; } = [];

        public Product
            (string name,
            decimal price, string state)
        {
            this.Name = name;
            this.Price = price;
            this.State = state;
        }

        public Product
            (CreateProductCommand command)
        {
            this.Name = command.Name;
            this.Price = command.Price;
            this.State = command.ProductState.ToString();
        }
    }
}