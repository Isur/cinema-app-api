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
    public class UsersController : CrudController<Users>
    {
        private readonly IEncryptor _encryptor;
        public UsersController(IBaseCrudService<Users> crud, IEncryptor encryptor) : base(crud)
        {
            _encryptor = encryptor;
        }

        [HttpGet, Route("{id}")]
        override public Users Get(string id)
        {
            var entity = _crud.GetItem(id);
            entity.Password = null;
            entity.FirstName = _encryptor.Decrypt(entity.FirstName);
            entity.LastName = _encryptor.Decrypt(entity.LastName);
            return entity;
        }

        [HttpGet]
        override public List<Users> GetList()
        {
            var list = _crud.GetItems();
            foreach (var user in list)
            {
                user.Password = null;
                user.FirstName = _encryptor.Decrypt(user.FirstName);
                user.LastName = _encryptor.Decrypt(user.LastName);
            }
            return list;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto model)
        {
            if (model == null) return BadRequest("No data");
            if (string.IsNullOrEmpty(model.FirstName)) return BadRequest("No first name");
            if (string.IsNullOrEmpty(model.LastName)) return BadRequest("No last name");
            if (string.IsNullOrEmpty(model.UserName)) return BadRequest("No user name");
            if (string.IsNullOrEmpty(model.Password)) return BadRequest("No password");

            var user = new Users
            {
                FirstName = _encryptor.Encrypt(model.FirstName),
                LastName = _encryptor.Encrypt(model.LastName),
                Role = model.Role,
                UserName = model.UserName,
                Password = PasswordHasher.Hash(model.Password),
            };
            var entity = _crud.AddItem(user);
            if (entity == null) return BadRequest("User already exists");
            entity.Password = null;
            entity.FirstName = _encryptor.Decrypt(entity.FirstName);
            entity.LastName = _encryptor.Decrypt(entity.LastName);
            return Ok(new { user = entity });
        }

        [HttpPatch, Route("{id}")]
        public IActionResult Patch(string id, [FromBody] UpdateUserDto model)
        {
            if (model == null) return BadRequest("No data");
            if (string.IsNullOrEmpty(model.FirstName)) return BadRequest("No first name");
            if (string.IsNullOrEmpty(model.LastName)) return BadRequest("No last name");
            if (string.IsNullOrEmpty(model.UserName)) return BadRequest("No user name");

            var user = new Users
            {
                FirstName = _encryptor.Encrypt(model.FirstName),
                LastName = _encryptor.Encrypt(model.LastName),
                Role = model.Role,
                UserName = model.UserName,
            };

            var entity = _crud.UpdateItem(id, user);
            entity.Password = null;
            entity.FirstName = _encryptor.Decrypt(entity.FirstName);
            entity.LastName = _encryptor.Decrypt(entity.LastName);
            return Ok(new { user = entity });
        }

    }
}