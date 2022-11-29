using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;


public class Course
{
	public long id { get; set; }

	public string name { get; set; }

	public int addScore { get; set; }

	public ICollection<Developer> developers { get; }
}

