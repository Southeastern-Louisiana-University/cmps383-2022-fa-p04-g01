using Microsoft.AspNetCore.Identity;
namespace FA22.P04.Web.Features.Authorization;

public class User : IdentityUser<int>
{
    public ICollection<UserRole>? Roles { get; set; } = new List<UserRole>();
}