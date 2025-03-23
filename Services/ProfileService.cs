using Microsoft.EntityFrameworkCore;
using SpacesReservation.API.Models;
using SpacesReservation.API.Services.Interfaces;

namespace SpacesReservation.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _context;

        public ProfileService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Profile> createProfile(Profile profile)
        {
            try
            {
                var exsitingProfile = await this._context.Profiles.FirstOrDefaultAsync(p => p.UserId == profile.UserId);
                if (exsitingProfile is not null) return null;
                var createdProfile = this._context.Profiles.Add(profile!);
                await this._context.SaveChangesAsync();
                return createdProfile.Entity;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<Profile> getProfileById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
