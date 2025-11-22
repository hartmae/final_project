using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Food?id=null or api/Food?id=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods(int? id)
        {
            if (id == null || id == 0)
            {
                // Return first 5 results
                return await _context.Foods.Take(5).ToListAsync();
            }
            else
            {
                // Return specific food
                var food = await _context.Foods.FindAsync(id);
                if (food == null)
                {
                    return NotFound();
                }
                return new List<Food> { food };
            }
        }

        // POST: api/Food
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, food);
        }

        // PUT: api/Food/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }
    }
}