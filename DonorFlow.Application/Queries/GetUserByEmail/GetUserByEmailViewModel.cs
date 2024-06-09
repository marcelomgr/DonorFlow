using DonorFlow.Core.Enums;
using DonorFlow.Core.Entities;
using DonorFlow.Application.Commands.UpdateUser;

namespace DonorFlow.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailViewModel
    {
        public GetUserByEmailViewModel(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            CPF = user.CPF;
            Email = user.Email;
            Status = user.Status;
            Role = user.Role;
            Gender = user.Gender;
            BirthDate = user.BirthDate;
            Location = user.Location is not null ? new LocationInfoModel(user.Location) : null;
        }

        public Guid Id { get; set; }
        public string FullName { get; private set; }
        public string? CPF { get; private set; }
        public string? Email { get; private set; }
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public LocationInfoModel? Location { get; set; }
    }
}
