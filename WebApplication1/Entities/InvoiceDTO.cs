namespace WebApplication1.Entities
{
    public class InvoiceDTO
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
