using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devnet_Csharp_backend.api.Services.security
{
    public interface SecurityService
    {
        Task<string> encryptPassword(string password);

        Task<bool> verifyPassword(string password, string currentPassword);
    }
}