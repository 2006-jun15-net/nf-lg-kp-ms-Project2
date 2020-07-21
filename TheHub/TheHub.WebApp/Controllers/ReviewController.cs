﻿using System;
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

        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
            var followers = _userRepository.GetFollowing(id);
            List<Review> followingReview = new List<Review>();

            foreach (var item in followers)
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