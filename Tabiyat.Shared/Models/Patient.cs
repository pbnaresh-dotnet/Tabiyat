using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Patient registration and demographic information
    /// </summary>
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public BloodGroup BloodGroup { get; set; }

        /// <summary>
        /// Height in centimeters
        /// </summary>
        [Required]
        public decimal Height { get; set; }

        /// <summary>
        /// Current weight in kilograms
        /// </summary>
        [Required]
        public decimal CurrentWeight { get; set; }

        /// <summary>
        /// BMI calculated from height and weight
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal? BMI { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        /// <summary>
        /// Emergency contact name
        /// </summary>
        [StringLength(100)]
        public string EmergencyContactName { get; set; }

        /// <summary>
        /// Emergency contact phone
        /// </summary>
        [Phone]
        [StringLength(20)]
        public string EmergencyContactPhone { get; set; }

        /// <summary>
        /// Patient health score (0-100)
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal? HealthScore { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<PatientMedicalCondition> MedicalConditions { get; set; } = new List<PatientMedicalCondition>();
        public ICollection<PatientSurgery> Surgeries { get; set; } = new List<PatientSurgery>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<TestReport> TestReports { get; set; } = new List<TestReport>();
        public ICollection<Scan> Scans { get; set; } = new List<Scan>();
        public ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}
