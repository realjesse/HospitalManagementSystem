using HospitalServer.Data;
using HospitalServer.DTOs;
using HospitalServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalServer.Services
{
    public class InventoryService
    {
        private readonly HospitalDbContext _db;

        public InventoryService(HospitalDbContext db)
        {
            _db = db;
        }

        public async Task<List<InventoryItemResponse>> GetAllAsync()
        {
            return await _db.InventoryItems
                .OrderBy(i => i.ItemName)
                .Select(i => ToResponse(i))
                .ToListAsync();
        }

        public async Task<InventoryItemResponse?> GetByIdAsync(int inventoryItemId)
        {
            var item = await _db.InventoryItems
                .FirstOrDefaultAsync(i => i.InventoryItemId == inventoryItemId);

            return item == null ? null : ToResponse(item);
        }

        public async Task<InventoryItemResponse> CreateAsync(InventoryItemRequest request)
        {
            var item = new InventoryItem
            {
                ItemName = request.ItemName,
                Category = request.Category,
                Quantity = request.Quantity,
                MinimumStockLevel = request.MinimumStockLevel,
                Unit = request.Unit,
                LastUpdated = DateTime.UtcNow
            };

            _db.InventoryItems.Add(item);
            await _db.SaveChangesAsync();

            return ToResponse(item);
        }

        public async Task<InventoryItemResponse?> UpdateAsync(int inventoryItemId, InventoryItemRequest request)
        {
            var item = await _db.InventoryItems
                .FirstOrDefaultAsync(i => i.InventoryItemId == inventoryItemId);

            if (item == null)
            {
                return null;
            }

            item.ItemName = request.ItemName;
            item.Category = request.Category;
            item.Quantity = request.Quantity;
            item.MinimumStockLevel = request.MinimumStockLevel;
            item.Unit = request.Unit;
            item.LastUpdated = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return ToResponse(item);
        }

        public async Task<bool> DeleteAsync(int inventoryItemId)
        {
            var item = await _db.InventoryItems
                .FirstOrDefaultAsync(i => i.InventoryItemId == inventoryItemId);

            if (item == null)
            {
                return false;
            }

            _db.InventoryItems.Remove(item);
            await _db.SaveChangesAsync();

            return true;
        }

        private static InventoryItemResponse ToResponse(InventoryItem item)
        {
            return new InventoryItemResponse
            {
                InventoryItemId = item.InventoryItemId,
                ItemName = item.ItemName,
                Category = item.Category,
                Quantity = item.Quantity,
                MinimumStockLevel = item.MinimumStockLevel,
                Unit = item.Unit,
                LastUpdated = item.LastUpdated,
                IsLowStock = item.Quantity <= item.MinimumStockLevel
            };
        }
    }
}