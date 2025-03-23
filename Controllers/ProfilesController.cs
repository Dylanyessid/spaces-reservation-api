
using Microsoft.AspNetCore.Mvc;
using SpacesReservation.API.DTOs;
using SpacesReservation.API.Services.Interfaces;
using SpacesReservation.API.Models;
namespace SpacesReservation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

      
        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> createProfile([FromBody] CreateProfileDTO body)
        {
            Profile newProfile = new() { FirstName=body.FirstName, LastName=body.LastName, UserId=body.UserId };
            var result = await _profileService.createProfile(newProfile);
            if (result is null) return BadRequest( new { error = "Existing profile"});
            return Created("", new { data=result!,message = "Profile created" });
        }
    }
}
