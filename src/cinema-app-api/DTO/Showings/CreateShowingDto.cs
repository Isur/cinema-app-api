using System;

namespace cinema_app_api.DTO
{
    public class CreateShowingDto
    {
        public string Movie { get; set; }
        public string Hall { get; set; }
        public DateTime Time { get; set; }
    }
}