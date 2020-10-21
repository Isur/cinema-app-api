using cinema_app_api.DTO;
using cinema_app_api.Models;
using cinema_app_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : CrudController<Tickets>
    {
        private readonly IBaseCrudService<Showings> _crudShowings;
        private readonly IBaseCrudService<Users> _crudUsers;
        public TicketsController(
            IBaseCrudService<Tickets> _crud,
            IBaseCrudService<Showings> crudShowings,
            IBaseCrudService<Users> crudUsers) : base(_crud)
        {
            _crudShowings = crudShowings;
            _crudUsers = crudUsers;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTicketDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Showing == null || model.Showing == "") return BadRequest("No name");
            if (model.User == null || model.User == "") return BadRequest("No director");
            if(model.FieldX == 0) return BadRequest("No fieldX");
            if(model.FieldY == 0) return BadRequest("No fieldY");

            var user = _crudUsers.GetItem(model.User);
            var show = _crudShowings.GetItem(model.Showing);

            var ticket = new Tickets
            {
                Showing = show,
                User = user,
                FieldX = model.FieldX,
                FieldY = model.FieldY,
            };
            var entity = _crud.AddItem(ticket);

            return Ok(new { movie = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateTicketDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Showing == null || model.Showing == "") return BadRequest("No name");
            if (model.User == null || model.User == "") return BadRequest("No director");
            if(model.FieldX == 0) return BadRequest("No fieldX");
            if(model.FieldY == 0) return BadRequest("No fieldY");

            var user = _crudUsers.GetItem(model.User);
            var show = _crudShowings.GetItem(model.Showing);

            var ticket = new Tickets
            {
                Showing = show,
                User = user,
                FieldX = model.FieldX,
                FieldY = model.FieldY,
            };
            
            var entity = _crud.UpdateItem(id, ticket);
            return Ok(new { movie = entity });
        }
    }
}