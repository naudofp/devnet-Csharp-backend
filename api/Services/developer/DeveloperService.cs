using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devnet_Csharp_backend.api.Services.developer
{
    public interface DeveloperService
    {
        Task<string> save(DeveloperRegisterDTO dto);        
    
        void update(DeveloperRegisterDTO dto, long id);        
    
        void delete(long id);        

        void addCourse(long idUser, long idCourse);
    
        void rmCourse(long idUser, long idCourse);

        Task<DeveloperDetailsDTO> findById(long id);

        Task<List<CourseCardDTO>> findCourses(long id);

        Task<List<DeveloperCardDTO>> findByUsername(string username);
    }

}
 
