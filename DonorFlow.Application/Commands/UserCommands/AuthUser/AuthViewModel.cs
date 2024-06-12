namespace DonorFlow.Application.Commands.UserCommands.AuthUser
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
