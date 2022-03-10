using GatewayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public class UserRepo : IRepo<string, UserDTO>
    {
        private readonly UserContext _context;
        private readonly IGenerateToken<UserDTO> _generateToken;

        public UserRepo(UserContext context,IGenerateToken<UserDTO> generateToken)
        {
            _context = context;
            _generateToken = generateToken;
        }
        public async Task<UserDTO> Add(UserDTO item)
        {
            using var hmac = new HMACSHA512();
            var user1 = new User()
            {
                Username = item.Username,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(item.Password)),
                PassKey = hmac.Key
            };
            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            item.Password = "";
            item.Token = _generateToken.CreateToken(item);
            return item;
        }
        public async Task<UserDTO> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Delete(string id)
        {
            throw new NotImplementedException();
        }

       

        public Task<ICollection<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
