using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for creating and updating prescriptions
    /// </summary>
    public class PrescriptionDTO
    {
        public int? Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [StringLength(500)]
        public string DietaryRecommendations { get; set; }

        [StringLength(500)]
        public string LifestyleRecommendations { get; set; }

        [StringLength(200)]
        public string FollowUpRecommendation { get; set; }

        public int ValidityDays { get; set; }
        public List<PrescriptionMedicineDTO> Medicines { get; set; } = new List<PrescriptionMedicineDTO>();
    }

    /// <summary>
    /// DTO for prescription medicine details
    /// </summary>
    public class PrescriptionMedicineDTO
    {
        public int? Id { get; set; }

        [Required]
        public int MedicineId { get; set; }

        public string MedicineName { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        [Required]
        public MedicineTiming Timing { get; set; }

        [Required]
        public int DurationDays { get; set; }

        [Required]
        public int FrequencyPerDay { get; set; }

        [StringLength(500)]
        public string SpecialInstructions { get; set; }
    }

    /// <summary>
    /// DTO for prescription detail view
    /// </summary>
    public class PrescriptionDetailDTO
    {
        public int Id { get; set; }
        public PatientBriefDTO Patient { get; set; }
        public DoctorBriefDTO Doctor { get; set; }
        public DateTime IssuedDate { get; set; }
        public int ValidityDays { get; set; }
        public string Notes { get; set; }
        public string DietaryRecommendations { get; set; }
        public string LifestyleRecommendations { get; set; }
        public string FollowUpRecommendation { get; set; }
        public List<PrescriptionMedicineDetailDTO> Medicines { get; set; }
    }

    /// <summary>
    /// DTO for medicine details in prescription
    /// </summary>
    public class PrescriptionMedicineDetailDTO
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public string Strength { get; set; }
        public string Form { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public MedicineTiming Timing { get; set; }
        public int DurationDays { get; set; }
        public int FrequencyPerDay { get; set; }
        public string SpecialInstructions { get; set; }
    }
}
