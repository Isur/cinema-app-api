using System;

namespace cinema_app_api.Models
{
    public partial class Tickets
    {
        public Guid Id { get; set; }
        public Guid ShowingId { get; set; }
        public Guid UserId { get; set; }
        public int FieldX { get; set; }
        public int FieldY { get; set; }
        
        public TicketStatus Status { get; set; }

        public virtual Showings Showing { get; set; }
        public virtual Users User { get; set; }

    }
}