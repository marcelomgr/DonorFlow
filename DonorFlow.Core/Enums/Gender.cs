using DonorFlow.Core.Attributes;

namespace DonorFlow.Core.Enums
{
    public enum Gender
    {
        [DescriptionAttribute("Masculino")]
        Male,
        [DescriptionAttribute("Feminino")]
        Female,
        [DescriptionAttribute("Outro")]
        Other
    }
}
