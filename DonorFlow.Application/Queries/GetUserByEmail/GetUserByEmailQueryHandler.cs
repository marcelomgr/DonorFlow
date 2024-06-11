using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, BaseResult<GetUsersViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetUsersViewModel>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(request.Email);

            if (user is null)
            {
                return new BaseResult<GetUsersViewModel>(null, false, string.Empty);
            }

            var viewModel = new GetUsersViewModel(user);

            return new BaseResult<GetUsersViewModel>(viewModel);
        }
    }
}
