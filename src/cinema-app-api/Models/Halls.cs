using System;
using System.Collections.Generic;

namespace cinema_app_api.Models
{
    public partial class Halls
    {

        public Halls() {
            this.Showings = new HashSet<Showings>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public virtual ICollection<Showings> Showings { get; set; }
    }
}