using BikeShopNET.Repositories.GenericRepository;
using BikeShopNET.Models;

namespace BikeShopNET.Repositories.UserRepository
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
         string GetRole(string userId);
         string GetFirstName(string userId);
         string GetLastName(string userId);
        void Delete(AppUser user);
        AppUser GetAppUserById(string userId);
        List<AppUser> GetAll();
        List<AppUser> GetAdminsWhoLiveInCity(string City);

        void CreateProfile(UserProfile userProfile);
    }
}
