using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Interfaces;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.BloodStockQueries.GetBloodStockAll
{
    public class GetBloodStockAllQueryHandler : IRequestHandler<GetBloodStockAllQuery, BaseResult<IEnumerable<GetBloodStockViewModel>>>
    {
        private readonly IBloodStockRepository _repository;
        private readonly IEnumService _enumService;

        public GetBloodStockAllQueryHandler(IBloodStockRepository repository, IEnumService enumService)
        {
            _repository = repository;
            _enumService = enumService;
        }

        public async Task<BaseResult<IEnumerable<GetBloodStockViewModel>>> Handle(GetBloodStockAllQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _repository.GetAllAsync();

            if (bloodStocks is null)
            {
                return new BaseResult<IEnumerable<GetBloodStockViewModel>>(null, false, "Nenhum estoque encontrado");
            }

            var viewModels = bloodStocks.Select(bs => new GetBloodStockViewModel(bs, _enumService)).ToList();

            return new BaseResult<IEnumerable<GetBloodStockViewModel>>(viewModels);
        }
    }
}
