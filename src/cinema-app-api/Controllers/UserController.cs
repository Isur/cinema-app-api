using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using cinema_app_api.Data;
using cinema_app_api.DTO;
using cinema_app_api.Helpers;
using cinema_app_api.Models;
using cinema_app_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Worker")]
    public class UserController : CrudController<Users>
    {
        public UserController(IBaseCrudService<Users> crud) : base(crud) { }

        
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.FirstName == null || model.FirstName == "") return BadRequest("No name");
            if (model.LastName == null || model.LastName == "") return BadRequest("No name");
            if (model.UserName == null || model.UserName == "") return BadRequest("No name");
            if (model.Password == null || model.Password == "") return BadRequest("No name");

            var user = new Users
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                UserName = model.UserName,
                Password = PasswordHasher.Hash(model.Password),
            };
            var entity = _crud.AddItem(user);

            return Ok(new { user = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateUserDto model)
        {
            if (model == null) return BadRequest("No data");
            if (model.FirstName == null || model.FirstName == "") return BadRequest("No name");
            if (model.LastName == null || model.LastName == "") return BadRequest("No name");
            if (model.UserName == null || model.UserName == "") return BadRequest("No name");
            if (model.Password == null || model.Password == "") return BadRequest("No name");

            var user = new Users
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                UserName = model.UserName,
                Password = PasswordHasher.Hash(model.Password),
            };
            
            var entity = _crud.UpdateItem(id, user);
            return Ok(new { user = entity });
        }

    }
}