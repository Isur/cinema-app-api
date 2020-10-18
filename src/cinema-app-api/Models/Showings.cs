using System;

namespace cinema_app_api.Models
{
    public class Showings
    {
        public Guid Id { get; set; }
        public Movies Movie { get; set; }
        public Halls Hall { get; set; }
        public DateTime Time { get; set; }
    }
}