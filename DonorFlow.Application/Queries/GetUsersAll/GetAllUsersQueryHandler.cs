using MediatR;
using DonorFlow.Core.Repositories;
using DonorFlow.Application.Models;
using DonorFlow.Application.Queries.Models;

namespace DonorFlow.Application.Queries.GetUsersAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, BaseResult<List<GetUsersViewModel>>>
    {
        private readonly IUserRepository _repository;
        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResult<List<GetUsersViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            if (users is null)
            {
                return new BaseResult<List<GetUsersViewModel>>(null, false, "Nenhum usuário encontrado");
            }

            var viewModels = users.Select(user => new GetUsersViewModel(user)).ToList();

            return new BaseResult<List<GetUsersViewModel>>(viewModels);
        }
    }
}
