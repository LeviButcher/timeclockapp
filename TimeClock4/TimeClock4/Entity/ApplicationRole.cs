using Microsoft.AspNetCore.Identity;

namespace TimeClock4.Entity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
