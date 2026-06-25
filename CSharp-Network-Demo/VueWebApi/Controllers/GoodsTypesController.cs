using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueWebApi.Models;

namespace VueWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsTypesController : ControllerBase
    {
        private readonly OnlineShopContext _context;

        public GoodsTypesController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: api/GoodsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodsType>>> GetGoodsTypes()
        {
          if (_context.GoodsTypes == null)
          {
              return NotFound();
          }
            return await _context.GoodsTypes.ToListAsync();
        }

        // GET: api/GoodsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodsType>> GetGoodsType(int id)
        {
          if (_context.GoodsTypes == null)
          {
              return NotFound();
          }
            var goodsType = await _context.GoodsTypes.FindAsync(id);

            if (goodsType == null)
            {
                return NotFound();
            }

            return goodsType;
        }

        // PUT: api/GoodsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoodsType(int id, GoodsType goodsType)
        {
            if (id != goodsType.GoodsTypeId)
            {
                return BadRequest();
            }

            _context.Entry(goodsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsTypeExists(id))
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

        // POST: api/GoodsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GoodsType>> PostGoodsType(GoodsType goodsType)
        {
          if (_context.GoodsTypes == null)
          {
              return Problem("Entity set 'OnlineShopContext.GoodsTypes'  is null.");
          }
            _context.GoodsTypes.Add(goodsType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoodsType", new { id = goodsType.GoodsTypeId }, goodsType);
        }

        // DELETE: api/GoodsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoodsType(int id)
        {
            if (_context.GoodsTypes == null)
            {
                return NotFound();
            }
            var goodsType = await _context.GoodsTypes.FindAsync(id);
            if (goodsType == null)
            {
                return NotFound();
            }

            _context.GoodsTypes.Remove(goodsType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoodsTypeExists(int id)
        {
            return (_context.GoodsTypes?.Any(e => e.GoodsTypeId == id)).GetValueOrDefault();
        }
    }
}
