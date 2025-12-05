using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToOneAPI_Demo.Data;
using OneToOneAPI_Demo.Models;

namespace OneToOneAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/person
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await _context.Persons
                .Include(p => p.Passport)  // include related Passport
                .ToListAsync();

            return Ok(people);
        }

        // GET: api/person/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _context.Persons
                .Include(p => p.Passport)
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST: api/person
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.PersonId }, person);
        }

        // PUT: api/person/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Person person)
        {
            if (id != person.PersonId)
                return BadRequest();

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/person/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.Persons.Include(p => p.Passport).FirstOrDefaultAsync(p => p.PersonId == id);
            if (person == null)
                return NotFound();

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
