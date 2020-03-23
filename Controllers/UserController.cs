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
    public class UserController : ControllerBase
    {
        public UserRepository repository;

        public UserController(UserRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return repository.ReadAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return repository.Read(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            repository.Create(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            repository.Update(id,user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
