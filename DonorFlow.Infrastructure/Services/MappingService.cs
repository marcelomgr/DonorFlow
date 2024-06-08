using AutoMapper;
using DonorFlow.Core.Dtos;
using DonorFlow.Core.Entities;
using DonorFlow.Core.ValueObjects;

namespace DonorFlow.Infrastructure.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Donor, DonorDTO>();
            CreateMap<DonorDTO, Donor>();

            CreateMap<LocationInfo, LocationInfoDTO>();
            CreateMap<LocationInfoDTO, LocationInfo>();
        }
    }
}
