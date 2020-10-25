using cinema_app_api.DTO;
using cinema_app_api.Models;
using cinema_app_api.Repository;
using cinema_app_api.Repository.ExtendedRepositories;
using Microsoft.AspNetCore.Mvc;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : CrudController<Tickets>
    {
        private new readonly ITicketRepository _crud;
        private readonly IBaseCrudService<Showings> _crudShowings;
        private readonly IBaseCrudService<Users> _crudUsers;
        public TicketsController(
            ITicketRepository crud,
            IBaseCrudService<Showings> crudShowings,
            IBaseCrudService<Users> crudUsers) : base(crud)
        {
            _crudShowings = crudShowings;
            _crudUsers = crudUsers;
            _crud = crud;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTicketDto model)
        {
            if (model == null) return BadRequest("No data");
            if (string.IsNullOrEmpty(model.Showing)) return BadRequest("No Showing");
            if (string.IsNullOrEmpty(model.User)) return BadRequest("No User");
            if(model.FieldX <= 0) return BadRequest("No fieldX");
            if(model.FieldY <= 0) return BadRequest("No fieldY");
            
            var placeIsFree = _crud.CheckIfFree(model.FieldX, model.FieldY);
            if (!placeIsFree) return BadRequest("Slot taken");

            var user = _crudUsers.GetItem(model.User);
            var show = _crudShowings.GetItem(model.Showing);
            
            if (show.Hall.SizeX < model.FieldX) return BadRequest("Wrong slot");
            if (show.Hall.SizeY < model.FieldY) return BadRequest("Wrong slot");

            var ticket = new Tickets
            {
                Showing = show,
                User = user,
                FieldX = model.FieldX,
                FieldY = model.FieldY,
                Status = model.Status,
            };
            var entity = _crud.AddItem(ticket);

            return Ok(new { ticket = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateTicketDto model)
        {
            if (model == null) return BadRequest("No data");
            if (string.IsNullOrEmpty(model.Showing)) return BadRequest("No Showing");
            if (string.IsNullOrEmpty(model.User)) return BadRequest("No User");
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
                Status = model.Status,
            };
            
            var entity = _crud.UpdateItem(id, ticket);
            return Ok(new { ticket = entity });
        }
    }
}