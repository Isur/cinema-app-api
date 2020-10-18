using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using cinema_app_api.Data;
using cinema_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cinema_app_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DataContext _context;

        public UserController(ILogger<UserController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet("users")]
        [Authorize]
        public DbSet<Users> Get()
        {
            var users = _context.Users;
            return users;
        }
    }
}