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
    internal class CustomerService(IUnitOfWork unitOfWork,IMapper mapper) : iCustomerService
    {
        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto dto)
        {
            var customer =  mapper.Map<Customer>(dto);
            await unitOfWork.GetRepo<Customer,int>().AddAsync(customer);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<OrderSummaryDto>> GetCustomerOrdersAsync(int customerId)
        {
            var orders = await unitOfWork.GetRepo<Order,int>().GetAsync(customerId);
            return mapper.Map<IEnumerable<OrderSummaryDto>>(orders);
        }
    }
}
