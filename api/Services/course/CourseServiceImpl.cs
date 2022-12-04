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

        public async Task<List<Course>> addDefaultCourses()
        {
            string[] namesCourse = 
				{
				  "Python", "C#", "C++", "JavaScript",
				  "Node.js", "Spring Boot", "Dart", "Flutter",
				  "PHP", "Java", "Go", "SQL", "Ruby",
				  "React", "HTML", "CSS", "React Native",
				  "Angular", "Vue.js", "jQuery", "Svelte",
				  "Bootstrap", "Bulma", "JavaScript",
				  "TypeScript", "Sass", "UI/UX"
				};

            int[] scoreCourses = 
				{
				  310, 300, 300, 350, 220, 230,
				  250, 180, 300, 360, 300, 150, 280,
				  200, 50, 50, 100, 200, 180, 150, 
				  150, 70, 40, 180, 180, 50, 250
				};

            for (int i = 0; i < namesCourse.Length; i++)
            {
                await context.AddAsync(new Course(i+1, namesCourse[i], scoreCourses[i]));
            }

            await context.SaveChangesAsync();
            return await context.course.ToListAsync();
        }
    }
}