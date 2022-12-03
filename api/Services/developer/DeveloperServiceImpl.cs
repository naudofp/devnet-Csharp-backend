using devnet_Csharp_backend.api.Data;
using Microsoft.EntityFrameworkCore;
using Developer = devnet_Csharp_backend.api.Models.Developer;

namespace devnet_Csharp_backend.api.Services.developer
{
    public class DeveloperServiceImpl : DeveloperService
    {
        private readonly DevnetDBContext context;

        public DeveloperServiceImpl(DevnetDBContext _context)
        {
            context = _context;
        }


        public async Task<string> save(DeveloperRegisterDTO dto)
        {
            if(context.developer.Any(x => x.username == dto.username)) throw new Exception("Username already registered");
            Developer dev = new Developer(dto.name, dto.username, dto.password);

            await context.developer.AddAsync(dev);
            await context.SaveChangesAsync();
            return "Register was successfully";
        }

        public async Task<string> delete(long id)
        {
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            context.developer.Remove(developer);
            await context.SaveChangesAsync();

            return "Developer deleted successfully";
        }

        public async Task<DeveloperDetailsDTO> findById(long id)
        {
            var developer = await context.developer.Include(x => x.courses)
            .AsNoTracking().SingleOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            DeveloperDetailsDTO dto = new DeveloperDetailsDTO(developer.id, developer.name, developer.username, developer.getScore());
            
            return dto; 
        }

        public async Task<List<DeveloperCardDTO>> findByUsername(string username)
        {
            var devs = context.developer.FromSqlRaw($"select * from user where username like '%{username}%'");
            
            List<DeveloperCardDTO> dtos = new List<DeveloperCardDTO>();
            foreach (var d in devs) {
                dtos.Add(new DeveloperCardDTO(d.id, d.username));
            }

            return dtos;
        }

        public async Task<List<CourseCardDTO>> findDeveloperWithCourses(long id)
        {
            var dev = await context.developer.Include(x => x.courses).AsNoTracking().SingleOrDefaultAsync(x => x.id == id);
            if(dev == null) throw new Exception("Developer " + id + " was not found");

            List<CourseCardDTO> dtos = new List<CourseCardDTO>();
            
            dev.courses.ForEach(c => dtos.Add(new CourseCardDTO(c.id, c.name, c.addScore)));
            return dtos;
        }

        public async Task<string> addCourse(long idUser, long idCourse)
        {
            var course = await context.course.Include(x => x.developers)
            .AsNoTracking().SingleOrDefaultAsync(x => x.id == idCourse);

            var developer = await context.developer.Include(x => x.courses)
            .AsNoTracking().SingleOrDefaultAsync(x => x.id == idUser);

            if(developer == null) throw new Exception("Developer " + idUser + " was not found");
            if(course == null) throw new Exception("Course " + idCourse + " was not found");

            developer.courses.ForEach(c => {
                if(c.id == idCourse) throw new Exception("Course already added");
            });

            course.developers.Add(developer);
            developer.courses.Add(course);

            context.course.Update(course);
            context.developer.Update(developer);

            await context.SaveChangesAsync();

            return "Course added successfully to Developer";
        }

        public async Task<string> rmCourse(long idUser, long idCourse)
        {
            var course = await context.course.Include(x => x.developers)
            .AsNoTracking().SingleOrDefaultAsync(x => x.id == idCourse);

            var developer = await context.developer.Include(x => x.courses)
            .SingleOrDefaultAsync(x => x.id == idUser);

            if(developer == null) throw new Exception("Developer " + idUser + " was not found");
            if(course == null) throw new Exception("Course " + idCourse + " was not found");

            //  DEV PROCESSING
            var coursesDev = developer.courses;
            developer.courses.Clear();
            coursesDev.ForEach(c => {

                if(c.id == idCourse) 
                    coursesDev.Remove(c);
                else
                    developer.courses.Add(c);
            });

            //  COURSE PROCESSING
            var devsCourse = course.developers;
            course.developers.Clear();
            devsCourse.ForEach(d => {

                if(d.id == idUser) 
                    devsCourse.Remove(d);
                else
                    course.developers.Add(d);
            });
            
            await context.SaveChangesAsync();
            return "Course successfully deleted to Developer";
        }
    }
}