using Microsoft.AspNetCore.Identity;
using Zanobia.Core.Enums;

namespace Zanobia.Core.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
