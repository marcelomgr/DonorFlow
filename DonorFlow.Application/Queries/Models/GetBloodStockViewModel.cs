using DonorFlow.Core.Entities;
using DonorFlow.Application.Interfaces;

namespace DonorFlow.Application.Queries.Models
{
    public class GetBloodStockViewModel
    {
        private readonly IEnumService _enumService;

        public GetBloodStockViewModel(BloodStock bloodStock, IEnumService enumService)
        {
            _enumService = enumService;

            Id = bloodStock.Id;
            QuantityML = bloodStock.QuantityML;
            BloodType = GetEnumDescription(bloodStock.BloodType, nameof(BloodType));
            RhFactor = GetEnumDescription(bloodStock.RhFactor, nameof(RhFactor));
        }

        public Guid Id { get; set; }
        public int QuantityML { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }

        private string GetEnumDescription<T>(T enumValue, string enumTypeName) where T : Enum
        {
            var enumValues = _enumService.GetDonorEnums();

            if (enumValues.ContainsKey(enumTypeName))
            {
                var enumList = enumValues[enumTypeName];
                var enumString = enumList.FirstOrDefault(e => e.Value == Convert.ToInt32(enumValue))?.Description;
                return enumString ?? enumValue.ToString();
            }

            return enumValue.ToString();
        }
    }
}
