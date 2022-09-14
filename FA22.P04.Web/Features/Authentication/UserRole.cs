using Microsoft.AspNetCore.Identity;

namespace FA22.P04.Web.Features.Authorization
{
    public class UserRole : IdentityUserRole<int>
    {
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
