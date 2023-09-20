using System.ComponentModel.DataAnnotations;

namespace TA_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? EmployeeId { get; set; }

        [Required]
        public string Street_number { get; set; }

        [Required]
        public string Street { get; set; }

        public string? Building_name { get; set; }

        public string? Unit_number { get; set; }

        public string? Address_instruction { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; } //province in SA

        [Required]
        public string Country { get; set; }

        public string? Postal_code { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
