namespace DonorFlow.Core.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class DescriptionAttribute : Attribute
{
    public string Description { get; }

    public DescriptionAttribute(string description)
    {
        Description = description;
    }
}
