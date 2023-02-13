using Microsoft.AspNetCore.Identity;
using Dashboard.Core.Enums;

namespace Dashboard.Core.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
