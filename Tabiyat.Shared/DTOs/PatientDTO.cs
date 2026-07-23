using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for Patient registration and updates
    /// </summary>
    public class PatientDTO
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public BloodGroup BloodGroup { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public decimal CurrentWeight { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string EmergencyContactName { get; set; }

        [Phone]
        public string EmergencyContactPhone { get; set; }

        public decimal? HealthScore { get; set; }
        public List<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();
        public List<PatientSurgeryDTO> Surgeries { get; set; } = new List<PatientSurgeryDTO>();
    }

    /// <summary>
    /// DTO for Patient health score response
    /// </summary>
    public class PatientHealthScoreDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public decimal? HealthScore { get; set; }
        public decimal BMI { get; set; }
        public int Age { get; set; }
        public List<string> MedicalConditions { get; set; }
        public List<string> RecentScans { get; set; }
        public List<string> RecentTestResults { get; set; }
        public string HealthStatus { get; set; }
        public string Recommendations { get; set; }
    }

    /// <summary>
    /// DTO for brief patient information
    /// </summary>
    public class PatientBriefDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? HealthScore { get; set; }
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// DTO for patient surgery information
    /// </summary>
    public class PatientSurgeryDTO
    {
        public int? Id { get; set; }
        public SurgeryType SurgeryType { get; set; }
        public DateTime SurgeryDate { get; set; }
        public string Hospital { get; set; }
        public string SurgeonName { get; set; }
        public string Notes { get; set; }
    }

    /// <summary>
    /// DTO for medical condition information
    /// </summary>
    public class PatientMedicalConditionDTO
    {
        public int? Id { get; set; }
        public MedicalCondition Condition { get; set; }
        public int? DiagnosisYear { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
