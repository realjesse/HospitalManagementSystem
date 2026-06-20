namespace HospitalServer.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int MinimumStockLevel { get; set; }
        public string? Unit { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}