using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Patient's existing medical conditions
    /// </summary>
    public class PatientMedicalCondition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public MedicalCondition Condition { get; set; }

        /// <summary>
        /// Year when condition was diagnosed
        /// </summary>
        public int? DiagnosisYear { get; set; }

        /// <summary>
        /// Additional notes about the condition
        /// </summary>
        [StringLength(500)]
        public string Notes { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
