using MediatR;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.ForgotPasswordUser
{
    public class ForgotPasswordUserCommandHandler : IRequestHandler<ForgotPasswordUserCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ForgotPasswordUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult> Handle(ForgotPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user is null)
                return new BaseResult<Guid>(Guid.Empty, false, "Usuário não encontrado.");

            if (!user.CPF.Equals(request.CPF) || !user.BirthDate.ToShortDateString().Equals(request.BirthDate.ToShortDateString()))
                return new BaseResult<Guid>(Guid.Empty, false, "Os dados do usuário não conferem.");

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
