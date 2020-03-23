using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Repositories
{
    public class TicketRepository
    {
        public IEnumerable<Ticket> ReadAll()
        {
            return LoadData();
        }

        private List<Ticket> LoadData()
        {
            var dataString = File.ReadAllText("E:\\P R O D I G Y\\A C A D E M I C\\IUT SWE\\SEM 5\\CSE     4539         SERVER PROGRAMMING\\L A B\\SP_TicketManaegement\\Data\\Ticket.json");
            return JsonConvert.DeserializeObject<List<Ticket>>(dataString);
        }

        internal Ticket Read(Guid id)
        {
            var tickets = LoadData();
            return tickets.Find(ticket => ticket.Ticket_Guid == id);
        }

        internal void Create(Ticket ticket)
        {
            ticket.Ticket_Guid= Guid.NewGuid();
            var tickets = LoadData();
            tickets.Add(ticket);
            SaveData(tickets);

        }

        internal void Update(Guid id, Ticket ticket)
        {
            var tickets = LoadData();
            var ticketToUpdate = tickets.Find(ticket => ticket.Ticket_Guid == id);
            ticketToUpdate.TicketQuantity = ticket.TicketQuantity;
            ticketToUpdate.TicketPrice= ticket.TicketPrice;
            SaveData(tickets);
        }

        internal void Delete(Guid id)
        {
            var tickets = LoadData();
            var ticketToRemove = tickets.Find(ticket => ticket.Ticket_Guid == id);
            tickets.Remove(ticketToRemove);
            SaveData(tickets);
        }

        private void SaveData(List<Ticket> data)
        {
            var dataString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("E:\\P R O D I G Y\\A C A D E M I C\\IUT SWE\\SEM 5\\CSE     4539         SERVER PROGRAMMING\\L A B\\SP_TicketManaegement\\Data\\Ticket.json", dataString);
        }
    }
}
