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
    public class ReviewController : Controller
    {
        private readonly IReviewRepo _reviewRepository;
        private readonly IUserRepo _userRepository;

        public ReviewController(IReviewRepo reviewRepository, IUserRepo userRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
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
