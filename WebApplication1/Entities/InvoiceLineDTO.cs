namespace WebApplication1.Entities
{
    public class InvoiceLineDTO
    {
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineAmount { get; set; }
        public int InvoiceId { get; set; }
    }
}
