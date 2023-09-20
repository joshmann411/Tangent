using System.ComponentModel.DataAnnotations;

namespace TA_API.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? EmployeeId { get; set; }

        public string? Street_number { get; set; }

        public String? Street { get; set; }

        public String? Building_name { get; set; }

        public String? Unit_number { get; set; }

        public String? Address_instruction { get; set; }

        public String? Suburb { get; set; }
        public String? City { get; set; }

        public String? State { get; set; } //province in SA

        public String? Country { get; set; }

        public String? Postal_code { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
