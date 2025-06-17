using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
