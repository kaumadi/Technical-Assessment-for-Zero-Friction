using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }
        // One-to-many relationship with InvoiceLines
        public List<InvoiceLine>? InvoiceLines { get; set; }
        

    }
}
