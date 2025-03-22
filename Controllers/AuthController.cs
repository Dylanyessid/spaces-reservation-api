using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SpacesReservation.API.DTOs;
using SpacesReservation.API.Models;
using SpacesReservation.API.Services.Interfaces;
using SpacesReservation.API.Utils;

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

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] LoginRequestDTO request)
        {
            var user = new User() { Email=request.Email, Password=request.Password };
            var token = this._userService.Login(user);
            if (token is null) return Unauthorized(new { message = "Invalid credentials" });

            return Ok( new { token=token.Result } );
        }
    }
}
