using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labPWSI.DataContext;
using labPWSI.Models;


namespace labPWSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly CoreStudentsContext _context;

        public GroupsController(CoreStudentsContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
          if (_context.Groups == null)
          {
              return NotFound();
          }
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
          if (_context.Groups == null)
          {
              return NotFound();
          }
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.GrupaId)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups - Stary POST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
          if (_context.Groups == null)
          {
              return Problem("Entity set 'CoreStudentsContext.Groups'  is null.");
          }
            _context.Groups.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.GrupaId }, @group);
        }
        */

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Route("api/Groups")]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'CoreStudentsContext.Groups'  is null.");
            }
            //_context.Groups.Add(@group);
            Group gr = new Group();
            gr.Nazwa = @group.Nazwa;
            _context.Groups.Add(gr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = gr.GrupaId }, gr);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (_context.Groups == null)
            {
                return NotFound();
            }
            var @group = await _context.Groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return (_context.Groups?.Any(e => e.GrupaId == id)).GetValueOrDefault();
        }
    }
}
