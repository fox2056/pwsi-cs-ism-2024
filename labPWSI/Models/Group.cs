using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace labPWSI.Models
{
    [Table("Group")]
    public class Group
    {
        public Group() 
        { 
            Students = new HashSet<Student>();
        }
        [Key]
        public int GrupaId { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Student> Students { get; set;}

    }
}
