using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardPaymentAPI.Data;
using CardPaymentAPI.Models;

namespace CardPaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCardDetailsController : ControllerBase
    {
        private readonly CardPaymentsDbContext _context;

        public UserCardDetailsController(CardPaymentsDbContext context)
        {
            _context = context;
        }

        // GET: api/UserCardDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCardDetails>>> GetUsersCardsDetails()
        {
          if (_context.UsersCardsDetails == null)
          {
              return NotFound();
          }
            return await _context.UsersCardsDetails.ToListAsync();
        }

        // GET: api/UserCardDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCardDetails>> GetUserCardDetails(int id)
        {
          if (_context.UsersCardsDetails == null)
          {
              return NotFound();
          }
            var userCardDetails = await _context.UsersCardsDetails.FindAsync(id);

            if (userCardDetails == null)
            {
                return NotFound();
            }

            return userCardDetails;
        }

        // PUT: api/UserCardDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCardDetails(int id, UserCardDetails userCardDetails)
        {
            if (id != userCardDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCardDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCardDetailsExists(id))
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

        // POST: api/UserCardDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCardDetails>> PostUserCardDetails(UserCardDetails userCardDetails)
        {
          if (_context.UsersCardsDetails == null)
          {
              return Problem("Entity set 'CardPaymentsDbContext.UsersCardsDetails'  is null.");
          }
            _context.UsersCardsDetails.Add(userCardDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCardDetails", new { id = userCardDetails.Id }, userCardDetails);
        }

        // DELETE: api/UserCardDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCardDetails(int id)
        {
            if (_context.UsersCardsDetails == null)
            {
                return NotFound();
            }
            var userCardDetails = await _context.UsersCardsDetails.FindAsync(id);
            if (userCardDetails == null)
            {
                return NotFound();
            }

            _context.UsersCardsDetails.Remove(userCardDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCardDetailsExists(int id)
        {
            return (_context.UsersCardsDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
