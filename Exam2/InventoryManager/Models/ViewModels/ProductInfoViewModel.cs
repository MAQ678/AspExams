using InventoryManager.Models.Entities;

namespace InventoryManager.Models.ViewModels
{
    public class ProductInfoViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Category Category { get; set; }
        public required double Price { get; set; }
        public int Quantity { get; set; }
        public QuantityStatus Status { get; set; }
    }
}
