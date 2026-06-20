using HospitalServer.Data;
using HospitalServer.DTOs;
using HospitalServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalServer.Services
{
    public class AppointmentService
    {
        private readonly HospitalDbContext _db;

        public AppointmentService(HospitalDbContext db)
        {
            _db = db;
        }

        public async Task<List<AppointmentResponse>> GetAllAsync()
        {
            return await _db.Appointments
                .OrderBy(a => a.AppointmentDate)
                .Select(a => ToResponse(a))
                .ToListAsync();
        }

        public async Task<AppointmentResponse?> GetByIdAsync(int appointmentId)
        {
            var appointment = await _db.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

            return appointment == null ? null : ToResponse(appointment);
        }

        public async Task<AppointmentResponse> CreateAsync(AppointmentRequest request)
        {
            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                DoctorName = request.DoctorName,
                AppointmentDate = request.AppointmentDate,
                Reason = request.Reason,
                Status = request.Status
            };

            _db.Appointments.Add(appointment);
            await _db.SaveChangesAsync();

            return ToResponse(appointment);
        }

        public async Task<AppointmentResponse?> UpdateAsync(int appointmentId, AppointmentRequest request)
        {
            var appointment = await _db.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

            if (appointment == null)
            {
                return null;
            }

            appointment.PatientId = request.PatientId;
            appointment.DoctorName = request.DoctorName;
            appointment.AppointmentDate = request.AppointmentDate;
            appointment.Reason = request.Reason;
            appointment.Status = request.Status;

            await _db.SaveChangesAsync();

            return ToResponse(appointment);
        }

        public async Task<bool> DeleteAsync(int appointmentId)
        {
            var appointment = await _db.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

            if (appointment == null)
            {
                return false;
            }

            _db.Appointments.Remove(appointment);
            await _db.SaveChangesAsync();

            return true;
        }

        private static AppointmentResponse ToResponse(Appointment appointment)
        {
            return new AppointmentResponse
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                DoctorName = appointment.DoctorName,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                Status = appointment.Status
            };
        }
    }
}