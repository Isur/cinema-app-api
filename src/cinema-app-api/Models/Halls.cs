using System;

namespace cinema_app_api.Models
{
    public class Halls
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
    }
}