using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Developer : User
{
    public int score { get; set; }
    public ICollection<Course> courses { get; }
    
    public Developer(long id, string name, string username, string password)
    {
        this.id = id;
        this.name = name;
        this.username = username;
        this.password = password;
        this.score = calculateScore();
    }
    public int calculateScore() 
    {	
		int newScore = 0;
		
        foreach (Course course in courses) {
			newScore += course.addScore;
        }

		return newScore;  
	}
}