using DonorFlow.Core.Entities;
using DonorFlow.Application.Commands.UpdateUser;

namespace DonorFlow.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailViewModel
    {
        public GetUserByEmailViewModel(User user)
        {
            Name = user.FullName;
            CPF = user.CPF;
            Email = user.Email;
            Location = user.Location is not null ? new LocationInfoModel(user.Location) : null;
        }

        public string Name { get; private set; }
        public string? CPF { get; private set; }
        public string? Email { get; private set; }
        public LocationInfoModel? Location { get; set; }
    }
}
