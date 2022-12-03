using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Developer = devnet_Csharp_backend.api.Models.Developer;

public class Course
{
	public long id { get; set; }

	public string name { get; set; }

	public int addScore { get; set; }

	public List<Developer> developers { get; set; }

	public Course(long id, string name, int addScore){
		this.id = id;
		this.name = name;
		this.addScore = addScore;
	}

	public Course(string name, int addCourse){
		this.name = name;
		this.addScore = addCourse;
	}
}

