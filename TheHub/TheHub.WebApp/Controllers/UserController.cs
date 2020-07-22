using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly IReviewRepo _reviewRepository;
        private readonly ICommentRepo _commentRepository;

        public UserController(IUserRepo userRepository, IReviewRepo reviewRepository, ICommentRepo commentRepository)
        {
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _commentRepository = commentRepository;
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
        [HttpPut("Update/{id}")]
        public IActionResult UpdateProfile([FromBody][Required] User user)
        {
                _userRepository.Update(user);

                return Ok();
        }

        //like reviews
        [HttpPost("/{id}")] // not sure what the path would be for this
        public IActionResult ReviewLike([FromBody] bool status, int id)
        {
            if (status == false)
                return NotFound();

            var review = _reviewRepository.GetById(id);
            review.Likes += 1;
            _reviewRepository.Save();

            return Ok(review.Likes);
        }

        //like comments
        [HttpPost("/{id}")] // not sure what the path would be for this
        public IActionResult CommentLike([FromBody] bool status, int id)
        {
            if (status == false)
                return NotFound();

            var comment = _commentRepository.GetById(id);
            comment.Likes += 1;
            _commentRepository.Save();

            return Ok(comment.Likes);
        }

    }
}
