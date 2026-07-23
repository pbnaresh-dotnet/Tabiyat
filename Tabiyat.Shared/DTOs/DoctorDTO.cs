using System.ComponentModel.DataAnnotations;
using Tabiyat.Shared.Models;

namespace Tabiyat.Shared.DTOs
{
    /// <summary>
    /// DTO for Doctor registration and updates
    /// </summary>
    public class DoctorDTO
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public Specialization Specialization { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        public string MedicalSchool { get; set; }
        public int? GraduationYear { get; set; }
        public int YearsOfExperience { get; set; }
        public string Hospital { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal? Rating { get; set; }
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// DTO for brief doctor information
    /// </summary>
    public class DoctorBriefDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Specialization Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public string Hospital { get; set; }
        public decimal? Rating { get; set; }
    }
}
