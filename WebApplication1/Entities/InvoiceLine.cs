using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace WebApplication1.Entities
{
    public class InvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int LineAmount { get; set; }
        public int InvoiceId { get; set; }
        // One-to-many relation with Invoice
        public Invoice Invoice { get; set; }

    }
}
