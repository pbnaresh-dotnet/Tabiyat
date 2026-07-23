using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Patient's medical history and health records
    /// </summary>
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        /// <summary>
        /// Entry date
        /// </summary>
        [Required]
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Type of history entry (Visit, Lab, Allergy, etc.)
        /// </summary>
        [Required]
        [StringLength(50)]
        public string EntryType { get; set; }

        /// <summary>
        /// Description of the medical event
        /// </summary>
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Associated doctor (if applicable)
        /// </summary>
        [StringLength(100)]
        public string DoctorName { get; set; }

        /// <summary>
        /// Associated hospital (if applicable)
        /// </summary>
        [StringLength(200)]
        public string Hospital { get; set; }

        /// <summary>
        /// Severity level (if applicable)
        /// </summary>
        [StringLength(50)]
        public string Severity { get; set; }

        /// <summary>
        /// Status of the condition (Active, Resolved, etc.)
        /// </summary>
        [StringLength(50)]
        public string Status { get; set; } = "Active";

        /// <summary>
        /// Any relevant notes
        /// </summary>
        [StringLength(500)]
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
