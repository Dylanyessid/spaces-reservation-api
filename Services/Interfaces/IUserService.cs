

using SpacesReservation.API.Models;

namespace SpacesReservation.API.Services.Interfaces
{
    public interface IUserService
    {
       
            IEnumerable<User> GetUsers();
            //User GetUserById(int id);
            Task CreateUser(User user);
            Task<User> GetUserByEmail(string email  );
        
    }
}
