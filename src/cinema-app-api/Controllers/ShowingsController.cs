using cinema_app_api.DTO;
using cinema_app_api.Models;
using cinema_app_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowingsController : CrudController<Showings>
    {
        private readonly IBaseCrudService<Movies> _crudMovies;
        private readonly IBaseCrudService<Halls> _crudHalls;
        public ShowingsController(
            IBaseCrudService<Showings> _crud,
            IBaseCrudService<Movies> crudMovies,
            IBaseCrudService<Halls> crudHalls) : base(_crud)
        {
            _crudHalls = crudHalls;
            _crudMovies = crudMovies;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateShowingDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Hall == null || model.Hall == "") return BadRequest("No name");
            if (model.Movie == null || model.Movie == "") return BadRequest("No director");
            if (model.Time == null) return BadRequest("No time");

            var hall = _crudHalls.GetItem(model.Hall);
            var movie = _crudMovies.GetItem(model.Movie);

            var show = new Showings
            {
                Hall = hall,
                Movie = movie,
                Time = model.Time,
            };
            var entity = _crud.AddItem(show);

            return Ok(new { showing = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateShowingDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Hall == null || model.Hall == "") return BadRequest("No name");
            if (model.Movie == null || model.Movie == "") return BadRequest("No director");
            if (model.Time == null) return BadRequest("No time");

            var hall = _crudHalls.GetItem(model.Hall);
            var movie = _crudMovies.GetItem(model.Movie);

            var show = new Showings
            {
                Hall = hall,
                Movie = movie,
                Time = model.Time,
            };
            var entity = _crud.UpdateItem(id, show);
            return Ok(new { showing = entity });
        }
    }
}