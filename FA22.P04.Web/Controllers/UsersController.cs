using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FA22.P04.Web.Features.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA22.P04.Web.Controllers;
{
    [Route("[api/UsersController]")]
    [ApiController]

    //Create User Endpoint
    [HttpPost]
    public async Task<ActionResult> Create(UserDto dto)
    {
        var user = new User { UserName = dto.UserName };
        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            return BadRequest();
        }
        await userManager.AddToRoleAsync(user, "User");
        return Ok();
    }
}