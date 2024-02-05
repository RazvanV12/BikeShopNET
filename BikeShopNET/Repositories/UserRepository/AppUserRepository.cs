using BikeShopNET.Models;
using BikeShopNET.Repositories.GenericRepository;


namespace BikeShopNET.Repositories.UserRepository
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {

        public AppUserRepository(BikeShopContext dbContext) : base(dbContext)
        {
        }
        public string GetRole(string userId)
        {
            return _dbContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).FirstOrDefault();
        }
        public string GetFirstName(string userId)
        {
            return _dbContext.Users.Where(u => u.Id == userId).Select(u => u.FirstName).FirstOrDefault();
        }
        public string GetLastName(string userId)
        {
            return _dbContext.Users.Where(u => u.Id == userId).Select(u => u.LastName).FirstOrDefault();
        }
    }
}
