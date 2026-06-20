using HospitalServer.DTOs;
using HospitalServer.Hubs;
using HospitalServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HospitalServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        private readonly IHubContext<HospitalHub> _hubContext;

        public InventoryController(
            InventoryService inventoryService,
            IHubContext<HospitalHub> hubContext)
        {
            _inventoryService = inventoryService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<InventoryItemResponse>>> GetAll()
        {
            var items = await _inventoryService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemResponse>> GetById(int id)
        {
            var item = await _inventoryService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryItemResponse>> Create(
            InventoryItemRequest request)
        {
            var item = await _inventoryService.CreateAsync(request);

            await _hubContext.Clients.All.SendAsync(
                "InventoryItemCreated",
                item);

            return CreatedAtAction(
                nameof(GetById),
                new { id = item.InventoryItemId },
                item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryItemResponse>> Update(
            int id,
            InventoryItemRequest request)
        {
            var item = await _inventoryService.UpdateAsync(id, request);

            if (item == null)
            {
                return NotFound();
            }

            await _hubContext.Clients.All.SendAsync(
                "InventoryItemUpdated",
                item);

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _inventoryService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            await _hubContext.Clients.All.SendAsync(
                "InventoryItemDeleted",
                id);

            return NoContent();
        }
    }
}