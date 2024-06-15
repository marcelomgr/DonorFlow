using DonorFlow.Core.Attributes;

namespace DonorFlow.Core.Enums
{
    public enum BloodType
    {
        [DescriptionAttribute("Tipo A")]
        A,
        [DescriptionAttribute("Tipo B")]
        B,
        [DescriptionAttribute("Tipo AB")]
        AB,
        [DescriptionAttribute("Tipo O")]
        O
    }
}
