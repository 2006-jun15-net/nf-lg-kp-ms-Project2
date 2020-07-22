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

        public ReviewController(IReviewRepo Repository)
        {
            _reviewRepository = Repository;
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
    }
}
