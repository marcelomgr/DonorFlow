using System.Reflection;
using DonorFlow.Core.Enums;
using DonorFlow.Core.Attributes;
using DonorFlow.Application.Models;
using DonorFlow.Application.Interfaces;

namespace DonorFlow.Application.Services;

public class EnumService : IEnumService
{
    // Método para obter enums específicos de pessoa
    private List<EnumValue> GetEnumValues<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T))
                   .Cast<T>()
                   .Select(e => new EnumValue
                   {
                       Name = e.ToString(),
                       Value = Convert.ToInt32(e),
                       Description = GetEnumDescription(e)
                   })
                   .ToList();
    }

    // Método para obter a descrição do enum
    private string GetEnumDescription<T>(T value) where T : Enum
    {
        FieldInfo field = value.GetType().GetField(value.ToString());

        if (field == null) return value.ToString();

        var attribute = field.GetCustomAttribute<DescriptionAttribute>(false);
        if (attribute != null)
        {
            return attribute.Description;
        }

        // Fallback para usar CustomAttributes
        var customAttributes = field.CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(DescriptionAttribute));
        if (customAttributes != null)
        {
            var description = customAttributes.ConstructorArguments.FirstOrDefault().Value;
            if (description != null)
            {
                return description.ToString();
            }
        }

        return value.ToString(); // Fallback para o nome do enum se não houver descrição
    }

    private IDictionary<string, List<EnumValue>> CombineDictionaries(params IDictionary<string, List<EnumValue>>[] dictionaries)
    {
        var combinedDict = new Dictionary<string, List<EnumValue>>();

        foreach (var dict in dictionaries)
        {
            foreach (var kvp in dict)
            {
                combinedDict[kvp.Key] = kvp.Value;
            }
        }

        return combinedDict;
    }

    public IDictionary<string, List<EnumValue>> GetPersonEnums()
    {
        return new Dictionary<string, List<EnumValue>>
            {
                { nameof(Gender), GetEnumValues<Gender>() }
            };
    }

    public IDictionary<string, List<EnumValue>> GetDonorEnums()
    {
        var personEnums = GetPersonEnums();
        var donorSpecificEnums = new Dictionary<string, List<EnumValue>>
            {
                { nameof(BloodType), GetEnumValues<BloodType>() },
                { nameof(RhFactor), GetEnumValues<RhFactor>() }
            };

        return CombineDictionaries(donorSpecificEnums);
    }

    public IDictionary<string, List<EnumValue>> GetUserEnums()
    {
        var personEnums = GetPersonEnums();
        var userSpecificEnums = new Dictionary<string, List<EnumValue>>
            {
                { nameof(UserStatus), GetEnumValues<UserStatus>() },
                { nameof(UserRole), GetEnumValues<UserRole>() }
            };

        return CombineDictionaries(userSpecificEnums);
    }
}
