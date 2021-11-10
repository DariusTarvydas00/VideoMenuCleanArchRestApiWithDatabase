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
        
    }
}