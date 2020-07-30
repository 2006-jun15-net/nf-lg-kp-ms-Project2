using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheHub.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {

        private readonly IMediaRepo _mediaRepository;
        private readonly IMediaTypeRepo _mediaTypeRepository;
        private readonly IGenreRepo _genreRepository;


        public MediaController(IMediaRepo mediaRepository, IMediaTypeRepo mediaTypeRepo, IGenreRepo genreRepository)
        {
            _mediaRepository = mediaRepository;
            _mediaTypeRepository = mediaTypeRepo;
            _genreRepository = genreRepository;
        }
        // GET: api/<MediaController>
        

        // GET api/<MediaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetMediaById(int id)
        {
            var currentMedia = _mediaRepository.GetById(id);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetById(id));
            }
        }

        /// <summary>
        /// get media by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        // GET api/<MediaController>
        [HttpGet("title/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaByTitle(string title)
        {
            var currentMedia = _mediaRepository.GetByTitle(title);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByTitle(title));
            }
        }

        [HttpGet("genreid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetGenreById(int id)
        {
            var currentGenre = _genreRepository.GetById(id);

            if (currentGenre == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_genreRepository.GetById(id));
            }
        }

        /// <summary>
        /// get medias by genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        // GET api/<MediaController>/5
        [HttpGet("genre/{genre}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaByGenre(string genre)
        {
            var currentMedia = _mediaRepository.GetByGenre(genre);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByGenre(genre));
            }
        }

        /// <summary>
        /// get medias by number of reviews
        /// </summary>
        /// <param name="reviewCount"></param>
        /// <returns></returns>
        [HttpGet("reviewcount/{reviewCount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaByReviewCount(int reviewCount)
        {
            var currentMedia = _mediaRepository.GetByReviewcount(reviewCount);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByReviewcount(reviewCount));
            }
        }

        /// <summary>
        /// get medias by number of rating
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpGet("rating/{rating}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaByRating(int rating)
        {
            var currentMedia = _mediaRepository.GetByRating(rating);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByRating(rating));
            }
        }

        /// <summary>
        /// get media by composer
        /// </summary>
        /// <param name="composer"></param>
        /// <returns></returns>
        [HttpGet("composer/{composer}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaByComposer(string composer)
        {
            var currentMedia = _mediaRepository.GetByComposer(composer);

            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByComposer(composer));
            }
        }

        // POST api/<MediaController>
        [HttpPost("CreateMedia")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateMedia([FromBody] Media media)
        {
            _mediaRepository.Add(media);

            var newMedia = _mediaRepository.GetByTitle(media.MediaName);

            return CreatedAtAction(nameof(GetMediaById), new { id = newMedia.MediaId }, newMedia);
        }

        // PUT api/<MediaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMedia(int id, [FromBody] Media media)
        {
           
            var currentMedia = _mediaRepository.GetById(id);
            if (currentMedia == null)
            {
                return NotFound();
            }
            else
            {
                
                _mediaRepository.Update(media);

                return CreatedAtAction(nameof(GetMediaById), new { id = currentMedia.MediaId }, media);
                
            }
     
            

        }
        //GET api/media/5/rating
        [HttpGet("{id}/rating")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMediaRating(int id)
        {
            try
            {
                var media = _mediaRepository.GetById(id);
                return Ok(media.Rating);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        // DELETE api/<MediaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveMedia(int id)
        {
            var currentMedia = _mediaRepository.GetById(id);

            if (currentMedia == null)
            {
                return BadRequest();
            }
            else
            {
                _mediaRepository.Delete(currentMedia.MediaId);
                return Ok();
            }
        }

        [HttpGet("UnapprovedMedia")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUnapprovedMedia()
        {
            var unapprovedMedias = _mediaRepository.GetUnapprovedMedia();
            if (unapprovedMedias == null)
            {
                return NotFound();
            }
            else {
                return Ok(_mediaRepository.GetUnapprovedMedia());
            }
        }

        [HttpGet("MediaType/{id}")]

        public IActionResult GetByMediaType (int id)
        {
            var mediaType = _mediaTypeRepository.GetById(id);

            if (mediaType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mediaRepository.GetByMediaType(mediaType.Name));
            }



        }
    }
}
