using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;

namespace devnet_Csharp_backend.api.Services.security
{
    public class SecurityServiceImpl : SecurityService
    {
        public Task<string> encryptPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return Task.FromResult(passwordHash);
        }

        public Task<bool> verifyPassword(string password, string currentPassword)
        {
            bool validPassword = BCrypt.Net.BCrypt.Verify(password, currentPassword);
            return Task.FromResult(validPassword);
        }
    }
}