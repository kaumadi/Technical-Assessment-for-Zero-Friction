using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Entities;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private DataContext DbContext { get; }
        public InvoiceRepository(DataContext dbContext)
        {
            this.DbContext = dbContext;
        }
        #region 1. CRUD for INVOICES
        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            try
            {
               return await DbContext.Invoices.ToListAsync();
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id, bool isIncludeInvoiceLine)
        {
            try
            {
                // Check Invoice has InvoiceLines
                if (isIncludeInvoiceLine) 
                {
                    return await DbContext.Invoices.Include(b => b.InvoiceLines).FirstOrDefaultAsync(i => i.InvoiceId == id);
                }

                // If InvoiceLines excluded to Invoice
                return await DbContext.Invoices.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> AddInvoiceAsync(InvoiceDTO invoice)
        {
            try
            {

                    await DbContext.Invoices.AddAsync(new Invoice()
                    {
                        Date = invoice.Date,
                        Description = invoice.Description,
                        TotalAmount = invoice.TotalAmount,
                    });
                    await DbContext.SaveChangesAsync();
                return "Successfully Added Invoice";
                //return await DbContext.Invoices.FindAsync(invoice.InvoiceId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<string> UpdateInvoiceAsync(int invoiceid,InvoiceDTO invoice)
        {
            try
            {

                var invoiceToUpdate = await DbContext.Invoices.FirstOrDefaultAsync(s => s.InvoiceId == invoiceid);
                if (invoiceToUpdate != null)
                {
                    invoiceToUpdate.Date = invoice.Date;
                    invoiceToUpdate.Description = invoice.Description;
                    invoiceToUpdate.TotalAmount = invoice.TotalAmount;
                    await DbContext.SaveChangesAsync();
                }
                return "Successfully Updated Invoice";

            }
            catch (Exception ex)
            {
                return null;
            }
        }
#endregion
        #region 2. CRUD for INVOICE LINES
        public async Task<List<InvoiceLine>> GetInvoiceLineAsync()
        {
            try
            {
                return await DbContext.InvoiceLines.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<InvoiceLine> GetInvoiceLineAsync(int id)
        {
            try
            {
                return await DbContext.InvoiceLines.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> AddInvoiceLineAsync(InvoiceLineDTO invoiceLine)
        {
            try
            {

                await DbContext.InvoiceLines.AddAsync(new InvoiceLine()
                {
                    Amount = invoiceLine.Amount,
                    Quantity = invoiceLine.Quantity,
                    UnitPrice = invoiceLine.UnitPrice,
                    LineAmount = invoiceLine.LineAmount,
                    InvoiceId = invoiceLine.InvoiceId

                });
                await DbContext.SaveChangesAsync();
                return "Successfully Added InvoiceLine";
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<string> UpdateInvoiceLineAsync(int invoiceLineid, InvoiceLineDTO invoiceLine)
        {
            try
            {

                var invoiceLineToUpdate = await DbContext.InvoiceLines.FirstOrDefaultAsync(s => s.InvoiceLineId == invoiceLineid);
                if (invoiceLineToUpdate != null)
                {
                    invoiceLineToUpdate.Amount = invoiceLine.Amount;
                    invoiceLineToUpdate.Quantity = invoiceLine.Quantity;
                    invoiceLineToUpdate.UnitPrice = invoiceLine.UnitPrice;
                    invoiceLineToUpdate.InvoiceId = invoiceLine.InvoiceId;
                    invoiceLineToUpdate.LineAmount = invoiceLine.LineAmount;

                    await DbContext.SaveChangesAsync();
                }
                return "Successfully Updated Invoice Line";

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
