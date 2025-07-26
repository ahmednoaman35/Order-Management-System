using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Entites
{
    public class Invoice:BaseEntity<int>
    {
      
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Order Order { get; set; }
    }
}
