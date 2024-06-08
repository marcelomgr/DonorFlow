using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Application.Commands.AuthUser
{
    public class AuthViewModel
    {
        public AuthViewModel(string name, string email, string token)
        {
            Name = name;
            Email = email;
            Token = token;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
