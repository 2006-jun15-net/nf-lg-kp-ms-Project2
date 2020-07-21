using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheHub.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ICommentRepo _commentRepository;

        public ReviewController(ICommentRepo commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET api/review/comment/5
        [HttpGet("comment/{id}")]
        public IActionResult GetCommentById(int id)
        {
            if(_commentRepository.GetById(id) != null)
            {
                var comment = _commentRepository.GetById(id);
                return Ok(comment);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST api/review/AddComment
        [HttpPost("AddComment")]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            try
            {
                int CommentId = _commentRepository.Add(comment);
                var newComment = _commentRepository.GetById(CommentId);
                return CreatedAtAction(nameof(GetCommentById), new { id = CommentId }, newComment);
            }
            catch (InvalidOperationException)
            {
                return Conflict();
            }
            
      
        }

    }
}
