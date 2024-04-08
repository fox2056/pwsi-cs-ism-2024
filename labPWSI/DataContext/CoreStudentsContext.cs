using Microsoft.EntityFrameworkCore;

namespace labPWSI.DataContext
{
    public class CoreStudentsContext : DbContext
    {
        public CoreStudentsContext(DbContextOptions<CoreStudentsContext> options) : base(options) 
        {  
        }
        public virtual DbSet<labPWSI.Models.Group> Groups { get; set; }
        public virtual DbSet<labPWSI.Models.Student> Students { get; set; }
    }
}
