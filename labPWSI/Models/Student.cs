using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace labPWSI.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int OsobaId { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int Wiek { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }


    }
}
