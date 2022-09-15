using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FA22.P04.Web.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using FA22.P04.Web.Data;
using FA22.P04.Web.Features.Authorization;

namespace FA22.P04.Web.Controllers;

[Route("[api/authentication]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    private Task<User> GetCurrentUserAsync() {

        userManager.GetUserAsync(User);
            
    }

        //Login Endpoint
        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                return BadRequest();
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            await signInManager.SignInAsync(user, false, "Password");
            var roles = await userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                UserName = user.UserName,
                Role = roles,
            });
        }

        //Logout Endpoint
        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
           await signInManager.SignOutAsync();
           return Ok();
        }
}


