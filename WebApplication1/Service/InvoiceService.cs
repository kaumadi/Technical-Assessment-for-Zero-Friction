using WebApplication1.Entities;
using WebApplication1.Repository.IRepository;
using WebApplication1.Service.IService;

namespace WebApplication1.Service
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepository InvoiceRepository { get; }
        private readonly ILogger<InvoiceService> _logger;
        public InvoiceService(IInvoiceRepository invoiceRepository, ILogger<InvoiceService> logger)
        {
            InvoiceRepository = invoiceRepository;
            _logger = logger;
        }

        public Task<List<Invoice>> GetInvoicesAsync()
        {
            _logger.LogInformation("API call for get Invoices in Manager/Service Layer");
            return InvoiceRepository.GetInvoicesAsync();
        }

        public Task<Invoice> GetInvoiceByIdAsync(int id, bool isIncludeInvoiceLine)
        {
            return InvoiceRepository.GetInvoiceByIdAsync(id, isIncludeInvoiceLine);
        }

        public Task<string> AddInvoiceAsync(InvoiceDTO invoice)
        {
            return InvoiceRepository.AddInvoiceAsync(invoice);
        }

        public Task<string> UpdateInvoiceAsync(int invoiceid, InvoiceDTO invoice)
        {
            return InvoiceRepository.UpdateInvoiceAsync(invoiceid, invoice);
        }
        public Task<string> AddInvoiceLineAsync(InvoiceLineDTO invoiceLine)
        {
            return InvoiceRepository.AddInvoiceLineAsync(invoiceLine);
        }

        public Task<string> UpdateInvoiceLineAsync(int invoiceLineid, InvoiceLineDTO invoiceLine)
        {
            return InvoiceRepository.UpdateInvoiceLineAsync(invoiceLineid, invoiceLine);
        }
    }
}
