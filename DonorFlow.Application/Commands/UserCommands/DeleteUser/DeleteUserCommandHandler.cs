using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user is null)
                return new BaseResult(false, "Usuário não encontrado.");

            await _unitOfWork.Users.DeleteAsync(user.Id);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
