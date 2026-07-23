using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Medical scans and reports uploaded by patient for health score calculation
    /// </summary>
    public class Scan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        /// <summary>
        /// Scan file name
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
        /// Type of scan
        /// </summary>
        [Required]
        public ReportType ScanType { get; set; }

        /// <summary>
        /// Date when the scan was taken
        /// </summary>
        [Required]
        public DateTime ScanDate { get; set; }

        /// <summary>
        /// Description or title of the scan
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// Medical center where scan was done
        /// </summary>
        [StringLength(200)]
        public string MedicalCenter { get; set; }

        /// <summary>
        /// Doctor's remarks or findings
        /// </summary>
        [StringLength(1000)]
        public string DoctorRemarks { get; set; }

        /// <summary>
        /// Whether this scan is used for health score calculation
        /// </summary>
        public bool IncludeInHealthScore { get; set; } = true;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }

        // Navigation property
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
