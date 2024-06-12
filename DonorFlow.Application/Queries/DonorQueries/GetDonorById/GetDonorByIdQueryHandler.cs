using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, BaseResult<GetDonorsViewModel>>
    {
        private readonly IDonorRepository _repository;
        public GetDonorByIdQueryHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetDonorsViewModel?>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetByIdAsync(request.Id);

            if (donor is null)
            {
                return new BaseResult<GetDonorsViewModel?>(null, false, string.Empty);
            }

            var viewModel = new GetDonorsViewModel(donor);

            return new BaseResult<GetDonorsViewModel?>(viewModel);
        }
    }
}
