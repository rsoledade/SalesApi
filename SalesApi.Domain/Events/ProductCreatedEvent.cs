namespace SalesApi.Domain.Events
{
    public class ProductCreatedEvent : EventMessageBase
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
