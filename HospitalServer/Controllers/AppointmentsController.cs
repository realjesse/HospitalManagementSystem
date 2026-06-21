using HospitalServer.DTOs;
using HospitalServer.Hubs;
using HospitalServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HospitalServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        private readonly IHubContext<HospitalHub> _hubContext;

        public AppointmentsController(
            AppointmentService appointmentService,
            IHubContext<HospitalHub> hubContext)
        {
            _appointmentService = appointmentService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentResponse>>> GetAll()
        {
            return Ok(await _appointmentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentResponse>> GetById(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentResponse>> Create(AppointmentRequest request)
        {
            var appointment = await _appointmentService.CreateAsync(request);

            await _hubContext.Clients.All.SendAsync(
                "AppointmentCreated",
                appointment);

            return CreatedAtAction(
                nameof(GetById),
                new { id = appointment.AppointmentId },
                appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentResponse>> Update(
            int id,
            AppointmentRequest request)
        {
            var appointment =
                await _appointmentService.UpdateAsync(id, request);

            if (appointment == null)
                return NotFound();

            await _hubContext.Clients.All.SendAsync(
                "AppointmentUpdated",
                appointment);

            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _appointmentService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            await _hubContext.Clients.All.SendAsync(
                "AppointmentDeleted",
                id);

            return NoContent();
        }
    }
}