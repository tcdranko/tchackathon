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
    public class UserReviewsController : ControllerBase
    {
        private readonly TCRateAndFeedbackDBContext _context;

        public UserReviewsController(TCRateAndFeedbackDBContext context)
        {
            _context = context;
        }

        // GET: api/UserReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReview>>> GetUserReview()
        {
            return await _context.UserReview.Include(p => p.IntRating).ToListAsync();
        }

        // GET: api/UserReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReview>> GetUserReview(int id)
        {
            var UserReview = await _context.UserReview.Include(p => p.IntRating).FirstOrDefaultAsync(p => p.LngReviewId == id);

            if (UserReview == null)
            {
                return NotFound();
            }

            return UserReview;
        }

        // PUT: api/UserReviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutUserReview(int id, UserReview UserReview)
        {
            if (id != UserReview.LngReviewId)
            {
                return BadRequest();
            }

            _context.Entry(UserReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/UserReviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserReview>> PostUserReview(UserReview UserReview)
        {
            _context.UserReview.Add(UserReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserReview", new { id = UserReview.LngReviewId }, UserReview);
        }

        // DELETE: api/UserReviews/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<UserReview>> DeleteUserReview(int id)
        {
            var UserReview = await _context.UserReview.FindAsync(id);
            if (UserReview == null)
            {
                return NotFound();
            }

            _context.UserReview.Remove(UserReview);
            await _context.SaveChangesAsync();

            return UserReview;
        }*/

        private bool UserReviewExists(int id)
        {
            return _context.UserReview.Any(e => e.LngReviewId == id);
        }
    }
}
