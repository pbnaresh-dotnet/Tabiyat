using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for uploading and managing test reports
    /// </summary>
    public class TestReportDTO
    {
        public int? Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        public int? TestId { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string FilePath { get; set; }

        public long FileSizeBytes { get; set; }

        [StringLength(50)]
        public string MimeType { get; set; }

        [Required]
        public ReportType ReportType { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [StringLength(200)]
        public string Lab { get; set; }

        [StringLength(200)]
        public string ReferenceValue { get; set; }

        [StringLength(200)]
        public string ActualValue { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string DoctorRemarks { get; set; }
    }

    /// <summary>
    /// DTO for report list view
    /// </summary>
    public class TestReportListDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime ReportDate { get; set; }
        public string Lab { get; set; }
        public string Status { get; set; }
        public DateTime UploadedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
