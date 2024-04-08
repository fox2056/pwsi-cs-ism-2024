using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using labPWSI.DataContext;
using labPWSI.Models;

namespace labPWSI.Pages.Group_View
{
    public class DeleteModel : PageModel
    {
        private readonly labPWSI.DataContext.CoreStudentsContext _context;

        public DeleteModel(labPWSI.DataContext.CoreStudentsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Group Group { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var group = await _context.Groups.FirstOrDefaultAsync(m => m.GrupaId == id);

            if (group == null)
            {
                return NotFound();
            }
            else 
            {
                Group = group;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }
            var group = await _context.Groups.FindAsync(id);

            if (group != null)
            {
                Group = group;
                _context.Groups.Remove(Group);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
