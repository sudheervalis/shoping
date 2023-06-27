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
    public class EmpTablesController : ControllerBase
    {
        private readonly RaoneContext _context;

        public EmpTablesController(RaoneContext context)
        {
            _context = context;
        }

        // GET: api/EmpTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpTable>>> GetEmpTables()
        {
            return await _context.EmpTables.ToListAsync();
        }

        // GET: api/EmpTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpTable>> GetEmpTable(int id)
        {
            var empTable = await _context.EmpTables.FindAsync(id);

            if (empTable == null)
            {
                return NotFound();
            }

            return empTable;
        }

        // PUT: api/EmpTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpTable(int id, EmpTable empTable)
        {
            if (id != empTable.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(empTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpTableExists(id))
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

        // POST: api/EmpTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpTable>> PostEmpTable(EmpTable empTable)
        {
            _context.EmpTables.Add(empTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpTable", new { id = empTable.EmpId }, empTable);
        }

        // DELETE: api/EmpTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpTable(int id)
        {
            var empTable = await _context.EmpTables.FindAsync(id);
            if (empTable == null)
            {
                return NotFound();
            }

            _context.EmpTables.Remove(empTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpTableExists(int id)
        {
            return _context.EmpTables.Any(e => e.EmpId == id);
        }
    }
}
