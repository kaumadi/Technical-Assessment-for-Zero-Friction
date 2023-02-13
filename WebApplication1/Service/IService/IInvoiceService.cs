using WebApplication1.Entities;

namespace WebApplication1.Service.IService
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id, bool isIncludeInvoiceLine);
        Task<string> AddInvoiceAsync(InvoiceDTO invoice);
        Task<string> UpdateInvoiceAsync(int invoiceid, InvoiceDTO invoice);
        Task<string> AddInvoiceLineAsync(InvoiceLineDTO invoiceLine);
        Task<string> UpdateInvoiceLineAsync(int invoiceLineid, InvoiceLineDTO invoiceLine);
    }
}
