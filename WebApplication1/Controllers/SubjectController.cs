using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public SubjectController(ApplicationDBContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateSubject([FromBody] SubjectDTO subjectDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var subject = _mapper.Map<Subject>(subjectDto);

        //    _context.Subjects.Add(subject);

        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //        foreach (var teacherSubjectDto in subjectDto.TeacherSubjects)
        //        {
        //            var teacher = await _context.Teachers.FindAsync(teacherSubjectDto.TeacherId);
        //            if (teacher == null)
        //            {
        //                return NotFound($"Teacher with ID {teacherSubjectDto.TeacherId} not found.");
        //            }

        //            var teacherSubject = _mapper.Map<TeacherSubject>(teacherSubjectDto);
        //            teacherSubject.SubjectId = subject.Id;

        //            _context.TeacherSubjects.Add(teacherSubject);
        //        }

        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        return StatusCode(500, "Internal server error. Please try again later.");
        //    }
        //}



        //[HttpGet("{id}")]

        //public async Task<ActionResult<Subject>> GetSubjectById(int id)
        //{
        //    var subject = await _context.Subjects
        //        .Include(s => s.TeacherSubjects)
        //        .ThenInclude(ts => ts.Teacher)
        //        .FirstOrDefaultAsync(s => s.Id == id);

        //    if (subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return subject;
        //}


        // POST: api/Subject
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

           
            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }



        // PUT: api/Subject/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
