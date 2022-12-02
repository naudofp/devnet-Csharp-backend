using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devnet_Csharp_backend.api.Models
{
    public class Developer : User
    {
        public int score; 
        public List<Course> courses { get; set; }
    
        public Developer(long id, string name, string username, string password)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.score = getScore();
            this.courses = new List<Course>(); 
        }

        public Developer(string name, string username, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public int getScore() 
        {	
		    int newScore = 0;
		
            foreach (Course course in this.courses) {
		    	newScore += course.addScore;
            }

	    	return newScore;  
	    }
    }
}
