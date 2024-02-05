namespace BikeShopNET.Services.AppUserService
{
    public interface IAppUserService
    {
        bool CheckIfAdmin(string userId);

        Tuple<string, string> GetFullname(string userId);
    }
}
