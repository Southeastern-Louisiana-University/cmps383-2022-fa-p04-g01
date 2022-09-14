using Microsoft.AspNetCore.Identity;

namespace FA22.P04.Web.Features.Authorization
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole>? Users { get; set; } = new List<UserRole>();  
    }
}
