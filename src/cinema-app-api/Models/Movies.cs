using System;
using System.Collections.Generic;

namespace cinema_app_api.Models
{
    public partial class Movies
    {
        public Movies() {
            this.Showings = new HashSet<Showings>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

        public virtual ICollection<Showings> Showings { get; set; }
    }
}