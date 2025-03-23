
using System.ComponentModel.DataAnnotations;

namespace SpacesReservation.API.DTOs
{
    public class CreateProfileDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

    }
}
