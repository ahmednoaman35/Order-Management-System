using Doiman.Contracts;
using Doiman.Entites;
using ServiesAbstractions;
using Sheared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servies
{
    internal class InvoiceService(IUnitOfWork unitOfWork) : IInvoiceService
    {
        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            var invoices = await unitOfWork.GetRepo<Invoice ,int>().GetAllAsync();
            return invoices.Select(i => new InvoiceDto
            {
                InvoiceId = i.Id,
                OrderId = i.OrderId,
                InvoiceDate = i.InvoiceDate,
                TotalAmount = i.TotalAmount
            });
        }

        public async Task<InvoiceDto> GetInvoiceByIdAsync(int id)
        {
            var invoice = await unitOfWork.GetRepo<Invoice, int>().GetAsync(id);
            if (invoice == null) throw new Exception("Invoice not found");

            return new InvoiceDto
            {
                InvoiceId = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                TotalAmount = invoice.TotalAmount,
                OrderId = invoice.OrderId
            };
        }
    }
}
