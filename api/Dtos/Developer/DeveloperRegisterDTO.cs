using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeveloperRegisterDTO
{
    public string name { get; set; }        
    public string username { get; set; }        
    public string password { get; set; }

      public DeveloperRegisterDTO(string name, string username, string password){
        this.name = name;
        this.username = username;
        this.password = password;
    }                
}