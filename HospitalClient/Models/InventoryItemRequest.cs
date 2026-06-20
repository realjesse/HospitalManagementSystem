namespace HospitalClient.Models
{
    public class InventoryItemRequest
    {
        public string ItemName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int MinimumStockLevel { get; set; }
        public string Unit { get; set; }
    }
}