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

        public async void addCourse(long idUser, long idCourse)
        {
            var course = await context.course.FirstOrDefaultAsync(x => x.id == idCourse);
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == idCourse);

            if(developer == null) throw new Exception("Developer " + idUser + " was not found");
            if(course == null) throw new Exception("Course " + idCourse + " was not found");

            foreach (var c in developer.courses){
                if(c.id == course.id) throw new Exception("Course was already added");
            }

            course.developers.Add(developer);
            developer.courses.Add(course);

            context.course.Update(course);
            context.developer.Update(developer);

            await context.SaveChangesAsync();
        }

        public async void delete(long id)
        {
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            context.developer.Remove(developer);
            await context.SaveChangesAsync();
        }

        public async Task<DeveloperDetailsDTO> findById(long id)
        {
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            DeveloperDetailsDTO dto = new DeveloperDetailsDTO(developer.id, developer.name, developer.username, developer.score);
            
            return dto; 
        }

        public Task<List<DeveloperCardDTO>> findByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseCardDTO>> findCourses(long id)
        {
            var dev = await context.developer.FirstOrDefaultAsync(x => x.id == id);
            if(dev == null) throw new Exception("Developer " + id + " was not found");

            List<CourseCardDTO> dtos = new List<CourseCardDTO>();

            foreach (var course in dev.courses){
                dtos.Add(new CourseCardDTO(course.id, course.name, course.addScore));
            }

            return dtos;
        }

        public async void rmCourse(long idUser, long idCourse)
        {
            var course = await context.course.FirstOrDefaultAsync(x => x.id == idCourse);
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == idCourse);

            if(developer == null) throw new Exception("Developer " + idUser + " was not found");
            if(course == null) throw new Exception("Course " + idCourse + " was not found");

            course.developers.Remove(developer);
            developer.courses.Remove(course);

            context.course.Update(course);
            context.developer.Update(developer);

            await context.SaveChangesAsync();
        }

        public async Task<string> save(DeveloperRegisterDTO dto)
        {
            if(context.developer.Any(x => x.username == dto.username)) throw new Exception("Username already registered");

            Developer dev = new Developer(dto.name, dto.username, dto.password);
            await context.developer.AddAsync(dev);
            await context.SaveChangesAsync();
            return "";
        }

        public void update(DeveloperRegisterDTO dto, long id)
        {
        }
    }
}