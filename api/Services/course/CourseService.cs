using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface CourseService
{
    Task<List<CourseCardDTO>> save(CourseRegisterDTO dto);

    void update(CourseRegisterDTO dto, long id);
    
    Task<string> delete(long id);

    Task<CourseDetailsDTO> findById(long id);

    Task<List<CourseCardDTO>> findAll();
    
    Task<List<CourseCardDTO>> findByName(string name);
}