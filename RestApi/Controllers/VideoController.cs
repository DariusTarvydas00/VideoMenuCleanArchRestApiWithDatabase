using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.DTOs.Videos;
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
        public ActionResult<IEnumerable<Video>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_videoService.GetFilteredOrders(filter));
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong");
            }
            // return Ok(_videoService.GetFilteredOrders(filter));
            // return _videoService.GetAllVideos();
        }

        [HttpGet("{id}")]
        public ActionResult<Video> Get(int id)
        {
            var video = _videoService.FindVideoById(id);
            try
            {
                return Ok(new GetVideoByIdDto()
                {
                    Title = video.Title,
                    StoryLine = video.StoryLine,
                    DateTime = video.ReleaseDate
                });
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
        public ActionResult<Video> Put(int id, [FromBody] Video video)
        {
            if (id < 1 || id != video.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_videoService.UpdateVideo(video));
        }

        [HttpDelete]
        public ActionResult<Genre> Delete(int id)
        {
            var genre = _videoService.DeleteVideo(id);
            if (genre == null)
            {
                return StatusCode(404, "Did not found any Video");
            }

            return Ok("Video was deleted");
        }

    }
}