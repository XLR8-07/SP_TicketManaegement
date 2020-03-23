using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Models;
using TicketManagement.Repositories;

namespace TicketManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public TicketRepository repository;
        public TicketController(TicketRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return repository.ReadAll();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public Ticket Get(Guid id)
        {
            return repository.Read(id);
        }

        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] Ticket ticket)
        {
            repository.Create(ticket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Ticket ticket)
        {
            repository.Update(id, ticket);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
