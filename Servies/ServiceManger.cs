using AutoMapper;
using Doiman.Contracts;
using ServiesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servies
{
    public class ServiceManger : IServieceManger
    {

        private readonly Lazy<Iorder> _order;
        private readonly Lazy<IEmailService> _emailService;
        private readonly Lazy<iCustomerService> _customerService;
        private readonly Lazy<iProductService> _productService;

        private readonly Lazy<IInvoiceService> _invoiceService;
        private readonly Lazy<IUserService> _userService;
        

        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _order = new Lazy<Iorder>(() => new OrderService(unitOfWork,mapper));    
        }

        public Iorder Order => _order.Value;

        public IEmailService EmailService => _emailService.Value;

        public iCustomerService CustomerService => _customerService.Value;

        public iProductService ProductService => _productService.Value;

        public IInvoiceService InvoiceService =>_invoiceService.Value;

        public IUserService UserService =>_userService.Value;
    }
}
