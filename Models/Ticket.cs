using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Models
{
    public class Ticket
    {
        public Guid Ticket_Guid { get; set; }
        public string VehicleType { get; set; }
        public int TicketPrice { get; set; }
        public int TicketQuantity { get; set; }
    }
}
