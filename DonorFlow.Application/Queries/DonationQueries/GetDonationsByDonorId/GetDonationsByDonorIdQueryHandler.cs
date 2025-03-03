using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationsByDonorId
{
    public class GetDonationsByDonorIdQueryHandler : IRequestHandler<GetDonationsByDonorIdQuery, BaseResult<List<GetDonationsViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationsByDonorIdQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<List<GetDonationsViewModel>>> Handle(GetDonationsByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetByDonor(request.Id);

            if (donations is null)
            {
                return new BaseResult<List<GetDonationsViewModel>>(null, false, "Nenhuma doação encontrada");
            }

            var viewModels = donations.Select(donation => new GetDonationsViewModel(donation)).ToList();

            return new BaseResult<List<GetDonationsViewModel>>(viewModels);
        }
    }
}
