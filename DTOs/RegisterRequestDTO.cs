using System.ComponentModel.DataAnnotations;

namespace SpacesReservation.API.DTOs
{
    public class RegisterRequestDTO
    {

        [Required()]
        public string Email { get; set; }


        [Required()]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
