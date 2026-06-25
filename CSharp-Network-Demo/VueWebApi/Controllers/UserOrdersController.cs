using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueWebApi.Models;

namespace VueWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
        private readonly OnlineShopContext _context;

        public UserOrdersController(OnlineShopContext context)
        {
            _context = context;
        }

        // GET: api/UserOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOrder>>> GetUserOrders()
        {
          if (_context.UserOrders == null)
          {
              return NotFound();
          }
            return await _context.UserOrders.ToListAsync();
        }

        // GET: api/UserOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOrder>> GetUserOrder(int id)
        {
          if (_context.UserOrders == null)
          {
              return NotFound();
          }
            var userOrder = await _context.UserOrders.FindAsync(id);

            if (userOrder == null)
            {
                return NotFound();
            }

            return userOrder;
        }

        // PUT: api/UserOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOrder(int id, UserOrder userOrder)
        {
            if (id != userOrder.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(userOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOrderExists(id))
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

        // POST: api/UserOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOrder>> PostUserOrder(UserOrder userOrder)
        {
          if (_context.UserOrders == null)
          {
              return Problem("Entity set 'OnlineShopContext.UserOrders'  is null.");
          }
            _context.UserOrders.Add(userOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOrder", new { id = userOrder.OrderId }, userOrder);
        }

        // DELETE: api/UserOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOrder(int id)
        {
            if (_context.UserOrders == null)
            {
                return NotFound();
            }
            var userOrder = await _context.UserOrders.FindAsync(id);
            if (userOrder == null)
            {
                return NotFound();
            }

            _context.UserOrders.Remove(userOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserOrderExists(int id)
        {
            return (_context.UserOrders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
