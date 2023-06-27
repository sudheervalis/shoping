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
    public class SudentTablesController : ControllerBase
    {
        private readonly RaoneContext _context;

        public SudentTablesController(RaoneContext context)
        {
            _context = context;
        }

        // GET: api/SudentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SudentTable>>> GetSudentTables()
        {
            return await _context.SudentTables.ToListAsync();
        }

        // GET: api/SudentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SudentTable>> GetSudentTable(int id)
        {
            var sudentTable = await _context.SudentTables.FindAsync(id);

            if (sudentTable == null)
            {
                return NotFound();
            }

            return sudentTable;
        }

        // PUT: api/SudentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSudentTable(int id, SudentTable sudentTable)
        {
            if (id != sudentTable.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(sudentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SudentTableExists(id))
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

        // POST: api/SudentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SudentTable>> PostSudentTable(SudentTable sudentTable)
        {
            _context.SudentTables.Add(sudentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSudentTable", new { id = sudentTable.StudentId }, sudentTable);
        }

        // DELETE: api/SudentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSudentTable(int id)
        {
            var sudentTable = await _context.SudentTables.FindAsync(id);
            if (sudentTable == null)
            {
                return NotFound();
            }

            _context.SudentTables.Remove(sudentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SudentTableExists(int id)
        {
            return _context.SudentTables.Any(e => e.StudentId == id);
        }
    }
}
