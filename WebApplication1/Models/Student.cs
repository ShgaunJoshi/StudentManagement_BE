using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public string Image { get; set; }

        public string Class { get; set; }

        [Required]
        [StringLength(50)]
        public string RollNumber { get; set; }
       


    }
}
