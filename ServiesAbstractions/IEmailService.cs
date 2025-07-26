using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiesAbstractions
{
    public interface IEmailService
    {
        Task SendOrderStatusUpdateEmailAsync(string email, string customerName, string orderStatus);

    }
}
