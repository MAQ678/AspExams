using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
