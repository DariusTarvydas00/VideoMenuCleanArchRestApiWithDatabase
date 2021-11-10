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
        private readonly IVideoService _VideoService;

        public VideoController(IVideoService VideoService)
        {
            _VideoService = VideoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> Get()
        {
            return _VideoService.GetAllVideos();
        }
        
    }
}