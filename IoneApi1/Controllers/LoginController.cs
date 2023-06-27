using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAxisLayer.Models;

namespace IoneApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly RaoneContext _context;

        public LoginController(RaoneContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDatum>>> GetUserData()
        {
            return await _context.UserData.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDatum>> GetUserDatum(int id)
        {
            var userDatum = await _context.UserData.FindAsync(id);

            if (userDatum == null)
            {
                return NotFound();
            }

            return userDatum;
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDatum(int id, UserDatum userDatum)
        {
            if (id != userDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDatumExists(id))
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

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDatum>> PostUserDatum(UserDatum userDatum)
        {
            _context.UserData.Add(userDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDatum", new { id = userDatum.Id }, userDatum);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDatum(int id)
        {
            var userDatum = await _context.UserData.FindAsync(id);
            if (userDatum == null)
            {
                return NotFound();
            }

            _context.UserData.Remove(userDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDatumExists(int id)
        {
            return _context.UserData.Any(e => e.Id == id);
        }
    }
}
