using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TeacherSubject
    {


        public int TeacherId { get; set; }
        public Teachers Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
