using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApi.DTOs.Customers;
using RestApi.DTOs.Genres;
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
        public ActionResult<List<Genre>> Get()
        {
            try
            {
                return Ok(_genreService.GetAllGenre());
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GetGenreByIdDto> Get(int id)
        {
            var genreFromDto = _genreService.FindGenreById(id);
            return Ok(new GetGenreByIdDto()
            {
                Type = genreFromDto.Type
            });
        }

        [HttpPost]
        public ActionResult<PostGenreDto> Post([FromBody] PostGenreDto dto)
        {
            var genreDto = new Genre()
            {
                Type = dto.Type
            };
            try
            {
                var newGenre = _genreService.CreateNewGenre(genreDto);
                return Created($"https://localhost:5001/api/videos/{newGenre.Id}", newGenre);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public ActionResult<PutGenreDto> Put(int id, [FromBody] PutGenreDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Something went wrong");
            }

            return Ok(_genreService.UpdateGenre(new Genre()
            {
                Id = dto.Id,
                Type = dto.Type
            }));
        }

        [HttpDelete]
        public ActionResult<GetGenreByIdDto> Delete(int id)
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