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

        public MediaController(IMediaRepo mediaRepository)
        {
            _mediaRepository = mediaRepository;
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
                
                _mediaRepository.Update(currentMedia);

                return CreatedAtAction(nameof(GetMediaById), new { id = currentMedia.MediaId }, currentMedia);
                
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
    }
}
