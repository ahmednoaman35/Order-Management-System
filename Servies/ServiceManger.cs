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

        public ServiceManger(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _order = new Lazy<Iorder>(() => new OrderService(unitOfWork,mapper));    
        }

        public Iorder Order => _order.Value;
    }
}
