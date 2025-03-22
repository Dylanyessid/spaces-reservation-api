using Microsoft.EntityFrameworkCore;
using SpacesReservation.API.Models;
using SpacesReservation.API.Services.Interfaces;

namespace SpacesReservation.API.Services
{
    public class UserService: IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context) 
        {
            this._context = context;
        }

        public IEnumerable<User> GetUsers() { 
            return _context.Users.ToList();
        }

        public async Task CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                //return user;

            }
            catch
            {
                //return null;
            }
           
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
