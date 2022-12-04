using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devnet_Csharp_backend.api.Services.developer
{
    public interface DeveloperService
    {
        Task<string> save(DeveloperRegisterDTO dto);        
    
        Task<string> delete(long id);        

        Task<string> addCourse(long idUser, long idCourse);
    
        Task<string> rmCourse(long idUser, long idCourse);

        Task<DeveloperDetailsDTO> findById(long id);

        Task<List<CourseCardDTO>> findDeveloperWithCourses(long id);

        Task<List<DeveloperCardDTO>> findByUsername(string username);
    }

}
 
