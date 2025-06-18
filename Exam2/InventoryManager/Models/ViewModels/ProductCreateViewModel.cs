using InventoryManager.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public Category Category { get; set; }

        [Range(0, double.MaxValue, ErrorMessage ="Price must be positive number.")]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
