using DonorFlow.Core.Attributes;

namespace DonorFlow.Core.Enums
{
    public enum UserStatus
    {
        [DescriptionAttribute("Inativo")]
        Inactive,
        [DescriptionAttribute("Ativo")]
        Active,
        [DescriptionAttribute("Bloqueado")]
        Blocked
    }
}
