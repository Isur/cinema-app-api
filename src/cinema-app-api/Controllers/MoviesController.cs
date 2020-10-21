using cinema_app_api.DTO;
using cinema_app_api.Models;
using cinema_app_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : CrudController<Movies>
    {
        public MoviesController(IBaseCrudService<Movies> _crud) : base(_crud) { }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Title == "" || model.Title == null) return BadRequest("No name");
            if (model.Director == "" || model.Director == null) return BadRequest("No director");
            if (model.Year == 0) return BadRequest("No year");

            var movie = new Movies
            {
                Director = model.Director,
                Title = model.Title,
                Year = model.Year,
            };
            var entity = _crud.AddItem(movie);

            return Ok(new { movie = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateMovieDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Title == "" || model.Title == null) return BadRequest("No name");
            if (model.Director == "" || model.Director == null) return BadRequest("No director");
            if (model.Year == 0) return BadRequest("No year");

            var movie = new Movies
            {
                Director = model.Director,
                Title = model.Title,
                Year = model.Year,
            };

            var entity = _crud.UpdateItem(id, movie);
            return Ok(new { movie = entity });
        }
    }
}