using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CourseRegisterDTO
{
    public string nameCourse { get; set; }
    public int scoreCourse { get; set; }

    public CourseRegisterDTO(string nameCourse, int scoreCourse){
        this.nameCourse = nameCourse;
        this.scoreCourse = scoreCourse;
    }
}