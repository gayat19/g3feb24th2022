using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RevisionApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Services
{
    public class UserRepo : IRepo<string, User>
    {
        private readonly StoreContext _context;
        private readonly ILogger<UserRepo> _logger;
        //public UserRepo(StoreContext context)
        //{
        //    _context = context;
        //    //_logger = logger;
        //}
        public UserRepo(StoreContext context,ILogger<UserRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
               
            }
            return null;
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public User Get(string key)
        {
            return _context.Users.SingleOrDefault(u => u.Username == key);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
