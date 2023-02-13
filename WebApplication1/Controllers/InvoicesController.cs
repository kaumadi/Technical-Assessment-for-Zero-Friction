using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Repository.IRepository;
using WebApplication1.Service.IService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(IInvoiceService invoiceService, ILogger<InvoicesController> logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceService.GetInvoicesAsync();

            if (invoices == null)
            {
                _logger.LogError("No invoices in database");
                return StatusCode(StatusCodes.Status204NoContent, "No invoices in database");
            }

            return StatusCode(StatusCodes.Status200OK, invoices);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetInvoiceById(int id, bool isIncludeInvoiceLine)
        {
            _logger.LogInformation("Get Invoice for Invoiceid:"+ id);
            isIncludeInvoiceLine = false;
            Invoice invoice = await _invoiceService.GetInvoiceByIdAsync(id, isIncludeInvoiceLine);

            if (invoice == null)
            {
                _logger.LogError("No Invoice found for id");
                return StatusCode(StatusCodes.Status204NoContent, $"No Invoice found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, invoice);
        }

        [HttpPost]
        [Route("AddInvoice")]
        public async Task<ActionResult<string>> AddInvoice(InvoiceDTO invoice)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error in ModelState");
                return BadRequest(ModelState);
                
            }
            var result = await _invoiceService.AddInvoiceAsync(invoice);

            if (result == null)
            {
                _logger.LogError("Invoice could not be added ");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Invoice could not be added.");
                
            }

            _logger.LogInformation("Successfully Added Invoice");
            return result;
           
        }
        [HttpPost]
        [Route("AddInvoiceLine")]
        public async Task<ActionResult<string>> AddInvoiceLine(InvoiceLineDTO invoiceLine)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error in ModelState");
                return BadRequest(ModelState);
            }
            var result = await _invoiceService.AddInvoiceLineAsync(invoiceLine);

            if (result == null)
            {
                _logger.LogError("Invoice Line could not be added.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Invoice Line could not be added.");
               
            }
            _logger.LogInformation("Successfully Added Invoice Line");
            return result;
         
        }

        [HttpPut("invoiceid")]
      
        public async Task<ActionResult<string>> UpdateInvoice(int invoiceid, InvoiceDTO invoice)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error in ModelState");
                return BadRequest(ModelState);
            }

            var result = await _invoiceService.UpdateInvoiceAsync(invoiceid,invoice);

            if (result == null)
            {
                _logger.LogError("Invoice could not be updated");
                return StatusCode(StatusCodes.Status500InternalServerError, $" Invoice could not be updated");
            }
            _logger.LogInformation("Successfully Updated Invoice ");
            return result;
        }
        [HttpPut("invoiceLineid")]

        public async Task<ActionResult<string>> UpdateInvoiceLine(int invoiceLineid, InvoiceLineDTO invoiceLine)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error in ModelState");
                return BadRequest(ModelState);
            }

            var result = await _invoiceService.UpdateInvoiceLineAsync(invoiceLineid, invoiceLine);

            if (result == null)
            {
                _logger.LogError("Invoice Line could not be updated");
                return StatusCode(StatusCodes.Status500InternalServerError, $" Invoice Line could not be updated");
            }
            _logger.LogInformation("Successfully Updated Invoice Line ");
            return result;
        }


    }
}
