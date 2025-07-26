using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiesAbstractions
{
    public interface IServieceManger
    {
        public Iorder Order { get; }

        public IEmailService EmailService { get; }
        public iCustomerService CustomerService { get; }

        public iProductService ProductService { get; }

        public IInvoiceService InvoiceService { get; }

        public IUserService UserService { get; }


    }
}
