using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonorQueries.GetDonorsAll
{
    public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, BaseResult<List<GetDonorsViewModel>>>
    {
        private readonly IDonorRepository _repository;
        public GetAllDonorsQueryHandler(IDonorRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResult<List<GetDonorsViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donors = await _repository.GetAllAsync();

            if (donors is null)
            {
                return new BaseResult<List<GetDonorsViewModel>>(null, false, "Nenhum doador encontrado");
            }

            var viewModels = donors.Select(donor => new GetDonorsViewModel(donor)).ToList();

            return new BaseResult<List<GetDonorsViewModel>>(viewModels);
        }
    }
}
