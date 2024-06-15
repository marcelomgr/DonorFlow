using DonorFlow.Core.Attributes;

namespace DonorFlow.Core.Enums
{
    public enum UserStatus
    {
        [DescriptionAttribute("Inativo")]
        Inactive = 0,
        [DescriptionAttribute("Ativo")]
        Active = 1,
        [DescriptionAttribute("Bloqueado")]
        Blocked = 2
    }
}
