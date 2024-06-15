using DonorFlow.Application.Models;

namespace DonorFlow.Application.Interfaces;

public interface IEnumService
{
    IDictionary<string, List<EnumValue>> GetUserEnums();
    IDictionary<string, List<EnumValue>> GetDonorEnums();
}
