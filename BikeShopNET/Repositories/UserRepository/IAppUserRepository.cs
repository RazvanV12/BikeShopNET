using BikeShopNET.Repositories.GenericRepository;
using BikeShopNET.Models;

namespace BikeShopNET.Repositories.UserRepository
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
         string GetRole(string userId);
    }
}
