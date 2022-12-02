using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CourseCardDTO
{
    public long id { get; set; }
    public string nameCourse { get; set; }
    public int score { get; set; }

    public CourseCardDTO(long id, string nameCourse, int score){
        this.id = id;
        this.nameCourse = nameCourse;
        this.score = score;
    }
}