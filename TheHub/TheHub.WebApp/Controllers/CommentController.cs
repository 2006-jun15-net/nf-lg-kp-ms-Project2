using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheHub.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepository;
        private readonly IUserRepo _userRepository;

        public CommentController(ICommentRepo commentRepository, IUserRepo userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        [HttpPost("like/{commentId}/{userId}")]
        public IActionResult CommentLike(int commentId, int userId)
        {
            _commentRepository.CreateLike(commentId, userId);

            return Ok();
        }
        [HttpDelete("delete/{commentId}")]
        public IActionResult DeleteComment([FromBody] string username,int commentId)
        {
            var user = _userRepository.GetByUserName(username);
            if (user.AdminUser)
            {
                _commentRepository.DeleteById(commentId);
            return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
