using AutoMapper;

namespace WebApplication1.Models.DTOs
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {
            CreateMap<SubjectDTO, Subject>();
            CreateMap<TeacherSubjectDto, TeacherSubject>();
        }
    }
}
