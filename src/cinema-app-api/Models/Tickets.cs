using System;

namespace cinema_app_api.Models
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public Showings Showing { get; set; }
        public Users User { get; set; }
        public int FieldX { get; set; }
        public int FieldY { get; set; }
    }
}