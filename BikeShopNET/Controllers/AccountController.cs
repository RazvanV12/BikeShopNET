using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BikeShopNET.Models; // Actualizează cu namespace-ul corect pentru modelele tale
using BikeShopNET.ViewModels;// Actualizează cu namespace-ul corect pentru ViewModel-urile tale


namespace BikeShopNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,
                               SignInManager<AppUser> signInManager,
                               ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AccountUserDTO userdto)
        {
            _logger.LogDebug("Running register account...");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Model is not valid");
                return BadRequest(ModelState);
            }
            try
            {
                AppUser user = new AppUser(userdto);
                user.UserName = userdto.Email;
                var result = await _userManager.CreateAsync(user, userdto.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    _logger.LogWarning("Unauthorized access");
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRoleAsync(user, "User");
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO logindto)
        {
            _logger.LogDebug("Executing login account...");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(
                    logindto.Email, logindto.Password, false, false);

                if (!result.Succeeded || User.Identity.IsAuthenticated)
                {
                    _logger.LogWarning("Unauthorized access");
                    return Unauthorized(logindto);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            _logger.LogDebug("Running logoutaccount...");
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await _signInManager.SignOutAsync();
                    return Ok();
                }
                else
                {
                    _logger.LogWarning("Unauthorized access");
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return Problem("Something went wrong", statusCode: 500);
            }
        }

    }
}