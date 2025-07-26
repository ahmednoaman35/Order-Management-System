
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Entites
{
    public class User : IdentityUser
    {
   
        public string Displayname { get; set; }
    
    }
}
