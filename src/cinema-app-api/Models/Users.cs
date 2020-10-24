using System;
using System.Collections.Generic;

namespace cinema_app_api.Models
{
    public partial class Users
    {
        public Users() {
            this.Tickets = new HashSet<Tickets>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}