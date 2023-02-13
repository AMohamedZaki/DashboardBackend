using System;
using Dashboard.Core.Entities;

namespace Dashboard.Infrastructure.Serives.interfaces
{
    public interface IJwtHandler
    {
        string GetToken(ApplicationUser user);
    }
}
