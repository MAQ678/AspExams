using InventoryManager.Models.Entities;

namespace InventoryManager.Models
{
    public class FilterProductModel
    {
        public required string ProductName { get; set; }
        public Category? Category { get; set; }
    }
}
