using System;
using System.Collections.Generic;

namespace cinema_app_api.Models
{
    public partial class Showings
    {
        public Showings() {
            this.Tickets = new HashSet<Tickets>();
        }
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
        public DateTime Time { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual Halls Hall { get; set; }
        public virtual Movies Movie { get; set; }
    }
}