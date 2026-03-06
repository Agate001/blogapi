using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Models.DTO;
using blogapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
    
    [HttpPost("AddUser")]
    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        return _data.AddUser(UserToAdd);
    }

    [HttpGet("GetAllUsers")]

    public IEnumerable<UserModel> GetAllUsers()
    {
            return _data.GetAllUsers();     
    }



    [HttpGet("GetUserByUserName")]
    public UserIdDTO GetUserDTOUserName(string username)
    {
        return _data.GetUserIdDTOByUserName(username);
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDTO User)
    {
        return _data.Login(User);
    }
    } 
        

