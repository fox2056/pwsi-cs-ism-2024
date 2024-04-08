using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using labPWSI.DataContext;
using labPWSI.Models;

namespace labPWSI.Pages.Student_View
{
    public class CreateModel : PageModel
    {
        private readonly labPWSI.DataContext.CoreStudentsContext _context;

        public CreateModel(labPWSI.DataContext.CoreStudentsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_context.Groups, "GrupaId", "Nazwa");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Students == null || Student == null)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
