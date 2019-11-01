using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCRateAndFeedbackService.Models;

namespace TCRateAndFeedbackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewTypesController : ControllerBase
    {
        private readonly TCRateAndFeedbackDBContext _context;

        public UserReviewTypesController(TCRateAndFeedbackDBContext context)
        {
            _context = context;
        }

        // GET: api/UserReviewTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReviewType>>> GetUserReviewType()
        {
            return await _context.UserReviewType.ToListAsync();
        }

        // GET: api/UserReviewTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReviewType>> GetUserReviewType(byte id)
        {
            var UserReviewType = await _context.UserReviewType.FindAsync(id);

            if (UserReviewType == null)
            {
                return NotFound();
            }

            return UserReviewType;
        }

        // PUT: api/UserReviewTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserReviewType(byte id, UserReviewType UserReviewType)
        {
            if (id != UserReviewType.LngRatingId)
            {
                return BadRequest();
            }

            _context.Entry(UserReviewType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserReviewTypeExists(id))
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

        // POST: api/UserReviewTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserReviewType>> PostUserReviewType(UserReviewType UserReviewType)
        {
            _context.UserReviewType.Add(UserReviewType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserReviewType", new { id = UserReviewType.LngRatingId }, UserReviewType);
        }

        // DELETE: api/UserReviewTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserReviewType>> DeleteUserReviewType(byte id)
        {
            var UserReviewType = await _context.UserReviewType.FindAsync(id);
            if (UserReviewType == null)
            {
                return NotFound();
            }

            _context.UserReviewType.Remove(UserReviewType);
            await _context.SaveChangesAsync();

            return UserReviewType;
        }

        private bool UserReviewTypeExists(byte id)
        {
            return _context.UserReviewType.Any(e => e.LngRatingId == id);
        }
    }
}
