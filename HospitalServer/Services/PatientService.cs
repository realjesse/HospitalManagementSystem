using HospitalServer.Data;
using HospitalServer.DTOs;
using HospitalServer.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;

namespace HospitalServer.Services
{
    public class PatientService
    {
        private readonly HospitalDbContext _db;

        public PatientService(HospitalDbContext db)
        {
            _db = db;
        }

        // Gets all patients
        public async Task<List<PatientResponse>> GetAllAsync()
        {
            return await _db.Patients
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Select(p => ToResponse(p))
                .ToListAsync();
        }

        public async Task<PatientResponse?> GetByIdAsync(int PatientId)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == PatientId);

            if (patient == null)
            {
                return null;
            }

            return ToResponse(patient);
        }

        // Create a new patient
        public async Task<PatientResponse> CreateAsync(PatientRequest request)
        {
            // Create new patient entity
            var patient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            // Add it to the database
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();

            return ToResponse(patient);
        }

        // Update patient data
        public async Task<PatientResponse> UpdateAsync(int patientId, PatientRequest request)
        {
            // find patient
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);

            if (patient == null)
            {
                return null;
            }

            // Update patient values
            patient.FirstName = request.FirstName;
            patient.LastName = request.LastName;
            patient.DateOfBirth = request.DateOfBirth;

            // Update patient database
            await _db.SaveChangesAsync();

            return ToResponse(patient);
        }

        // Delete patient
        public async Task<bool> DeleteAsync(int patientId)
        {
            // Find patient
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);

            if (patient == null)
            {
                return false;
            }

            // Remove patient
            _db.Patients.Remove(patient);

            await _db.SaveChangesAsync();
        }

        // Converts Patient Entity into PatientResponse DTO
        private static PatientResponse ToResponse(Patient patient)
        {
            return new PatientResponse
            {
                PatientId = patient.PatientId,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth
            };
        }
    }
}
