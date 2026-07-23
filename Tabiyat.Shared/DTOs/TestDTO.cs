using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for recommending tests
    /// </summary>
    public class TestDTO
    {
        public int? Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string TestName { get; set; }

        [Required]
        public ReportType TestType { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(200)]
        public string RecommendedLab { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? TestDate { get; set; }
    }

    /// <summary>
    /// DTO for test with appointment details
    /// </summary>
    public class TestDetailDTO
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public ReportType TestType { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string RecommendedLab { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? TestDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppointmentDetailDTO Appointment { get; set; }
    }
}
