using BikeShopNET.Repositories.UserRepository;

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
    }
}
