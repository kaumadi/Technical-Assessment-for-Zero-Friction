using WebApplication1.Entities;

namespace WebApplication1.Repository.IRepository
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id, bool isIncludeInvoiceLine);
        Task<string> AddInvoiceAsync(InvoiceDTO invoice);
        Task<string> UpdateInvoiceAsync(int invoiceid, InvoiceDTO invoice);
        Task<List<InvoiceLine>> GetInvoiceLineAsync();
        Task<InvoiceLine> GetInvoiceLineAsync(int id);
        Task<string> AddInvoiceLineAsync(InvoiceLineDTO invoiceLine);
        Task<string> UpdateInvoiceLineAsync(int invoiceLineid, InvoiceLineDTO invoiceLine);







    }
}
