using Sheared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiesAbstractions
{
    public interface Iorder
    {
        Task<int> CreateOrderAsync(CreateOrderDto orderDto);
        Task<OrderDetailsDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderSummaryDto>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}
