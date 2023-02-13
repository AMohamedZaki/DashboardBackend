using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zanobia.Core.Entities;
using Zanobia.Core.Enums;
using Zanobia.Infrastructure.Serives.interfaces;

namespace Zanobia.Infrastructure.Serives
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, ApplicationUser user)
        {
            (DateTime expires, List<Claim> claims) = GetUserConiguration(user);
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);
            return tokenOptions;
        }

        private (DateTime, List<Claim>) GetUserConiguration(ApplicationUser user)
        {
            var userClaims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sid, user.Id),
                                               new Claim(JwtRegisteredClaimNames.Typ, user.UserType.ToString())};

            return user.UserType switch
            {
                UserTypeEnum.Admin => (DateTime.Now.AddMinutes(24 * 60), userClaims),
                _ => throw new ArgumentException(nameof(user.UserType)),
            };
        }

        public string GetToken(ApplicationUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(signingCredentials, user);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
