using BookManager.BusinessObjects.DTOs.Login;
using BookManager.BusinessObjects.Interfaces.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class LoginPresenter : ILoginPresenter
    {
        readonly IConfigurationSection JWTConfigurationSection;
        public string Token { get; private set; }

        public LoginPresenter(IConfigurationSection jWTConfigurationSection)
        {
            JWTConfigurationSection = jWTConfigurationSection;
        }

        public ValueTask Handle(UserDto userDto)
        {
            SigningCredentials SigningCredentials = GetSigningCredentials();

            List<Claim> UserClaims = GetClaims(userDto);

            JwtSecurityToken TokenOptions = GetTokenOptions(SigningCredentials, UserClaims);

            Token = new JwtSecurityTokenHandler().WriteToken(TokenOptions);

            return ValueTask.CompletedTask;
        }

        private JwtSecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> userClaims)
        {
            return new JwtSecurityToken(
                issuer: JWTConfigurationSection["ValidIssuer"],
                audience: JWTConfigurationSection["ValidAudience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(
                    JWTConfigurationSection["ExpiredInMinutes"])),
                signingCredentials: signingCredentials);
        }

        private List<Claim> GetClaims(UserDto userDto)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDto.Email)
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            var Key = Encoding.UTF8.GetBytes(JWTConfigurationSection["SecurityKey"]!);

            var Secret = new SymmetricSecurityKey(Key);

            return new SigningCredentials(Secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
