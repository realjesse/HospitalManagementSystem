using HospitalServer.DTOs;
using HospitalServer.Hubs;
using HospitalServer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HospitalServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;
        private readonly IHubContext<HospitalHub> _hubContext;

        public PatientsController(
            PatientService patientService,
            IHubContext<HospitalHub> hubContext)
        {
            _patientService = patientService;
            _hubContext = hubContext;
        }

        // Get all patients
        [HttpGet]
        public async Task<ActionResult<List<PatientResponse>>> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        // Get a certain patient based on ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientResponse>> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // Get a certain patient based on MongoDB user ID
        [HttpGet("by-user/{mongoUserId}")]
        public async Task<ActionResult<PatientResponse>> GetByMongoUserId(string mongoUserId)
        {
            var patient = await _patientService.GetByMongoUserIdAsync(mongoUserId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // Creat a patient
        [HttpPost]
        public async Task<ActionResult<PatientResponse>> Create(PatientRequest request)
        {
            var patient = await _patientService.CreateAsync(request);

            await _hubContext.Clients.All.SendAsync("PatientCreated", patient);

            return CreatedAtAction(
                nameof(GetById),
                new { id = patient.PatientId },
                patient);
        }

        // Update a patient
        [HttpPut("{id}")]
        public async Task<ActionResult<PatientResponse>> Update(int id, PatientRequest request)
        {
            var patient = await _patientService.UpdateAsync(id, request);

            if (patient == null)
            {
                return NotFound();
            }

            await _hubContext.Clients.All.SendAsync("PatientUpdated", patient);

            return Ok(patient);
        }

        // Delete patient
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _patientService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            await _hubContext.Clients.All.SendAsync("PatientDeleted", id);

            return NoContent();
        }
    }
}
