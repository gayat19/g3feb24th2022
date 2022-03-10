using GatewayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public class LoginService
    {
        private readonly UserContext _context;
        private readonly IGenerateToken<UserDTO> _generateToken;
        public LoginService(UserContext context, IGenerateToken<UserDTO> generateToken)
        {
            _context = context;
            _generateToken = generateToken;
        }
        public async Task<UserDTO> Login(UserDTO item)
        {
            var myUser = _context.Users.SingleOrDefault(u => u.Username == item.Username);
            if (myUser == null)
                return null;
            using var hmac = new HMACSHA512(myUser.PassKey);
            var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(item.Password));
            for(int i = 0; i < userPass.Length; i++)
            {
                if (userPass[i] != myUser.Password[i])
                    return null;
            }
            item.Password = "";
            item.Token = _generateToken.CreateToken(item);
            return item;
        }
    }
}
