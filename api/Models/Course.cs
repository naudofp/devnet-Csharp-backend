using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devnet_Csharp_backend.api.Models;

public class Course
{
	public long id { get; set; }
	
	public string name { get; set; }

	public ICollection<Developer> developers { get; }
}

