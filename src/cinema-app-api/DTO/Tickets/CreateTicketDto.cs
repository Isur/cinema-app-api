using System;
using cinema_app_api.Models;

namespace cinema_app_api.DTO {
    public class CreateTicketDto {
        public string Showing { get; set; }
        public string User { get; set; }
        public int FieldX { get; set; }
        public int FieldY { get; set; }
        public TicketStatus Status { get; set; }
    }
}