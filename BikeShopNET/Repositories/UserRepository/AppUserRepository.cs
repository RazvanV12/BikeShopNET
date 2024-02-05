using BikeShopNET.Models;
using BikeShopNET.Repositories.GenericRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BikeShopNET.Repositories.UserRepository
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {

        public AppUserRepository(BikeShopContext dbContext) : base(dbContext)
        {
        }

        public AppUser GetAppUserById(string userId)
        {
            return _dbContext.Users.Find(userId);
        }
        public string GetRole(string userId)
        {
            return _dbContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).FirstOrDefault();
        }

        public List<AppUser> GetAdminsWhoLiveInCity(string City)
        {
            var rezultat = from user in _dbContext.Users
                           join userRole in _dbContext.UserRoles on user.Id equals userRole.UserId
                           join role in _dbContext.Roles on userRole.RoleId equals role.Id
                           join profile in _dbContext.userProfiles on user.Id equals profile.UserId
                           where role.Name == "Admin" && profile.City == "NumeOras"
                           select user;
            return rezultat.ToList();
        }
        public string GetFirstName(string userId)
        {
            return _dbContext.Users.Where(u => u.Id == userId).Select(u => u.FirstName).FirstOrDefault();
        }
        public string GetLastName(string userId)
        {
            return _dbContext.Users.Where(u => u.Id == userId).Select(u => u.LastName).FirstOrDefault();
        }

        public void Delete(AppUser user)
        {
            _dbContext.Users.Remove(user);
        }

        public List<AppUser> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void CreateProfile(UserProfile userProfile)
        {
            _dbContext.userProfiles.Update(userProfile);
        }
    }
}
