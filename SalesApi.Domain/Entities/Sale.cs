namespace SalesApi.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public bool IsCancelled { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<SaleItem> Items { get; set; }

        public decimal GetTotalAmount() => Items.Sum(i => i.TotalAmount);
    }
}
