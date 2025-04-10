namespace SalesApi.Domain.Events
{
    public class EventMessageBase
    {
        public EventMessageBase()
        {
            EventId = Guid.NewGuid();
        }

        public Guid EventId { get; set; }
    }
}
