using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheared
{
    public record UserResultDto(string DisplayName, string Email, string token)
    {
    }
}
