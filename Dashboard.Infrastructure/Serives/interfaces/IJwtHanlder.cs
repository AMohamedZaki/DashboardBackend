using System;
using Zanobia.Core.Entities;

namespace Zanobia.Infrastructure.Serives.interfaces
{
    public interface IJwtHandler
    {
        string GetToken(ApplicationUser user);
    }
}
