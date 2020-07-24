using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TheHub.DataAccess.Repository;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheHub.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepository;

        public UserController(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }

        //GET api/user/login
        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var user = _userRepository.GetByUserName(username);
                if(user.Password == password)
                {
                    return Ok(user);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (ArgumentNullException)
            {
                return Unauthorized();
            }
        }


        // GET api/user/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        // GET api/following/1
        [HttpGet("following/{id}")]
        public IActionResult GetFollowing(int id)
        {
            return Ok(_userRepository.GetFollowing(id));
        }

        // GET api/followers/1
        [HttpGet("followers/{id}")]
        public IActionResult GetFollowers(int id)
        {
            return Ok(_userRepository.GetFollowers(id));
        }



        // POST api/CreateUser
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
           _userRepository.Add(user);

           var newUser = _userRepository.GetByUserName(user.UserName);

            return CreatedAtAction(nameof(GetUserById),new { id = newUser.UserId }, newUser);
            
        }

        // Post api/follow/1/1
        [HttpPut("follow/{FollowerId}/{FollowingId}")]
        public IActionResult FollowUser(int FollowerId, int FollowingId)
        {
            _userRepository.AddFollower(FollowerId, FollowingId);
            return Ok();
        }


        // PUT api/Update/1
        [HttpPut("Update/{id}")]
        public IActionResult UpdateProfile([FromBody][Required] User user, int id)
        {
            user.UserId = id;
            _userRepository.Update(user);

            return Ok();
        }

        
       
    }
}
