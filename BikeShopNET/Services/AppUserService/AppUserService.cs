using BikeShopNET.Repositories.UserRepository;
using BikeShopNET.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeShopNET.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public bool CheckIfAdmin(string userId)
        {
            return _appUserRepository.GetRole(userId) == "Admin";
        }

        public Tuple<string, string> GetFullname(string userId)
        {
            return new Tuple<string, string>(_appUserRepository.GetFirstName(userId), _appUserRepository.GetLastName(userId));
        }

        public void DeleteUser(string userId)
        {
            var user = _appUserRepository.GetAppUserById(userId);
            if (user != null)
                _appUserRepository.Delete(user);
            return;
        }

        public List<AppUser> GetAll()
        {
            return _appUserRepository.GetAll();
        }

        public List<AppUser> GetAdminsWhoLiveInCity(string City)
        {
            return _appUserRepository.GetAdminsWhoLiveInCity(City);
        }

        public void CreateProfile(UserProfile userProfile)
        {
            _appUserRepository.CreateProfile(userProfile);
        }
    }
}
