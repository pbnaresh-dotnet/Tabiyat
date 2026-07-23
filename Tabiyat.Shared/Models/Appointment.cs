// PatientHealthDashboard.Shared/Models/Appointment.cs
using System.ComponentModel.DataAnnotations;
using PatientHealthDashboard.Shared.Enums;

namespace PatientHealthDashboard.Shared.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        
        public TimeSpan AppointmentTime { get; set; }
        
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        
        [MaxLength(500)]
        public string Reason { get; set; }
        
        [MaxLength(500)]
        public string Notes { get; set; }
        
        public int QueueNumber { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? CompletedAt { get; set; }
        
        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual ICollection<TestReport> TestReports { get; set; }
        public virtual ICollection<AppointmentDocument> Documents { get; set; }
    }
    
    public class AppointmentDocument
    {
        [Key]
        public int Id { get; set; }
        
        public int AppointmentId { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string DocumentName { get; set; }
        
        public string DocumentUrl { get; set; }
        
        public string DocumentType { get; set; }
        
        public long FileSize { get; set; }
        
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        
        public virtual Appointment Appointment { get; set; }
    }
}
