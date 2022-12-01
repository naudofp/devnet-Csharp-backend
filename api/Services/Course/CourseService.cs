using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface CourseService
{
    List<CourseCardDTO> save(CourseRegisterDTO dto);

    void update(CourseRegisterDTO dto, long id);
    
    void delete(long id);

    CourseDTO findById(long id);

    List<CourseCardDTO> findAll();
    
    List<CourseCardDTO> findByName(string name);
}