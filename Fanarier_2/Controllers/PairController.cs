using Microsoft.AspNetCore.Mvc;
using Fanarier_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fanarier_2.Controllers
{
    [Route("api/[controller]")]
    public class PairController : ControllerBase
    {
        private readonly DataContext _db;

        public PairController(DataContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IEnumerable<Pair> GetPairs()
        {
            return _db.Pairs.ToList();
        }

        [HttpPost]
        public void SavePair([FromBody] Pair pair)
        {
            _db.Pairs.Add(pair);
            _db.SaveChanges();
        }

        [HttpPut]
        public async Task<ActionResult<Pair>> Put(Pair user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!_db.Pairs.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _db.Update(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public void DeletePair(long id)
        {
            _db.Pairs.Remove(_db.Pairs.FirstOrDefault(p => p.Id == id));
            _db.SaveChanges();
        }
    }
}
