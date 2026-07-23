using Microsoft.EntityFrameworkCore;
using Tabiyat.Api.Data;
using Tabiyat.Shared.DTOs;
using Tabiyat.Shared.Models;

namespace Tabiyat.Api.Services
{
    /// <summary>
    /// Service for doctor-related operations
    /// </summary>
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(ApplicationDbContext context, ILogger<DoctorService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DoctorDTO> RegisterDoctorAsync(DoctorDTO doctorDTO)
        {
            try
            {
                // Check if email already exists
                var existingDoctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Email == doctorDTO.Email);
                if (existingDoctor != null)
                    throw new InvalidOperationException("Doctor with this email already exists.");

                // Check if license number already exists
                var existingLicense = await _context.Doctors.FirstOrDefaultAsync(d => d.LicenseNumber == doctorDTO.LicenseNumber);
                if (existingLicense != null)
                    throw new InvalidOperationException("Doctor with this license number already exists.");

                var doctor = new Doctor
                {
                    FirstName = doctorDTO.FirstName,
                    LastName = doctorDTO.LastName,
                    Email = doctorDTO.Email,
                    Phone = doctorDTO.Phone,
                    Specialization = doctorDTO.Specialization,
                    LicenseNumber = doctorDTO.LicenseNumber,
                    MedicalSchool = doctorDTO.MedicalSchool,
                    GraduationYear = doctorDTO.GraduationYear,
                    YearsOfExperience = doctorDTO.YearsOfExperience,
                    Hospital = doctorDTO.Hospital,
                    Address = doctorDTO.Address,
                    City = doctorDTO.City,
                    State = doctorDTO.State,
                    PostalCode = doctorDTO.PostalCode,
                    Country = doctorDTO.Country,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Doctor registered: {doctor.Id}");
                return MapToDTO(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error registering doctor: {ex.Message}");
                throw;
            }
        }

        public async Task<DoctorDTO> UpdateDoctorAsync(int doctorId, DoctorDTO doctorDTO)
        {
            try
            {
                var doctor = await _context.Doctors.FindAsync(doctorId);
                if (doctor == null)
                    throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

                doctor.FirstName = doctorDTO.FirstName;
                doctor.LastName = doctorDTO.LastName;
                doctor.Phone = doctorDTO.Phone;
                doctor.Specialization = doctorDTO.Specialization;
                doctor.MedicalSchool = doctorDTO.MedicalSchool;
                doctor.GraduationYear = doctorDTO.GraduationYear;
                doctor.YearsOfExperience = doctorDTO.YearsOfExperience;
                doctor.Hospital = doctorDTO.Hospital;
                doctor.Address = doctorDTO.Address;
                doctor.City = doctorDTO.City;
                doctor.State = doctorDTO.State;
                doctor.PostalCode = doctorDTO.PostalCode;
                doctor.Country = doctorDTO.Country;
                doctor.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation($"Doctor updated: {doctorId}");
                return MapToDTO(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating doctor: {ex.Message}");
                throw;
            }
        }

        public async Task<DoctorDTO> GetDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

            return MapToDTO(doctor);
        }

        public async Task<DoctorBriefDTO> GetDoctorBriefAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");

            return MapToBriefDTO(doctor);
        }

        public async Task<List<DoctorBriefDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors
                .Where(d => d.IsActive)
                .ToListAsync();

            return doctors.Select(MapToBriefDTO).ToList();
        }

        public async Task<List<DoctorBriefDTO>> GetDoctorsBySpecializationAsync(Specialization specialization)
        {
            var doctors = await _context.Doctors
                .Where(d => d.IsActive && d.Specialization == specialization)
                .ToListAsync();

            return doctors.Select(MapToBriefDTO).ToList();
        }

        public async Task<bool> DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            if (doctor == null)
                return false;

            doctor.IsActive = false;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Doctor deactivated: {doctorId}");
            return true;
        }

        private DoctorDTO MapToDTO(Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Specialization = doctor.Specialization,
                LicenseNumber = doctor.LicenseNumber,
                MedicalSchool = doctor.MedicalSchool,
                GraduationYear = doctor.GraduationYear,
                YearsOfExperience = doctor.YearsOfExperience,
                Hospital = doctor.Hospital,
                Address = doctor.Address,
                City = doctor.City,
                State = doctor.State,
                PostalCode = doctor.PostalCode,
                Country = doctor.Country,
                Rating = doctor.Rating,
                IsActive = doctor.IsActive
            };
        }

        private DoctorBriefDTO MapToBriefDTO(Doctor doctor)
        {
            return new DoctorBriefDTO
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Specialization = doctor.Specialization,
                YearsOfExperience = doctor.YearsOfExperience,
                Hospital = doctor.Hospital,
                Rating = doctor.Rating
            };
        }
    }
}
