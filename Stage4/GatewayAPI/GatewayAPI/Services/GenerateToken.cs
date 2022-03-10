using GatewayAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public class GenerateToken : IGenerateToken<UserDTO>
    {
        private readonly SymmetricSecurityKey _key;

        public GenerateToken(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(UserDTO user)
        {
            var cliam = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username)
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDec = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cliam),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDec);
            return tokenHandler.WriteToken(token);
        }
    }
}
