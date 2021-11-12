using System;
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

        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            try
            {
                return Ok(_genreService.FindGenreById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Genre> Post([FromBody] Genre Genre)
        {
            if (string.IsNullOrEmpty(Genre.Type))
            {
                return BadRequest("Some fields are entered incorrectly");
            }

            return Ok(_genreService.CreateNewGenre(Genre));
        }

        [HttpPut]
        public ActionResult<Genre> Put(int id, [FromBody] Genre Genre)
        {
            if (id < 1 || id != Genre.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_genreService.UpdateGenre(Genre));
        }

        [HttpDelete]
        public ActionResult<Genre> Delete(int id)
        {
            var Genre = _genreService.DeleteGenre(id);
            if (Genre == null)
            {
                return StatusCode(404, "Did not found any Genre");
            }

            return Ok("Genre was deleted");
        }
    }
}