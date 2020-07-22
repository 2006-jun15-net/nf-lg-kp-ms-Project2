using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheHub.Library.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheHub.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepo _commentRepository;
       
        public CommentController(ICommentRepo commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost("like/{commentId}/{userId}")]
        public IActionResult CommentLike(int commentId, int userId)
        {
            _commentRepository.CreateLike(commentId, userId);

            return Ok();
        }
    }
}
