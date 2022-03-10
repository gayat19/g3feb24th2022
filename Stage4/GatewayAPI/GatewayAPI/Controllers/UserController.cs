using GatewayAPI.Models;
using GatewayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo<string, UserDTO> _repo;
        private readonly LoginService _loginService;

        public UserController(IRepo<string,UserDTO> repo,LoginService loginService)
        {
            _repo = repo;
            _loginService = loginService;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO user)
        {
            UserDTO user1 = await _repo.Add(user);
            return Ok(user1);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserDTO>> Login(UserDTO user)
        {
            UserDTO user1 = await _loginService.Login(user);
            if (user1 == null)
                return Unauthorized("Invalid username or password");
            return Ok(user1);
        }
    }
}
