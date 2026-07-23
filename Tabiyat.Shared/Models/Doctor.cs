// PatientHealthDashboard.Shared/Models/Doctor.cs
using System.ComponentModel.DataAnnotations;
using PatientHealthDashboard.Shared.Enums;

namespace PatientHealthDashboard.Shared.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        public DoctorSpecialization Specialization { get; set; }
        
        [MaxLength(50)]
        public string LicenseNumber { get; set; }
        
        public int YearsOfExperience { get; set; }
        
        [MaxLength(500)]
        public string ClinicAddress { get; set; }
        
        [MaxLength(100)]
        public string City { get; set; }
        
        public double ConsultationFee { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        public string ProfileImageUrl { get; set; }
        
        [MaxLength(1000)]
        public string Bio { get; set; }
        
        public string Qualifications { get; set; }
        
        public double Rating { get; set; }
        
        public int TotalAppointments { get; set; }
        
        // Working hours
        public TimeSpan MorningShiftStart { get; set; }
        public TimeSpan MorningShiftEnd { get; set; }
        public TimeSpan? EveningShiftStart { get; set; }
        public TimeSpan? EveningShiftEnd { get; set; }
        
        public virtual ICollection<DoctorAvailability> Availability { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
    
    public class DoctorAvailability
    {
        [Key]
        public int Id { get; set; }
        
        public int DoctorId { get; set; }
        
        public DayOfWeek DayOfWeek { get; set; }
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        public virtual Doctor Doctor { get; set; }
    }
}
