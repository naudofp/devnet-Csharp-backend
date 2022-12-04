using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CourseDetailsDTO
{
    public long id { get; set; }
    public string nameCourse { get; set; }        
    public int scoreCourse { get; set; }        
    public List<string>? developers { get; set; }  

    public CourseDetailsDTO(long id, string nameCourse, int scoreCourse, List<string>? developers){
        this.id = id;
        this.nameCourse = nameCourse;
        this.scoreCourse = scoreCourse;
        this.developers = developers;
    }      
}