using System;

namespace cinema_app_api.Models
{
    public class Movies
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
    }
}