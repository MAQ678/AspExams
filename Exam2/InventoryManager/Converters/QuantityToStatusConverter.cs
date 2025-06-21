using InventoryManager.Models.ViewModels;

namespace InventoryManager.Converters
{
    public static class QuantityToStatusConverter
    {
        public static QuantityStatus Convert(int quantity)
        {
            if (quantity == 0)
                return QuantityStatus.OutOfStock;
            else if (quantity < 10)
                return QuantityStatus.LowStock;
            return QuantityStatus.InStock;
        }
    }
}
