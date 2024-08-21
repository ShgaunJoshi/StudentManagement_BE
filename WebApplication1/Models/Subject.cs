using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{


    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Class { get; set; }

        [Required]
        public List<string> Languages { get; set; } = new List<string>();

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}
