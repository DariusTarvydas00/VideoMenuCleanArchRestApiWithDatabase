using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.Entity;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> Get()
        {
            return _videoService.GetAllVideos();
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            try
            {
                return Ok(_videoService.FindVideoById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Video> Post([FromBody] Video video)
        {
            if (string.IsNullOrEmpty(video.Title) || string.IsNullOrEmpty(video.StoryLine) || string.IsNullOrEmpty(video.Genre.Type) 
                || string.IsNullOrEmpty(video.ReleaseDate.ToString()) || video.Customer == null)
            {
                return BadRequest("Some fields are entered incorrectly");
            }

            return Ok(_videoService.CreateNewVideo(video));
        }

        [HttpPut]
        public ActionResult<Video> Put(int id, [FromBody] Video Video)
        {
            if (id < 1 || id != Video.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_videoService.UpdateVideo(Video));
        }

        [HttpDelete]
        public ActionResult<Genre> Delete(int id)
        {
            var Genre = _videoService.DeleteVideo(id);
            if (Genre == null)
            {
                return StatusCode(404, "Did not found any Genre");
            }

            return Ok("Genre was deleted");
        }

    }
}