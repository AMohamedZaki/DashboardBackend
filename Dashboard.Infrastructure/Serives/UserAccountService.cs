using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Core.Enums;
using Dashboard.Helper.Dtos.Account;
using Dashboard.Infrastructure.Serives.interfaces;

namespace Dashboard.Infrastructure.Serives
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IConfiguration _configuration;

        private readonly UserManager<ApplicationUser> _userManager;

        public UserAccountService(UserManager<ApplicationUser> userManager,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<RegisterDTO> RegisterUser(RegisterDTO registerDto)
        {
            if (registerDto == null)
                throw new ArgumentNullException(nameof(registerDto));
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                UserType = (UserTypeEnum)registerDto.UserType,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception(string.Join(',', errors));
            }
            return new RegisterDTO
            {
                Email = user.Email,
                UserName = user.UserName
            };
        }
        public async Task<ApplicationUser> ChangePassword(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                throw new Exception("Password Didn't Change");
            }
            return user;
        }
        public async Task<ApplicationUser> GetUserById(string userId)
        {
            if (userId == null) throw new Exception($"Invalid {nameof(userId)}");
            return await _userManager.FindByIdAsync(userId);
        }
        public async Task<bool> ValidateToken(string authToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = await GetValidationParameters();
                IPrincipal principal = handler.ValidateToken(authToken, validationParameters, out _);
                return principal.Identity.IsAuthenticated;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<TokenValidationParameters> GetValidationParameters()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                ValidAudience = jwtSettings.GetSection("validAudience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
            };
        }
        public async Task<ApplicationUser> GetUserByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return await _userManager.FindByNameAsync(name);
            }
            return null;
        }
        public async Task<IEnumerable<Claim>> GetClaimsAsync(string token)
        {
            bool isValid = await ValidateToken(token);
            if (isValid)
            {
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(token);
                return (jsonToken as JwtSecurityToken).Claims;
            }
            return new List<Claim>();
        }
        public async Task<(ApplicationUser user, bool loginSuccessful)> LoginUser(LoginDTO loginDto, IHeaderDictionary headers)
        {
            bool loginSuccessful = false;
            var user = _userManager.Users.FirstOrDefault(_user => _user.Email == loginDto.Email && _user.UserType == loginDto.UserType);
            if (user != null)
            {
                bool notValidPassword = !await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (user == null || user.IsDeleted || notValidPassword)
                {
                    return (null, loginSuccessful);
                } 
            }
            loginSuccessful = user != null;
            return (user, loginSuccessful);
        }
        public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByIdAsync(resetPasswordDTO.UserId);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, resetToken, resetPasswordDTO.NewPassword);
            return true;
        }

        public async Task<object> GetUserByToken(string token)
        {
            var userId = (await GetClaimsAsync(token))?.First(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null) { return user; }
            return null;
        }

        public List<RegisterDTO> GetAllUsers()
        {
            var users =  _userManager.Users.Select(user => new RegisterDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                UserType = (int)user.UserType
            });

            return users.ToList();
        }

    }
}
