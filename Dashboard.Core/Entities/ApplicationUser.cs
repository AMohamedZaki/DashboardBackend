using Dashboard.Helper;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Core.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
