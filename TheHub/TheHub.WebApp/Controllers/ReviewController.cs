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
        private readonly IReviewRepo _reviewRepository;
        private readonly IUserRepo _userRepository;
        public ReviewController(IReviewRepo reviewRepository, IUserRepo userRepository, ICommentRepo commentRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
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
      
        [HttpGet("{id}")]
        public IActionResult getReviewById(int id)
        {
            return Ok(_reviewRepository.GetById(id));
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
        // POST api/<ReviewController>
        [HttpPost("CreateReview")]
        public IActionResult CreateReview([FromBody] Review review)
        {
            Review newR = new Review
            {
                Rating = review.Rating,
                MediaId = review.MediaId,
                UserId = review.UserId,
                Content = review.Content
            };
            int Reviewid =_reviewRepository.Add(newR);

            var newReview = _reviewRepository.GetById(Reviewid);

            return CreatedAtAction(nameof(getReviewById), new {id = Reviewid}, newReview);

        }
        //get reviews by media id
        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult GetReviewByMediaId(int id)
        {
            return Ok(_reviewRepository.GetByMediaId(id));
        }

        //get reviews of all the following
        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult GetReviewByFollowing(int id)
        {
            var following = _userRepository.GetFollowing(id);
            List<Review> followingReview = new List<Review>();

            foreach (var item in following)
            {
                foreach(var item2 in _reviewRepository.GetByUserId(item.UserId))
                {
                    followingReview.Add(item2);
                }
            }

            followingReview.Sort((x, y) => DateTime.Compare(x.ReviewDate, y.ReviewDate)); //still working

            return Ok(followingReview);
        }
    }
}
