using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cinema_app_api.Data;
using cinema_app_api.DTO;
using cinema_app_api.Helpers;
using cinema_app_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace cinema_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, DataContext
            context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            if (user == null)
            {
                return BadRequest("Data not provided");
            }
            var dbUser = await _context.Users.FirstOrDefaultAsync(db => db.UserName == user.UserName);

            if (dbUser == null) return Unauthorized("Wrong password or username");
            if (!PasswordHasher.Verify(user.Password, dbUser.Password)) return Unauthorized();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Security:SecretKey")));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dbUser.UserName),
                    new Claim(ClaimTypes.Role, RoleHelper.RoleToString(dbUser.Role)),
                },
                expires: DateTime.Now.AddHours(8),
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new
            {
                Token = tokenString,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                UserName = dbUser.UserName,
                Role = RoleHelper.RoleToString(dbUser.Role),
            });
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO user)
        {
            if (user == null)
            {
                return BadRequest("Data not provided");
            }

            var existing = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existing != null) return BadRequest("User already exists!");

            var u = new Users
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = PasswordHasher.Hash(user.Password),
            };

            var us = await _context.Users.AddAsync(u);
            await _context.SaveChangesAsync();
            return Ok(new { id = us.Entity.Id });
        }
    }
}