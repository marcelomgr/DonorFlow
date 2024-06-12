using MediatR;
using DonorFlow.Core.Entities;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Core.Services.AuthService;

namespace DonorFlow.Application.Commands.UserCommands.AuthUser
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, BaseResult<AuthViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repository;

        public AuthUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<BaseResult<AuthViewModel>> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Email.Length is 0 || request.Password.Length is 0)
                return new BaseResult<AuthViewModel>(null, false, "Informe usuário e senha.");

            var passwordHash = User.HashPassword(request.Password);
            var user = await _repository.ValidateUserCredentialsAsync(request.Email, passwordHash);

            if (user is null)
                return new BaseResult<AuthViewModel>(null, false, "Usuário ou senha inválidos.");

            var jwtToken = _authService.GenerateJwtToken(user);
            var viewModel = new AuthViewModel(user.FullName, user.Email, jwtToken);

            return new BaseResult<AuthViewModel>(viewModel);
        }
    }
}
