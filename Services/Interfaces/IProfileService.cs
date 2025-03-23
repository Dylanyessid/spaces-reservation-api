using SpacesReservation.API.Models;

namespace SpacesReservation.API.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<Profile> createProfile(Profile profile);
        public Task<Profile> getProfileById(int id);
    }
}
