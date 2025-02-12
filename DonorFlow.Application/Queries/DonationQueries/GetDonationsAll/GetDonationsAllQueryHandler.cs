using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonationQueries.GetDonationsAll
{
    public class GetDonationsAllQueryHandler : IRequestHandler<GetDonationsAllQuery, BaseResult<List<GetDonationsViewModel>>>
    {
        private readonly IDonationRepository _repository;
        public GetDonationsAllQueryHandler(IDonationRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResult<List<GetDonationsViewModel>>> Handle(GetDonationsAllQuery request, CancellationToken cancellationToken)
        {
            var donations = await _repository.GetAllAsync();

            if (donations is null)
            {
                return new BaseResult<List<GetDonationsViewModel>>(null, false, "Nenhum doador encontrado");
            }

            var viewModels = donations.Select(donation => new GetDonationsViewModel(donation)).ToList();

            return new BaseResult<List<GetDonationsViewModel>>(viewModels);
        }
    }
}
