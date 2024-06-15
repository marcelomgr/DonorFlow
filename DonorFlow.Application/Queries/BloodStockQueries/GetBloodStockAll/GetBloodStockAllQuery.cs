using MediatR;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.BloodStockQueries.GetBloodStockAll
{
    public class GetBloodStockAllQuery : IRequest<BaseResult<IEnumerable<GetBloodStockViewModel>>>
    {
        public GetBloodStockAllQuery() { }
    }
}
