using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string PhoneNo { get; set; }
    }
}
