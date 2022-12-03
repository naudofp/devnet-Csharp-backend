using devnet_Csharp_backend.api.Data;
using Microsoft.EntityFrameworkCore;

namespace devnet_Csharp_backend.api.Services.course
{
    public class CourseServiceImpl : CourseService
    {
        private readonly DevnetDBContext context;

        public CourseServiceImpl(DevnetDBContext _context)
        {
            context = _context;
        }
        public async Task<List<CourseCardDTO>> save(CourseRegisterDTO dto)
        {
            Course course = new Course(dto.nameCourse, dto.scoreCourse);
            await context.course.AddAsync(course);
            await context.SaveChangesAsync();
            
            var courses = await context.course.ToListAsync();
            List<CourseCardDTO> dtos = new List<CourseCardDTO>();

            courses.ForEach(c => dtos.Add(new CourseCardDTO(c.id, c.name, c.addScore)));
            return dtos;
        }

        public void update(CourseRegisterDTO dto, long id)
        {
            throw new NotImplementedException();
        }
        public async Task<string> delete(long id)
        {
            var course = await context.course.FirstOrDefaultAsync(x => x.id == id);

            if(course == null) throw new Exception("Course " + id + " was not found");

            context.course.Remove(course);
            await context.SaveChangesAsync();

            return "Course deleted successfully";
        }

        public async Task<CourseDetailsDTO> findById(long id)
        {
            var course = await context.course.FirstOrDefaultAsync(x => x.id == id);
            if(course == null) throw new Exception("Course " + id + " was not found");

            return new CourseDetailsDTO(course.id, course.name, course.addScore, null);
        }

        public async Task<List<CourseCardDTO>> findByName(string name)
        {
            var courses = context.course.FromSqlRaw($"select * from course where name like '%{name}%'");
            List<CourseCardDTO> dtos = new List<CourseCardDTO>();

            foreach (var c in courses) dtos.Add(new CourseCardDTO(c.id, c.name, c.addScore));
            return dtos;
        }

        public async Task<List<CourseCardDTO>> findAll()
        {
            var courses = context.course.ToList();
            List<CourseCardDTO> dtos = new List<CourseCardDTO>();

            courses.ForEach(c => dtos.Add(new CourseCardDTO(c.id, c.name, c.addScore)));
            
            return dtos;
        }


    }
}