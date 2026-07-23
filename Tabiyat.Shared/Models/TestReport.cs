using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Test report uploaded by patient
    /// </summary>
    public class TestReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        public int? TestId { get; set; }

        /// <summary>
        /// Report file name
        /// </summary>
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        /// <summary>
        /// File path or URL
        /// </summary>
        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        /// <summary>
        /// File size in bytes
        /// </summary>
        public long FileSizeBytes { get; set; }

        /// <summary>
        /// MIME type of the file
        /// </summary>
        [StringLength(50)]
        public string MimeType { get; set; }

        /// <summary>
        /// Type of report
        /// </summary>
        [Required]
        public ReportType ReportType { get; set; }

        /// <summary>
        /// Date of the test/report
        /// </summary>
        [Required]
        public DateTime ReportDate { get; set; }

        /// <summary>
        /// Lab/Center that conducted the test
        /// </summary>
        [StringLength(200)]
        public string Lab { get; set; }

        /// <summary>
        /// Reference value or normal range
        /// </summary>
        [StringLength(200)]
        public string ReferenceValue { get; set; }

        /// <summary>
        /// Actual value from the test
        /// </summary>
        [StringLength(200)]
        public string ActualValue { get; set; }

        /// <summary>
        /// Status (Normal, Abnormal, Pending)
        /// </summary>
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        /// <summary>
        /// Doctor's remarks about the report
        /// </summary>
        [StringLength(500)]
        public string DoctorRemarks { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }

        // Navigation properties
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
    }
}
