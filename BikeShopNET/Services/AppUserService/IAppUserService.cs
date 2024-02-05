using BikeShopNET.Models;

namespace BikeShopNET.Services.AppUserService
{
    public interface IAppUserService
    {
        bool CheckIfAdmin(string userId);

        Tuple<string, string> GetFullname(string userId);
        void DeleteUser(string userId);

        List<AppUser> GetAdminsWhoLiveInCity(string City);
        List<AppUser> GetAll();
        void CreateProfile(UserProfile userProfile);
    }
}
