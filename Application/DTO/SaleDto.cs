namespace SalesApi.Application.DTO
{
    public class SaleDto
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public DateOnly Date { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalAmount { get; set; }
        public List<SaleItemDto> Items { get; set; } = new();
    }
}
