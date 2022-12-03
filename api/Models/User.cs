using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace devnet_Csharp_backend.api.Models
{
    public abstract class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}