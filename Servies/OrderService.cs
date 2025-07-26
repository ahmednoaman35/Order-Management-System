using AutoMapper;
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
    internal class OrderService(IUnitOfWork unitOfWork,IMapper mapper) : Iorder
    {
     
        public Task<int> CreateOrderAsync(CreateOrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderSummaryDto>> GetAllOrdersAsync()
        {
            var order = await unitOfWork.GetRepo<Order, int>().GetAllAsync();
            return mapper.Map<IEnumerable<OrderSummaryDto>>(order);
        }

        public async Task<OrderDetailsDto> GetOrderByIdAsync(int orderId)
        {
            var order = await unitOfWork.GetRepo<Order,int>().GetAsync(orderId);
            return mapper.Map<OrderDetailsDto>(order);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await unitOfWork.GetRepo<Order,int>().GetAsync(orderId);
            if (order == null) throw new Exception("Order not found.");
            order.Status = status;

            // مثال: إرسال إيميل لو تم التحديث
            // await _emailService.SendStatusUpdate(order.Customer.Email, status);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
