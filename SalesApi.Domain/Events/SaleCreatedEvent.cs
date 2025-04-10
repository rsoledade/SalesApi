namespace SalesApi.Domain.Events
{
    public class SaleCreatedEvent : EventMessageBase
    {
        public Guid SaleId { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
