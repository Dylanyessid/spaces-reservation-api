using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SpacesReservation.API.DTOs;
using SpacesReservation.API.Models;
using SpacesReservation.API.Services.Interfaces;

namespace SpacesReservation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        // Aquí se inyecta el servicio
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegisterRequestDTO request)
        {

            var existingUser = await this._userService.GetUserByEmail(request.Email);
            string hashed = BCrypt.Net.BCrypt.HashPassword(request.Password);
            
            if (existingUser is not null) return BadRequest( new { message = "Existing User" });
            User user = new() { Email = request.Email,Password = hashed};
            await this._userService.CreateUser(user);
            
           // var uri = $"/api/productos/{nuevoProducto.Id}";
            return Created( "" ,new { message= "Registered" } );
        }
    }
}
