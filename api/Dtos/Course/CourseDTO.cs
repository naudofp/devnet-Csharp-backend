using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CourseDTO
{
    public long id { get; set; }
    public string nameCourse { get; set; }        
    public string scoreCourse { get; set; }        
    public List<string> developers { get; set; }        
}