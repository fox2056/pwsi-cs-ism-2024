using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using labPWSI.DataContext;
using labPWSI.Models;

namespace labPWSI.Pages.Student_View
{
    public class IndexModel : PageModel
    {
        private readonly labPWSI.DataContext.CoreStudentsContext _context;

        public IndexModel(labPWSI.DataContext.CoreStudentsContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Group).ToListAsync();
            }
        }
    }
}
