using Microsoft.AspNetCore.Mvc;
using BikeShopNET.Services.AppUserService;
using Microsoft.AspNetCore.Authorization;
using BikeShopNET.Models;

namespace BikeShopNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AdminController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        [Route("GetFullName")]
        //[Authorize(Policy = "RequireAdminRole")]
        public Tuple<string, string> GetFullName(string userId)
        {
            var result = _appUserService.GetFullname(userId);
            return result;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        //[
        //
        //Authorize(Policy = "RequireAdminRole")]
        public void DeleteUser([FromBody] string userId)
        {
            _appUserService.DeleteUser(userId);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        //[
        //
        //Authorize(Policy = "RequireAdminRole")]
        public List<AppUser> GetAllUsers()
        {
            return _appUserService.GetAll();
        }
        [HttpGet]
        [Route("GetAdminsWhoLiveInCity")]
        //[
        //
        //Authorize(Policy = "RequireAdminRole")]
        public List<AppUser> GetAdminsWhoLiveInCity(string City)
        {
            return _appUserService.GetAdminsWhoLiveInCity(City);
        }

        [HttpPost]
        [Route("CreateProfile")]
        //[
        //
        //Authorize(Policy = "RequireAdminRole")]
        public void CreateProfile([FromBody] UserProfile userProfile)
        {
            _appUserService.CreateProfile(userProfile);
        }
    }
}
