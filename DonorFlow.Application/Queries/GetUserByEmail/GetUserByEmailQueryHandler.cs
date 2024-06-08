using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;

namespace DonorFlow.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, BaseResult<GetUserByEmailViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetUserByEmailViewModel>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(request.Email);

            if (user is null)
            {
                return new BaseResult<GetUserByEmailViewModel>(null, false, string.Empty);
            }

            var viewModel = new GetUserByEmailViewModel(user);

            return new BaseResult<GetUserByEmailViewModel>(viewModel);
        }
    }
}
