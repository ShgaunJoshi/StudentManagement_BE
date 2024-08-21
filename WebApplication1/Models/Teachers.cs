using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string Sex { get; set; }
       public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
    