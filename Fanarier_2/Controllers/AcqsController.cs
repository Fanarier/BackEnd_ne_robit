using Microsoft.AspNetCore.Mvc;
using Fanarier_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fanarier_2.Controllers
{
    [Route("api/[controller]")]
    public class AcqsController : ControllerBase
    {
        private readonly DataContext _db;

        public AcqsController(DataContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IEnumerable<Acq> GetAcqs()
        {
            return _db.Acqs.ToList();
        }

        [HttpPost]
        public void SaveAcq([FromBody] Acq acq)
        {
            _db.Acqs.Add(acq);
            _db.SaveChanges();
        }

        [HttpPut]
        public async Task<ActionResult<Acq>> Put(Acq user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (!_db.Acqs.Any(x => x.Id == user.Id))
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
            _db.Acqs.Remove(_db.Acqs.FirstOrDefault(p => p.Id == id));
            _db.SaveChanges();
        }
    }
}
