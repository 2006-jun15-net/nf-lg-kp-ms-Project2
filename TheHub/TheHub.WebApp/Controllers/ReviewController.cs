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
        private readonly IReviewRepo _reviewRepository;
        private readonly IUserRepo _userRepository;
        public ReviewController(IReviewRepo reviewRepository, IUserRepo userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }
      

        // POST api/<ReviewController>
        [HttpPost("CreateReview")]
        public IActionResult CreateReveiw([FromBody] Review review)
        {
            Review newR = new Review
            {
                Rating = review.Rating,
                MediaId = review.MediaId,
                UserId = review.UserId,
                Content = review.Content
            };
            _reviewRepository.Add(newR);

            var newReview = _reviewRepository.GetById(newR.ReviewId);

            return Created(""+review.ReviewId+"",newReview);

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
