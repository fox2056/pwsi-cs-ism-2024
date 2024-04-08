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
    public class DetailsModel : PageModel
    {
        private readonly labPWSI.DataContext.CoreStudentsContext _context;

        public DetailsModel(labPWSI.DataContext.CoreStudentsContext context)
        {
            _context = context;
        }

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
    }
}
