using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeveloperDetailsDTO
{
    public long? id { get; set; }
    public string name { get; set; }        
    public string username { get; set; }        
    public int score { get; set; } 


    public DeveloperDetailsDTO(long id, string name, string username, int score){
        this.id = id;
        this.name = name;
        this.username = username;
        this.score = score;
    }        
}