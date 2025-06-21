using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models.Entities
{
    public class ProductEntity : BaseEntity
    {
        public required string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
