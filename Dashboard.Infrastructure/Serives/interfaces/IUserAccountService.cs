using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Account;

namespace Dashboard.Infrastructure.Serives.interfaces
{
    public interface IUserAccountService
    {
        Task<RegisterDTO> RegisterUser(RegisterDTO registerDto);
        Task<ApplicationUser> ChangePassword(string userId, string newPassword);
        Task<ApplicationUser> GetUserById(string userId);
        Task<bool> ValidateToken(string authToken);
        Task<TokenValidationParameters> GetValidationParameters();
        Task<ApplicationUser> GetUserByName(string name);
        Task<IEnumerable<Claim>> GetClaimsAsync(string token);
        Task<(ApplicationUser user, bool loginSuccessful)> LoginUser(LoginDTO loginDto, IHeaderDictionary headers);
        Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);
        Task<object> GetUserByToken(string token);
        List<RegisterDTO> GetAllUsers(int? UserType = null);
    }
}
