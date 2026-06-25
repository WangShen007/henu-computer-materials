using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueWebApi.Models;

namespace VueWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly OnlineShopContext _context;

        public GoodsController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Good>>> GetGoods()
        {
          if (_context.Goods == null)
          {
              return NotFound();
          }
            return await _context.Goods.ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Good>> GetGood(int id)
        {
          if (_context.Goods == null)
          {
              return NotFound();
          }
            var good = await _context.Goods.FindAsync(id);

            if (good == null)
            {
                return NotFound();
            }

            return good;
        }

        // PUT: api/Goods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGood(int id, Good good)
        {
            if (id != good.GoodsId)
            {
                return BadRequest();
            }

            _context.Entry(good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Goods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Good>> PostGood(Good good)
        {
          if (_context.Goods == null)
          {
              return Problem("Entity set 'OnlineShopContext.Goods'  is null.");
          }
            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGood", new { id = good.GoodsId }, good);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGood(int id)
        {
            if (_context.Goods == null)
            {
                return NotFound();
            }
            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoodExists(int id)
        {
            return (_context.Goods?.Any(e => e.GoodsId == id)).GetValueOrDefault();
        }
    }
}
