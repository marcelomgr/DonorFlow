using DonorFlow.Core.Attributes;

namespace DonorFlow.Core.Enums
{
    public enum UserRole
    {
        [DescriptionAttribute("Administrador")]
        Admin,
        [DescriptionAttribute("Básico")]
        Basic
    }
}
