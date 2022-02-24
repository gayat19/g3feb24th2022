using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevisionApplication.Models;
using RevisionApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevisionApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepo<string, User> _repo;
        private readonly GetRoles _roles;
        private readonly ILogger<UserRepo> _logger;

        public UserController(IRepo<string,User> repo,GetRoles roles,ILogger<UserRepo> logger)
        {
            _repo = repo;
            _roles = roles;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
           
            //throw new DivideByZeroException("Some error");
            ViewBag.Roles = _roles.GetRoleList();
            _logger.LogInformation("Regitration started");
            return View();
        }
        [HttpPost]
        public IActionResult Register(VMUser vmuser)
        {
           
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Username = vmuser.Username;
                user.Password = vmuser.Password;
                user.Role = vmuser.Role;
                _repo.Add(user);
            }
            return RedirectToAction("Register");
        }
    }
}
