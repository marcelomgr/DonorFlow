using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Commands.DonorCommands.DeleteDonor
{
    public class DeleteDonorCommandHandler : IRequestHandler<DeleteDonorCommand, BaseResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.Donors.GetByIdAsync(request.Id);

            if (donor is null)
                return new BaseResult(false, "Doador não encontrado.");

            await _unitOfWork.Donors.DeleteAsync(donor.Id);
            await _unitOfWork.SaveChangesAsync();

            return new BaseResult();
        }
    }
}
