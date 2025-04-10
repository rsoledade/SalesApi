using SalesApi.Domain.Enums;

namespace SalesApi.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public TaxType TaxType { get; set; }
        public Guid SaleId { get; set; }

        public void ApplyTaxRules()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            if (Quantity >= 10)
            {
                TaxType = TaxType.Special;
                TaxAmount = Quantity * UnitPrice * 0.20m;
            }
            else if (Quantity >= 4)
            {
                TaxType = TaxType.Standard;
                TaxAmount = Quantity * UnitPrice * 0.10m;
            }
            else
            {
                TaxType = TaxType.Exempt;
                TaxAmount = 0;
            }

            TotalAmount = (Quantity * UnitPrice) + TaxAmount;
        }
    }
}
