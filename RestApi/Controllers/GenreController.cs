using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.Entity;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
            private readonly IGenreService _GenreService;

            public GenreController(IGenreService GenreService)
            {
                _GenreService = GenreService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Genre>> Get()
            {
                return _GenreService.GetAllGenre();
            }
        
    }
}