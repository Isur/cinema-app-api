using System.Threading.Tasks;
using cinema_app_api.Data;
using cinema_app_api.Models;
using cinema_app_api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using cinema_app_api.Repository;
using System.Collections.Generic;

namespace cinema_app_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HallsController : CrudController<Halls>
    {
        public HallsController(IBaseCrudService<Halls> crud) : base(crud) { }

        [HttpPost]
        public IActionResult PostHalls(CreateHallDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.Name == "" || model.Name == null) return BadRequest("No Name");
            if (model.SizeX == 0) return BadRequest("No SizeX");
            if (model.SizeY == 0) return BadRequest("No SizeY");
            var hall = new Halls
            {
                Name = model.Name,
                SizeX = model.SizeX,
                SizeY = model.SizeY,
            };
            var newHall = _crud.AddItem(hall);

            return Ok(new { hall = newHall });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult PatchHalls(string id, UpdateHallDto model)
        {
            var hall = new Halls
            {
                Name = model.Name,
                SizeX = model.SizeX,
                SizeY = model.SizeY,
            };
            var newHall = _crud.UpdateItem(id, hall);
            return Ok(new { hall = newHall });
        }

    }
}