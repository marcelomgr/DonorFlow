using DonorFlow.Core.Enums;

namespace DonorFlow.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodType BloodType { get; init; }
        public RhFactor RhFactor { get; init; }
        public int QuantityML { get; private set; }

        public BloodStock(BloodType bloodType, RhFactor rhFactor, int quantityML)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityML = quantityML;
        }

        public void AddQuantity(int quantity)
        {
            QuantityML += quantity;
        }

        public void ReduceQuantity(int quantity)
        {
            if (QuantityML < quantity) throw new InvalidOperationException("Quantidade insuficiente em estoque.");
            QuantityML -= quantity;
        }
    }
}
