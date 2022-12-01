using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace devnet_Csharp_backend.api.Services.Developer
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

            course.developers.Add(developer);
            developer.courses.Add(course);

            context.course.Update(course);
            context.developer.Update(developer);

            context.SaveChangesAsync();
        }

        public async void delete(long id)
        {
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            context.developer.Remove(developer);
            context.SaveChangesAsync();
        }

        public async Task<DeveloperDetailsDTO> findById(long id)
        {
            var developer = await context.developer.FirstOrDefaultAsync(x => x.id == id);

            if(developer == null) throw new Exception("Developer " + id + " was not found");

            DeveloperDetailsDTO dto = new DeveloperDetailsDTO();
            dto.id = developer.id;
            dto.name = developer.name;
            dto.username = developer.username;
            dto.score = developer.score;
            
            return dto; 
        }

        public Task<List<DeveloperCardDTO>> findByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseCardDTO>> findCourses(long id)
        {
            throw new NotImplementedException();
        }

        public void rmCourse(long idUser, long idCourse)
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginDTO> save(DeveloperRegisterDTO dto)
        {
            throw new NotImplementedException();
        }

        public void update(DeveloperRegisterDTO dto, long id)
        {
            throw new NotImplementedException();
        }
    }
}