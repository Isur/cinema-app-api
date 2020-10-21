using cinema_app_api.Models;

namespace cinema_app_api.DTO
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}