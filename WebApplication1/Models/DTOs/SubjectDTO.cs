namespace WebApplication1.Models.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Languages { get; set; }
        public List<TeacherSubjectDto> TeacherSubjects { get; set; }

    }

    public class TeacherSubjectDto
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
