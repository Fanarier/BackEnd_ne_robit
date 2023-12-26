using Microsoft.AspNetCore.Mvc;
using Fanarier_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fanarier_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _db;

        public ClientController(DataContext ctx)
        {
            _db = ctx;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _db.Clients.Where(p => p.HasPair == false).ToList();
        }

        [HttpGet("{id}")]
        public Client GetClient(int id)
        {
            return _db.Clients.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void SaveClient([FromBody] Client client)
        {
            if (client != null)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!_db.Clients.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _db.Update(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(long id)
        {
            _db.Clients.Remove(_db.Clients.FirstOrDefault(p => p.Id == id));
            _db.SaveChanges();
        }
    }
}
