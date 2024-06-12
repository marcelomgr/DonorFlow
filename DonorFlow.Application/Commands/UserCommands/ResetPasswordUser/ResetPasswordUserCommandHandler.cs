using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.ResetPasswordUser
{
    public class ResetPasswordUserCommandHandler : IRequestHandler<ResetPasswordUserCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResetPasswordUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult> Handle(ResetPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user is null)
                return new BaseResult<Guid>(Guid.Empty, false, "Usuário não encontrado.");

            user.ResetPassword(request.NewPassword);

            user.Update(
                user.FullName,
                user.CPF,
                user.Email,
                user.Password,
                user.BirthDate,
                Enum.Parse<Gender>(user.Gender.ToString()),
                Enum.Parse<UserRole>(user.Role.ToString()),
                user.Location);

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new BaseResult();
        }
    }
}
