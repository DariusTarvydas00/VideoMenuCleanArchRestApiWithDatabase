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
        public ActionResult<List<Video>> Get([FromQuery] Filter filter)
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
        public ActionResult<GetVideoByIdDto> Get(int id)
        {
            var video = _videoService.FindVideoById(id);
                return Ok(new GetVideoByIdDto()
                {
                    Title = video.Title,
                    StoryLine = video.StoryLine,
                    ReleaseTime = video.ReleaseDate,
                    Genre = video.Genre
                });
        }

        [HttpPost]
        public ActionResult<PostVideoDto> Post([FromBody] PostVideoDto dto)
        {
            var videoFromDto = new Video()
            {
                Title = dto.Title,
                StoryLine = dto.StoryLine,
                ReleaseDate = dto.ReleaseDate,
                Genre = new Genre()
                {
                    Id = dto.GenreEntityId
                }
            };
            try
            {
                var newVideo = _videoService.CreateNewVideo(videoFromDto);
                return Created($"https://localhost:5001/api/videos/{newVideo.Id}", newVideo);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<PutVideoDto> Put(int id, [FromBody] PutVideoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id on param must be the same as in object");
            }

            return Ok(_videoService.UpdateVideo(new Video()
            {
                Id = dto.Id,
                Title = dto.Title,
                StoryLine = dto.StoryLine,
                ReleaseDate = dto.ReleaseDate
            }));
        }

        [HttpDelete("{id}")]
        public ActionResult<GetVideoByIdDto> Delete(int id)
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