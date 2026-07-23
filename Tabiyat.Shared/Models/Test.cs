using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Medical test recommended by doctor
    /// </summary>
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Name of the test
        /// </summary>
        [Required]
        [StringLength(100)]
        public string TestName { get; set; }

        /// <summary>
        /// Type of test
        /// </summary>
        [Required]
        public ReportType TestType { get; set; }

        /// <summary>
        /// Priority of the test (Routine, Urgent, etc.)
        /// </summary>
        [StringLength(50)]
        public string Priority { get; set; } = "Routine";

        /// <summary>
        /// Description/Instructions for the test
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Recommended lab or imaging center
        /// </summary>
        [StringLength(200)]
        public string RecommendedLab { get; set; }

        /// <summary>
        /// Whether the test has been completed
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Date when test was conducted
        /// </summary>
        public DateTime? TestDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        public ICollection<TestReport> TestReports { get; set; } = new List<TestReport>();
    }
}
