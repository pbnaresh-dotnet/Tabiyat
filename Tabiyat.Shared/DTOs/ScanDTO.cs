using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for uploading and managing scans
    /// </summary>
    public class ScanDTO
    {
        public int? Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        public long FileSizeBytes { get; set; }

        [StringLength(50)]
        public string MimeType { get; set; }

        [Required]
        public ReportType ScanType { get; set; }

        [Required]
        public DateTime ScanDate { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(200)]
        public string MedicalCenter { get; set; }

        [StringLength(1000)]
        public string DoctorRemarks { get; set; }

        public bool IncludeInHealthScore { get; set; }
    }

    /// <summary>
    /// DTO for scan list view
    /// </summary>
    public class ScanListDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public ReportType ScanType { get; set; }
        public DateTime ScanDate { get; set; }
        public string Description { get; set; }
        public string MedicalCenter { get; set; }
        public bool IncludeInHealthScore { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
