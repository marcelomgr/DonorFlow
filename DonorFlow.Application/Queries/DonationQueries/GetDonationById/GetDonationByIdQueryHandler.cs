using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationById
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, BaseResult<GetDonationsViewModel>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationByIdQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetDonationsViewModel?>> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _repository.GetByIdAsync(request.Id);

            if (donation is null)
            {
                return new BaseResult<GetDonationsViewModel?>(null, false, string.Empty);
            }

            var viewModel = new GetDonationsViewModel(donation);

            return new BaseResult<GetDonationsViewModel?>(viewModel);
        }
    }
}
