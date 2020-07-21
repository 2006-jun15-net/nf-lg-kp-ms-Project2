using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        // POST api/<UserController>
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
           _userRepository.Add(user);

           var newUser = _userRepository.GetByUserName(user.UserName);

            return CreatedAtAction(nameof(GetUserById),new { id = newUser.UserId }, newUser);
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("Update/{id}")]
        public IActionResult UpdateProfile([FromBody] User user)
        {
                _userRepository.Update(user);

                return Ok();

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
