namespace SalesApi.Domain.Events
{
    public class SaleCancelledEvent : EventMessageBase
    {
        public Guid SaleId { get; set; }
        public DateTime CancelledAt { get; set; }
    }
}
