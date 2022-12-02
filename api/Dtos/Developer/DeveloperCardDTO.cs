using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeveloperCardDTO
{
    public long id { get; set; }        
    public string username { get; set; }   

    public DeveloperCardDTO(long id, string username){
        this.id = id;
        this.username = username;
    }     
}