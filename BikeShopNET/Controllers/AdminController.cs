using Microsoft.AspNetCore.Mvc;
using BikeShopNET.Services.AppUserService;
using Microsoft.AspNetCore.Authorization;

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
    }
}
