using System;

namespace cinema_app_api.DTO
{
    public class UpdateTicketDto
    {
        public string Showing { get; set; }
        public string User { get; set; }
        public int FieldX { get; set; }
        public int FieldY { get; set; }
    }
}