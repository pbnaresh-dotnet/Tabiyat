using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for Appointment booking and updates
    /// </summary>
    public class AppointmentDTO
    {
        public int? Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        public AppointmentStatus Status { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(1000)]
        public string Symptoms { get; set; }

        public int DurationInMinutes { get; set; }
    }

    /// <summary>
    /// DTO for appointment with patient and doctor details
    /// </summary>
    public class AppointmentDetailDTO
    {
        public int Id { get; set; }
        public PatientBriefDTO Patient { get; set; }
        public DoctorBriefDTO Doctor { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public string Reason { get; set; }
        public string Symptoms { get; set; }
        public string DoctorNotes { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// DTO for booking appointment request
    /// </summary>
    public class BookAppointmentRequestDTO
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(1000)]
        public string Symptoms { get; set; }
    }
}
