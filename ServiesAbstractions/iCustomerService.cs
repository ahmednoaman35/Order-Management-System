using Sheared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiesAbstractions
{
    public interface iCustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerDto dto);
        Task<IEnumerable<OrderSummaryDto>> GetCustomerOrdersAsync(int customerId);

    }
}
