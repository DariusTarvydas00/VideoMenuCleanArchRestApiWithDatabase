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
            private readonly IGenreService _genreService;

            public GenreController(IGenreService genreService)
            {
                _genreService = genreService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Genre>> Get()
            {
                return _genreService.GetAllGenre();
            }
        
    }
}